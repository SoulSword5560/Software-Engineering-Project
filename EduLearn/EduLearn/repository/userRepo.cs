using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EduLearn.model;

namespace EduLearn.repository
{
	public class userRepo
	{
		databaseEntities db = dbSingleton.getInstance();
		public void inserUser(User user)
		{
			db.Users.Add(user);
			db.SaveChanges();
		}

        public User getUser(string email, string password)
        {
            User user = (from x in db.Users where x.Email == email && x.password == password select x).FirstOrDefault();
            return user;
        }

		public User getUserByEmail(string email)
		{
            User user = (from x in db.Users where x.Email == email  select x).FirstOrDefault();
            return user;
        }

		public User getUserByName(string name)
		{
            User user = (from x in db.Users where x.Name == name select x).FirstOrDefault();
            return user;
        }
		public void changePassword(string email, string password)
		{
			User user = getUserByEmail(email);
			user.password = password;
			db.SaveChanges();
		}
    }
}