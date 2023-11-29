using Crud.App.Core.Interfaces;
using Crud.App.Core.Models;
using Crud.App.DataSource.ResponceAndRequest;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.App.Core.Services
{
    public class UserServices : IUser
    {
        private readonly IUserRepos userrepos;
        public UserServices(IUserRepos userrepos)
        {
            this.userrepos = userrepos;
        }

        public List<User> GetAllUsers()
        {
            return userrepos.GetAllUsers();
        }

        public List<User> GetUserByID(GetUserbyId userid)
        {
          return userrepos.GetUserByID(userid);
        }

        public bool InsertUser(InsertUsers insertuser)
        {
           return userrepos.InsertUser(insertuser);
        }

        public bool SoftDeleteUser(SoftDeleteUser deleteuser)
        {
          return userrepos.SoftDeleteUser(deleteuser);
        }

        public bool UpdateUser(UpdateUser updateUser)
        {
           return userrepos.UpdateUser(updateUser);
        }
    }
}
