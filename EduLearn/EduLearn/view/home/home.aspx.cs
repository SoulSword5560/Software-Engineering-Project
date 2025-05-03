using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EduLearn.model;
using EduLearn.repository;

namespace EduLearn.view.home
{
	public partial class home : System.Web.UI.Page
	{
        videRepo videRepo = new videRepo();
        bookRepo bookRepo = new bookRepo();
        private string connectionString = @"data source=(LocalDB)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\database.mdf;integrated security=True";
		protected void Page_Load(object sender, EventArgs e)
		{
            if (Session["user"] == null && Request.Cookies["user"] == null)
            {
                Response.Redirect("~/View/authentication/login.aspx");
            }

            if (!IsPostBack)
            {
                LoadYouTubeVideo();
                bindData();
            }
        }

        protected void bindData()
        {
            List<Book> books = bookRepo.getTop3Books();

            bookRepeater.DataSource = books;
            bookRepeater.DataBind();
        }

        private void LoadYouTubeVideo()
        {
            string videoUrl = videRepo.getFirstVideo();
            //using (SqlConnection conn = new SqlConnection(connectionString))
            //{
            //    conn.Open();
            //    SqlCommand cmd = new SqlCommand("SELECT TOP 1 URL FROM Video", conn);
            //    SqlDataReader reader = cmd.ExecuteReader();
            //    if (reader.Read())
            //    {
            //        videoUrl = reader["URL"].ToString();
            //    }
            //}

            //if (!string.IsNullOrEmpty(videoUrl))
            //{
            //    string embedUrl = ConvertToEmbed(videoUrl);
            //    if (!string.IsNullOrEmpty(embedUrl))
            //    {
            //        ytVideo.Src = embedUrl; // Use the Src property directly
            //    }
            //}
        }
        public string GetYouTubeEmbedUrl()
        {
            string videoUrl = videRepo.getFirstVideo();
            return ConvertToEmbed(videoUrl) ?? "about:blank"; // Fallback if URL is invalid
        }
        private string ConvertToEmbed(string url)
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
    }
}