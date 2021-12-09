using Stopify.Model;

namespace Stopify.Service.Services.Interfaces
{
    public interface IUserService
    {
        //Interface of UserService
        bool Login(string userName, string password);
        public General<Stopify.Model.Dtos.UserDto> Insert(Stopify.Model.Dtos.UserDto newUser);
        //void Insert(Stopify.DB.Entities.User newUser);
    }
}
