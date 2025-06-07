using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using EduLearn.model;

namespace EduLearn.repository
{
    public class bookRepo
    {
        databaseEntities db = dbSingleton.getInstance();
        private string connectionString = @"data source=(LocalDB)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\database.mdf;integrated security=True";

        public List<Book> getAllBooks()
        {
            return db.Books.ToList();
        }

        public List<Book> getTop3Books()
        {
            return db.Books.OrderBy(b => b.ID).Take(3).ToList();
        }

        public int findBookByName(string name)
        {
            return db.Books.Where(u => u.Name == name).Select(u => u.ID).FirstOrDefault();
        }
        public void addToLibrary(int userId, int bookId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string checkQuery = "SELECT COUNT(1) FROM MyBookList WHERE userID = @userID AND bookID = @bookID";
                string insertQuery = "INSERT INTO MyBookList (userID, bookID) VALUES (@userID, @bookID)";

                conn.Open();

                // Check if already exists
                SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@userID", userId);
                checkCmd.Parameters.AddWithValue("@bookID", bookId);

                bool exists = ((int)checkCmd.ExecuteScalar()) > 0;

                if (exists)
                {
                    Console.WriteLine("Book already in library.");
                    return;
                }

                // Insert if not exists
                SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                insertCmd.Parameters.AddWithValue("@userID", userId);
                insertCmd.Parameters.AddWithValue("@bookID", bookId);
                insertCmd.ExecuteNonQuery();

                Console.WriteLine("Book added successfully.");
                var readNotifs = db.Notifications
        .Where(n => n.userID == userId && n.is_read == true)
        .ToList();

                db.Notifications.RemoveRange(readNotifs);
                db.SaveChanges();
                var notif = new Notification
                    {
                        userID = userId,
                        messageID = 1,
                        time_created = DateTime.Now,
                        is_read = false
                    };
                    db.Notifications.Add(notif);
                db.SaveChanges();

            }
        }

        public List<Book> GetUserBooks(int userId)
        {
            List<Book> userBooks = new List<Book>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
           SELECT b.ID, b.Name, b.Image, b.URL, b.Category 
            FROM Book b
            INNER JOIN MyBookList mbl ON b.ID = mbl.bookID
            WHERE mbl.userID = @userID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userID", userId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    userBooks.Add(new Book
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        Image = reader["Image"].ToString(),
                        Name = reader["Name"].ToString(),
                        URL = reader["URL"].ToString(),
                        Category = reader["Category"].ToString()
                    });
                }
            }

            return userBooks;
        }

        public void removeFromLibrary(int userId, int bookId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string deleteQuery = "DELETE FROM MyBookList WHERE userID = @userID AND bookID = @bookID";

                SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn);
                deleteCmd.Parameters.AddWithValue("@userID", userId);
                deleteCmd.Parameters.AddWithValue("@bookID", bookId);

                conn.Open();
                int rowsAffected = deleteCmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Book removed successfully.");
                }
                else
                {
                    Console.WriteLine("Book was not found in the library.");
                }
            }
        }
    }
}