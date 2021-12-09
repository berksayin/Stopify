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
            var result = new General<Model.Dtos.UserDto>() {IsSuccess = false };

            try
            {
                var model = _mapper.Map<Stopify.DB.Entities.User>(newUser);
                using (var srv = new StopifyContext())
                {
                    srv.User.Add(model);
                    srv.SaveChanges();
                    result.Entity = _mapper.Map<Stopify.Model.Dtos.UserDto>(model);
                    result.IsSuccess = true;
                }
            }
            catch (Exception)
            {
                result.ExceptionMessage = "Beklenmeyen bir hata oluştu.";
            }
            
            return result;
        }

        //public void Insert(Stopify.DB.Entities.User newUser)
        //{
        //    using (var srv = new StopifyContext())
        //    {
        //        srv.User.Add(newUser);
        //        srv.SaveChanges();
        //    }

        //}
    }
}
