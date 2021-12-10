using Stopify.Model;
using Stopify.Model.Dtos;

namespace Stopify.Service.Services.Interfaces
{
    public interface IUserService
    {
        //Interface of UserService
        bool Login(string userName, string password);
        General<UserDetailsDto> GetActiveUsers(/*UserDetailsDto getUsers*/);
        General<UserDto> Insert(UserDto newUser);
        General<UserUpdateDto> Update(UserUpdateDto updateUser);
        bool ActivateUser(string userName, string password);
        General<UserDeleteDto> Delete(UserDeleteDto deleteUser, int id);
    }
}
