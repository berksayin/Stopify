namespace Stopify.Service.Services.Interfaces
{
    public interface IUserService
    {
        //Interface of UserService
        bool Login(string userName, string password);
        void Insert(Stopify.DB.Entities.User newUser);
    }
}
