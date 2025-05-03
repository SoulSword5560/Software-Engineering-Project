using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EduLearn.handler;
using EduLearn.model;

namespace EduLearn.view.authentication
{
	public partial class login : System.Web.UI.Page
	{
		userHandler userHandler = new userHandler();
		protected void Page_Load(object sender, EventArgs e)
		{
            if (Session["user"] != null || Request.Cookies["user"] != null)
            {
                Response.Redirect("~/View/home/home.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
			string email = emailTB.Text;
			string password = passwordTB.Text;
			User user = userHandler.userLogin(email, password);
			if (user == null)
			{
				errorMsg.Text = "invalid account";
				return;
			}
			Session["user"]=user;
			Session["id"] = user.Id;
			HttpCookie cookie = new HttpCookie("user");
			cookie["name"] = user.Name;
			cookie["id"] = user.Id.ToString();
			cookie.Expires = DateTime.Now.AddDays(2);
			Response.Cookies.Add(cookie);
			Response.Redirect("~/View/home/home.aspx");
        }
    }
}