using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EduLearn.model;

namespace EduLearn.factory
{
	public class userFactorycs
	{
		public User createUser(string username, string email, string password, DateTime date)
		{
			User user = new User();
			user.Name = username;
			user.Email = email;
			user.password = password;
			user.DOB = date;
			return user;
		}
	}
}