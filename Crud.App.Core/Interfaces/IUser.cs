using Crud.App.Core.Models;
using Crud.App.DataSource.ResponceAndRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.App.Core.Interfaces
{
    public interface IUser
    {
        bool InsertUser(InsertUsers insertuser);
        bool UpdateUser(UpdateUser updateUser);
        bool SoftDeleteUser(SoftDeleteUser deleteuser);
        List<User> GetAllUsers();
        List<User> GetUserByID(GetUserbyId userid);

    }
}
