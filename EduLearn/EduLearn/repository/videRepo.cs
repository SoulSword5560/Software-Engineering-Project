using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using EduLearn.model;

namespace EduLearn.repository
{

    public class videRepo
    {
        databaseEntities db = dbSingleton.getInstance();

        public string getFirstVideo()
        {
            int ID = 1;
            return db.Videos.Where(u => u.ID == ID).Select(u => u.URL).FirstOrDefault();
        }

    }
}