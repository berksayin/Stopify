using Stopify.Model;
using Stopify.Model.Dtos;

namespace Stopify.Service.Services.Interfaces
{
    public interface IUserService
    {
        //Interface of UserService
        bool Login(string userName, string password);
        public General<Stopify.Model.Dtos.UserDto> Insert(Stopify.Model.Dtos.UserDto newUser);
        General<UserDto> Update(UserDto updateUser);
        bool ActivateUser(string userName, string password);
        //void Insert(Stopify.DB.Entities.User newUser);
    }
}
