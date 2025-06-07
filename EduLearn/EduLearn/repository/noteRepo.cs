using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using EduLearn.model;

namespace EduLearn.repository
{
    public class noteRepo
    {
        databaseEntities db = dbSingleton.getInstance();
        private string connectionString = @"data source=(LocalDB)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\database.mdf;integrated security=True";
        public int getNoteByName(string name)
        {
            return db.Notes.Where(u => u.Description == name).Select(u => u.ID).FirstOrDefault();
        }
        public List<Note> getAllNotes()
        {
            return db.Notes.ToList();
        }
        public void addToLibrary(int userId, int noteId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string checkQuery = "SELECT COUNT(1) FROM MyNoteList WHERE userID = @userID AND noteID = @noteID";
                string insertQuery = "INSERT INTO MyNoteList (userID, noteID) VALUES (@userID, @noteID)";

                conn.Open();

                // Check if already exists
                SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@userID", userId);
                checkCmd.Parameters.AddWithValue("@noteID", noteId);

                bool exists = ((int)checkCmd.ExecuteScalar()) > 0;

                if (exists)
                {
                    Console.WriteLine("note already in library.");
                    return;
                }

                // Insert if not exists
                SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                insertCmd.Parameters.AddWithValue("@userID", userId);
                insertCmd.Parameters.AddWithValue("@noteID", noteId);
                insertCmd.ExecuteNonQuery();

                Console.WriteLine("note added successfully.");
                var readNotifs = db.Notifications
        .Where(n => n.userID == userId && n.is_read == true)
        .ToList();

                db.Notifications.RemoveRange(readNotifs);
                db.SaveChanges();
                var notif = new Notification
                {
                    userID = userId,
                    messageID = 4,
                    time_created = DateTime.Now,
                    is_read = false
                };
                db.Notifications.Add(notif);
                db.SaveChanges();
            }
        }
        public List<Note> GetUserNotes(int userId)
        {
            List<Note> userNotes = new List<Note>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
           SELECT b.ID, b.Image, b.Description 
            FROM Note b
            INNER JOIN MyNoteList mbl ON b.ID = mbl.NoteID
            WHERE mbl.userID = @userID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userID", userId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    userNotes.Add(new Note
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        Description = reader["Description"].ToString(),
                        Image = reader["Image"].ToString()
                        
                    });
                }
            }

            return userNotes;
        }
    }
}