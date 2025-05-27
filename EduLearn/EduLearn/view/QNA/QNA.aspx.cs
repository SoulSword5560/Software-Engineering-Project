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