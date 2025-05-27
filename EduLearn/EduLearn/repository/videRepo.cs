using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using EduLearn.model;

namespace EduLearn.repository
{

    public class videRepo
    {
        databaseEntities db = dbSingleton.getInstance();
        private string connectionString = @"data source=(LocalDB)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\database.mdf;integrated security=True";

        public string getFirstVideo()
        {
            int ID = 1;
            return db.Videos.Where(u => u.ID == ID).Select(u => u.URL).FirstOrDefault();
        }
        public List<Video> getAllVideos()
        {
            return db.Videos.ToList();
        }

        public void addToLibrary(int userId,int videoId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string checkQuery = "SELECT COUNT(1) FROM MyVideoList WHERE userID = @userID AND videoID = @videoID";
                string insertQuery = "INSERT INTO MyVideoList (userID, videoID) VALUES (@userID, @videoID)";

                conn.Open();

                // Check if already exists
                SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@userID", userId);
                checkCmd.Parameters.AddWithValue("@videoID", videoId);

                bool exists = ((int)checkCmd.ExecuteScalar()) > 0;

                if (exists)
                {
                    Console.WriteLine("video already in library.");
                    return;
                }

                // Insert if not exists
                SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                insertCmd.Parameters.AddWithValue("@userID", userId);
                insertCmd.Parameters.AddWithValue("@videoID", videoId);
                insertCmd.ExecuteNonQuery();

                Console.WriteLine("Video added successfully.");
            }
        }

        public List<Video> changeToEmbed(List<Video> videos)
        {
            foreach (var video in videos)
            {
                video.URL = ConvertToEmbed(video.URL);
            }
            return videos;
        }
        public int getVideoByName(string name)
        {
            return db.Videos.Where(u => u.Name == name).Select(u =>u.ID).FirstOrDefault();
        }
        public string ConvertToEmbed(string url)
        {
            try
            {
                Uri uri = new Uri(url);
                string host = uri.Host.ToLower();

                if (host.Contains("youtu.be"))
                {
                    // Short URL format
                    return "https://www.youtube.com/embed" + uri.AbsolutePath;
                }
                else if (host.Contains("youtube.com"))
                {
                    // Standard URL format
                    var query = System.Web.HttpUtility.ParseQueryString(uri.Query);
                    string videoId = query["v"];
                    return "https://www.youtube.com/embed/" + videoId;
                }
            }
            catch
            {
                // Invalid URL
            }

            return "";
        }
        public List<Video> GetUserVideos(int userId)
        {
            List<Video> userVideos = new List<Video>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
           SELECT b.ID, b.Name, b.Description, b.URL, b.Category 
            FROM Video b
            INNER JOIN MyVideoList mbl ON b.ID = mbl.VideoID
            WHERE mbl.userID = @userID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userID", userId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    userVideos.Add(new Video
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        Description = reader["Description"].ToString(),
                        Name = reader["Name"].ToString(),
                        URL = reader["URL"].ToString(),
                        Category = reader["Category"].ToString()
                    });
                }
            }

            return userVideos;
        }

        public void removeFromLibrary(int userId, int VideoId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string deleteQuery = "DELETE FROM MyVideoList WHERE userID = @userID AND VideoID = @VideoID";

                SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn);
                deleteCmd.Parameters.AddWithValue("@userID", userId);
                deleteCmd.Parameters.AddWithValue("@videoID", VideoId);

                conn.Open();
                int rowsAffected = deleteCmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Video removed successfully.");
                }
                else
                {
                    Console.WriteLine("Video was not found in the library.");
                }
            }
        }
    }

}