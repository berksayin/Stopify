using AutoMapper;
using Stopify.DB.Entities;
using Stopify.DB.Entities.DataContext;
using Stopify.Model;
using Stopify.Model.Dtos;
using Stopify.Service.Services.Interfaces;
using System;
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
        public General<UserDto> Update(UserDto updateUser)
        {
            var result = new General<Model.Dtos.UserDto>() { IsSuccess = false };

            var model = _mapper.Map<Stopify.DB.Entities.User>(updateUser);
            using (var srv = new StopifyContext())
            {
                srv.User.Update(model);
                srv.SaveChanges();
                result.Entity = _mapper.Map<Stopify.Model.Dtos.UserDto>(model);
                result.IsSuccess = true;
            }

            return result;
        }

        public bool ActivateUser(string userName, string password)
        {
            bool result = false;
            using (var svr = new StopifyContext())
            {
                var existingUser = svr.User.FirstOrDefault(x => x.UserName == userName && x.Password == password);

                if (existingUser != null)
                {
                    existingUser.IsActive = true;
                    svr.User.Update(existingUser);
                    svr.SaveChanges();

                    result = true;
                }

            }
            return result;
        }
    }
}
