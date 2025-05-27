using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EduLearn.model;

namespace EduLearn.repository
{
    public class QNARepo
    {
        databaseEntities db = dbSingleton.getInstance();
        public List<qnaViewModel> GetAllQnaWithBook()
        {
                    var query = @"
                SELECT b.Image AS Image, q.QuestionURL, q.AnswerURL
                FROM BookQNA bq
                INNER JOIN Book b ON bq.BookId = b.Id
                INNER JOIN QNA q ON bq.QnaId = q.Id
            ";

            return db.Database.SqlQuery<qnaViewModel>(query).ToList();

        }
    }
}