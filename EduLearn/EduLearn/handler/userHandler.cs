using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EduLearn.factory;
using EduLearn.model;
using EduLearn.repository;

namespace EduLearn.handler
{
	public class userHandler
	{
		userFactorycs userFactorycs = new userFactorycs();
		userRepo userRepo = new userRepo();

		public void createUser(string username, string email, string password, DateTime date)
		{
			User user = userFactorycs.createUser(username, email, password, date);
			userRepo.inserUser(user);
		}

		public User userLogin(string email, string password)
		{
			User user = userRepo.getUser(email, password);
			return user;
		}

		public User getUserByEmail(string email)
		{
			User user = userRepo.getUserByEmail(email);
			return user;
		}
		public void resetPass(string email, string password)
		{
			userRepo.changePassword(email, password);
		}

		public User getUserByName(string name)
		{
			User user = userRepo.getUserByName(name);
			return user;
		}
	}
}