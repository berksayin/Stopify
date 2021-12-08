using Stopify.DB.Entities.DataContext;
using Stopify.Service.Services.Interfaces;
using System;
using System.Linq;

namespace Stopify.Service.Services
{
    public class UserService : IUserService
    {
        //Login
        public bool Login(string userName, string password)
        {
            bool result = false;
            using (var srv = new StopifyContext())
            {
                result = srv.User.Any(a => !a.IsDeleted && a.IsActive &&
                a.UserName == userName && a.Password == password);
            }
            return result;
        }

        public void Insert(Stopify.DB.Entities.User newUser)
        {
            using (var srv = new StopifyContext())
            {
                srv.User.Add(newUser);
                srv.SaveChanges();
            }

        }
    }
}
