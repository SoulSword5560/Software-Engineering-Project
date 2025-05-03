using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EduLearn.model;
using EduLearn.repository;

namespace EduLearn.view.book
{
    public partial class books : System.Web.UI.Page
    {
        bookRepo bookRepo = new bookRepo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null && Request.Cookies["user"] == null)
            {
                Response.Redirect("~/View/authentication/login.aspx");
            }
            List<Book> books = bookRepo.getAllBooks();
        

            rptBooks.DataSource = books;
            rptBooks.DataBind();
        }

        protected void rptBooks_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "AddBook")
            {
                HiddenField hfBookName = (HiddenField)e.Item.FindControl("hfBookName");

                string userID;
                if (Session["id"] != null)
                {
                    userID = Session["id"].ToString();
                }
                else
                {
                    userID = Request.Cookies["user"]["id"].ToString();
                }

                int UserId = Convert.ToInt32(userID);
                string bookName = hfBookName.Value;

                int BookId = bookRepo.findBookByName(bookName);
                Debug.WriteLine("Book ID: " + BookId);
                bookRepo.addToLibrary(UserId, BookId);
            }
        }
    }
}