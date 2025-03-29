using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EduLearn.handler;

namespace EduLearn.view.authentication
{
	public partial class register : System.Web.UI.Page
	{
		userHandler userHandler = new userHandler();
		protected void Page_Load(object sender, EventArgs e)
		{
            if (Session["user"] != null || Request.Cookies["user"] != null)
            {
                Response.Redirect("~/View/home/home.aspx");
            }
        }

        protected void registerBtn_Click(object sender, EventArgs e)
        {
			string username = usernameTB.Text;
			string password = passwordTB.Text;
			string email = emailTB.Text;
			DateTime date = Convert.ToDateTime(dobTB.Text);
			DateTime now = DateTime.Now;

			if(username.Length <= 8)
			{
				errorMsg.Text = "must be a valid username";
				return;
			}
			if (!email.Contains("@"))
			{
				errorMsg.Text = "not a valid email";
				return;
			}
			if (password.Length <= 8) 
			{
				errorMsg.Text = "must be a valid password";
				return;
			}
			if(date > now)
			{
				errorMsg.Text = "not a valid date";
				return ;
			}
			if(now.Year - date.Year < 15)
			{
				errorMsg.Text = "minimum age is 15";
				return;
			}
			userHandler.createUser(username, email, password, date);
			Response.Redirect("~/View/authentication/login.aspx");
        }
    }
}