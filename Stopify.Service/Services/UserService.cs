using AutoMapper;
using Stopify.DB.Entities;
using Stopify.DB.Entities.DataContext;
using Stopify.Model;
using Stopify.Model.Dtos;
using Stopify.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Stopify.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        public UserService(IMapper mapper)
        {
            _mapper = mapper;
        }

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

        //List of Users
        public General<UserDetailsDto> GetAllUsers()
        {
            var result = new General<Model.Dtos.UserDetailsDto>() { IsSuccess = false };
            //var model = _mapper.Map<Stopify.DB.Entities.User>(getUsers);
            using (var srv = new StopifyContext())
            {
                var userData = srv.User.OrderBy(x => x.Id);
                result.List = _mapper.Map<List<UserDetailsDto>>(userData);
                result.IsSuccess = true;
                result.TotalCount = userData.Count();
            }
            return result;
        }

        //Get User By Id
        public General<UserDetailsDto> GetUserById(int id)
        {
            var result = new General<Model.Dtos.UserDetailsDto>() { IsSuccess = false };
            using (var srv = new StopifyContext())
            {
                var userData = srv.User.Where(x => x.Id == id);
                result.List = _mapper.Map<List<UserDetailsDto>>(userData);
                result.IsSuccess = true;
            }
            return result;
        }

        //List of Active Users
        public General<UserDetailsDto> GetActiveUsers(/*UserDetailsDto getUsers*/)
        {
            var result = new General<Model.Dtos.UserDetailsDto>() { IsSuccess = false };
            //var model = _mapper.Map<Stopify.DB.Entities.User>(getUsers);
            using (var srv = new StopifyContext())
            {
                var userData = srv.User.Where(x => x.IsActive && !x.IsDeleted).OrderBy(x => x.Id);
                result.List = _mapper.Map<List<UserDetailsDto>>(userData);
                result.IsSuccess = true;
                result.TotalCount = userData.Count();
            }
            return result;
        }

        //Insert
        public General<UserDto> Insert(UserDto newUser)
        {
            var result = new General<Model.Dtos.UserDto>() { IsSuccess = false };

            try
            {
                var model = _mapper.Map<Stopify.DB.Entities.User>(newUser);
                using (var srv = new StopifyContext())
                {
                    var isExisting = srv.User.Any(x=> x.UserName == newUser.UserName);
                    if (isExisting == false)
                    {
                        srv.User.Add(model);
                        srv.SaveChanges();
                        result.Entity = _mapper.Map<Stopify.Model.Dtos.UserDto>(model);
                        result.IsSuccess = true;
                    }
                    else result.ExceptionMessage = "Böyle bir kullanıcı zaten var.";
                }
            }
            catch (Exception)
            {
                result.ExceptionMessage = "Beklenmeyen bir hata oluştu.";
            }

            return result;
        }

        //Update
        public General<UserUpdateDto> Update(UserUpdateDto updateUser)
        {
            var result = new General<Model.Dtos.UserUpdateDto>() { IsSuccess = false };

            var model = _mapper.Map<Stopify.DB.Entities.User>(updateUser);
            using (var srv = new StopifyContext())
            {
                srv.User.Update(model);
                srv.SaveChanges();
                result.Entity = _mapper.Map<Stopify.Model.Dtos.UserUpdateDto>(model);
                result.IsSuccess = true;
            }

            return result;
        }

        //User Activation
        public bool ActivateUser(string userName, string password)
        {
            bool result = false;
            using (var srv = new StopifyContext())
            {
                var existingUser = srv.User.FirstOrDefault(x => x.UserName == userName && x.Password == password);

                if (existingUser != null)
                {
                    existingUser.IsActive = true;
                    srv.User.Update(existingUser);
                    srv.SaveChanges();

                    result = true;
                }

            }
            return result;
        }

        //User Delete
        public General<UserDeleteDto> Delete(/*UserDeleteDto deleteUser,*/ int id)
        {
            var result = new General<Model.Dtos.UserDeleteDto>() { IsSuccess = false };

            //var model = _mapper.Map<Stopify.DB.Entities.User>(deleteUser);
            using (var srv = new StopifyContext())
            {
                var existingUser = srv.User.FirstOrDefault(x => x.Id == id);
                if (existingUser != null)
                {
                    existingUser.IsActive = false;
                    existingUser.IsDeleted = true;
                    srv.User.Update(existingUser);
                    srv.SaveChanges();
                    //result.Entity = _mapper.Map<Stopify.Model.Dtos.UserDeleteDto>(model);
                    result.IsSuccess = true;
                }
                else result.ExceptionMessage = "Böyle bir id mevcut değil!";
            }

            return result;
        }

        
    }
}
