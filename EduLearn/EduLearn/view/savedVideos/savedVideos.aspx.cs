using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EduLearn.model;
using EduLearn.repository;

namespace EduLearn.view.savedVideos
{
    public partial class savedVideos : System.Web.UI.Page
    {
        videRepo videRepo = new videRepo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null && Request.Cookies["user"] == null)
            {
                Response.Redirect("~/View/authentication/login.aspx");
            }
            if (!IsPostBack)
            {
                bindData();
            }
        }

        protected void bindData()
        {
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
            List<Video> videos = videRepo.GetUserVideos(UserId);
            videRepo.changeToEmbed(videos);
            rptVideos.DataSource = videos;
            rptVideos.DataBind();
        }
        protected void rptVideos_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "removeFromList")
            {
                HiddenField hfVideoName = (HiddenField)e.Item.FindControl("hfVideoName");

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
                string videoName = hfVideoName.Value;

                int videoId = videRepo.getVideoByName(videoName);
                videRepo.removeFromLibrary(UserId, videoId);
                bindData();
            }
        }
    }
}