using Stopify.DB.Entities.DataContext;
using Stopify.Service.Services.Interfaces;
using System;
using System.Linq;

namespace Stopify.Service.Services
{
    public class UserService : IUserService
    {
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

        public void Insert()
        {
            var newUser = new Stopify.DB.Entities.User();
            using (var srv = new StopifyContext())
            {
                try
                {
                    srv.Database.BeginTransaction();
                    srv.User.Add(newUser);
                    srv.SaveChanges();
                    srv.Database.CommitTransaction();
                }
                catch (Exception)
                {
                    srv.Database.RollbackTransaction();
                }
            }
            
        }
    }
}
