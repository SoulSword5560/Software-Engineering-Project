using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EduLearn.view
{
    public partial class navbar : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] != null && Request.Cookies["user"] != null)
            {
                namee.Text =  Request.Cookies["user"]["name"];
            }
            else if (Session["user"] != null)
            {
                namee.Text = Session["user"].ToString();
            }
        }
    }
}