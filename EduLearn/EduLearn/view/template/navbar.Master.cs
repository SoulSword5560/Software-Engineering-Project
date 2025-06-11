using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EduLearn.model;
using EduLearn.repository;

namespace EduLearn.view
{
    public partial class navbar : System.Web.UI.MasterPage
    {
        databaseEntities db = dbSingleton.getInstance();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] != null && Request.Cookies["user"] != null)
            {
                namee.Text = Request.Cookies["user"]["name"];
            }
            else if (Session["user"] != null)
            {
                namee.Text = Session["user"].ToString();
            }

            if (!IsPostBack)
            {
                refresh();

            }
        }

        protected void btnNotif_Click(object sender, EventArgs e)
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
            var unreadNotifs = db.Notifications
                    .Where(n => n.userID == UserId && n.is_read == false)

                    .ToList();

            if (Session["NotifClicked"] == null || !(bool)Session["NotifClicked"])
            {
                // First click: mark unread as read

                var unread = db.Notifications
                    .Where(n => n.userID == UserId && n.is_read == false)
                    .ToList();

                foreach (var notif in unread)
                {
                    notif.is_read = true;
                }
                db.SaveChanges();

                Session["NotifClicked"] = true;
            }
            else
            {
                // Second click: delete read

                var readNotifs = db.Notifications
                    .Where(n => n.userID == UserId && n.is_read == true)
                    .ToList();

                db.Notifications.RemoveRange(readNotifs);
                db.SaveChanges();

                Session["NotifClicked"] = false;
            }

            // Optionally re-bind your notification list
            refresh();
        }


        protected void refresh()
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
            bool showRead = Session["NotifClicked"] != null && (bool)Session["NotifClicked"];

            var query = db.Notifications.Where(n => n.userID == UserId);

            if (!showRead)
            {
                query = query.Where(n => n.is_read == false);
            }

            var list = query
                .OrderByDescending(n => n.time_created)
                .Select(n => new
                {
                    ID = n.ID,
                    Message = n.MessageTemplate.Template,
                    Time = n.time_created,
                    IsRead = n.is_read
                })
                .ToList();

            notif_badge.Visible = list.Any(n => n.IsRead == false);
            notif_badge.InnerText = list.Count(n => n.IsRead == false).ToString();

            rptNotifications.DataSource = list;
            rptNotifications.DataBind();
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            // Clear session
            Session.Clear();
            Session.Abandon();

            // Clear authentication cookie if used
            if (Request.Cookies["user"] != null)
            {
                HttpCookie cookie = new HttpCookie("user");
                cookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie);
            }

            // Redirect to login page
            Response.Redirect("~/view/authentication/login.aspx");
        }
    }
}