using Api_User.Context;
using Api_User.Dto;
using Api_User.Model;
using Api_User.Services.interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_User.Services.implemaentation
{
    public class UserService : IUserService
    {
        private readonly MyDbContext _myDbContext;

        public UserService(MyDbContext myDbContext, IConfiguration configuration)
        {
            this._myDbContext = myDbContext;
        }

        public UserEntity AddUser(UserEntity userItem)
        {
            var x = _myDbContext.Usuarios.Add(userItem);
            _myDbContext.SaveChanges();
            return userItem;
        }

        public bool DeleteUser(int id)
        {
            var entity = _myDbContext.Usuarios.Find(id);
            if (entity != null)
            {
                var x = _myDbContext.Usuarios.Remove(entity);
                _myDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public UserEntity GetUserByiD(int id)
        {
            var entity = _myDbContext.Usuarios.Find(id);
            return entity;

        }

        public List<UserEntity> GetUsers()
        {
            var all = _myDbContext.Usuarios.ToList();
            return all;
        }

        public bool Login(AuthDTO authDTO)
        {
            var entity = _myDbContext.Usuarios.Where(u=>u.Login.Equals(authDTO.UserName) 
            && u.Password.Equals(authDTO.Password) ).FirstOrDefault();

            return entity != null;

        }
        

        public UserEntity UpdateUser(int id, UserEntity userItem)
        {
            var original = _myDbContext.Usuarios.Find(id);


            if (original != null)
            {
                _myDbContext.Entry(original).CurrentValues.SetValues(userItem);
                _myDbContext.SaveChanges();
            }
            return userItem;
        
    }
    }
}
