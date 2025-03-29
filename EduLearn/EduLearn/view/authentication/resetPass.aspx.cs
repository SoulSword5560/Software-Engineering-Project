using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EduLearn.handler;

namespace EduLearn.view.authentication
{
	public partial class resetPass : System.Web.UI.Page
	{
		userHandler userHandler = new userHandler();
		protected void Page_Load(object sender, EventArgs e)
		{

		}

        protected void btnReset_Click(object sender, EventArgs e)
        {
			string email = emailTB.Text;
			string password = passwordTB.Text;
			string con = conTB.Text;

			if(userHandler.getUserByEmail(email) == null)
			{
				errorMsg.Text = "wrong email";
				return;
			}
			if (password != con)
			{
				errorMsg.Text = "password not the same";
				return ;
			}
            if (password.Length <= 8)
            {
                errorMsg.Text = "must be a valid password";
                return;
            }
			userHandler.resetPass(email, password);
			Response.Redirect("~/view/authentication/login.aspx");
        }
    }
}