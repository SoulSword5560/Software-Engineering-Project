using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EduLearn.model;

namespace EduLearn.repository
{
	public class dbSingleton
	{
        private static databaseEntities instance;

        public static databaseEntities getInstance()
        {
            if (instance == null)
            {
                instance = new databaseEntities();
            }
            return instance;
        }
    }
}