using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using EduLearn.handler;
using EduLearn.model;

namespace EduLearn.view.account
{
	public partial class account : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            userHandler userHandler = new userHandler();
            if(Request.Cookies["user"] != null && Request.Cookies["user"] != null)
            {
                User user = userHandler.getUserByName(Request.Cookies["user"]["name"]);
                name.Text = "Username: &nbsp;&nbsp;" + Request.Cookies["user"]["name"];
                email.Text = "Email: &nbsp;&nbsp;" + user.Email;
                dob.Text = "DOB: &nbsp;&nbsp;" + user.DOB.ToString("dd/MM/yyyy");

            }
            else if (Session["user"] != null)
            {
                User user = userHandler.getUserByName(Session["user"].ToString());
                name.Text = "Username: &nbsp;&nbsp;" + Request.Cookies["user"]["name"];
                email.Text = "Email: &nbsp;&nbsp;" + user.Email;
                dob.Text = "DOB: &nbsp;&nbsp;" + user.DOB.ToString("dd/MM/yyyy");

            }
        }

        protected void resetPass_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/view/authentication/resetPass.aspx");
        }
    }
}