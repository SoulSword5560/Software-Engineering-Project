using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EduLearn.model;
using EduLearn.repository;

namespace EduLearn.view.Notes
{
    public partial class note : System.Web.UI.Page
    {
        noteRepo noteRepo = new noteRepo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null && Request.Cookies["user"] == null)
            {
                Response.Redirect("~/View/authentication/login.aspx");
            }
            if (!IsPostBack)
            {
                List<Note> notes = noteRepo.getAllNotes();
                rptNotes.DataSource = notes;
                rptNotes.DataBind();
            }
        }
        protected void rptNotes_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "AddNote")
            {
                HiddenField hfNoteName = (HiddenField)e.Item.FindControl("hfNoteName");

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
                string noteName = hfNoteName.Value;

                int noteId = noteRepo.getNoteByName(noteName);
                Debug.WriteLine("video ID: " + noteId);
                noteRepo.addToLibrary(UserId, noteId);
            }
        }
    }
}