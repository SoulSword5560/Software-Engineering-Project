using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EduLearn.repository;

namespace EduLearn.view.QNA
{
    public partial class QNA : System.Web.UI.Page
    {
        QNARepo repo = new QNARepo();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["user"] == null && Request.Cookies["user"] == null)
            {
                Response.Redirect("~/View/authentication/login.aspx");
            }
            BindQna();
        }
        private void BindQna()
        {
            var qnaWithBooks = repo.GetAllQnaWithBook();
            rptQna.DataSource = qnaWithBooks;
            rptQna.DataBind();
        }
    }
}