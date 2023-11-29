using Crud.App.Core.DbContexti;
using Crud.App.Core.Interfaces;
using Crud.App.Core.Models;
using Crud.App.DataSource.Enums;
using Crud.App.DataSource.ResponceAndRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.App.Infrastructure.Repositories
{
    public class UserServicesRepos:IUserRepos
    {
        public readonly DbRaisa dbraisa;
        public readonly IErrorRepos ierrorrepos;
        public readonly ILogRepos ilogrepos;
        public UserServicesRepos(DbRaisa dbraisa, IErrorRepos ierrorrepos, ILogRepos ilogrepos)
        {
            this.dbraisa = dbraisa;
            this.ierrorrepos = ierrorrepos;
            this.ilogrepos = ilogrepos;
        }
    
        #region InsertUser
        public bool InsertUser(InsertUsers insertuser)
        {
            using (var trans = dbraisa.Database.BeginTransaction())
            {
                try
                {
                    var userProfileID = 0;
                    var companyID = 0;
                    var addressID = 0;

                    var company = new Company
                    {
                        Name = insertuser.Name,
                        catchPhrase = insertuser.catchPhrase,
                       
                        bs = insertuser.bs
                    };

                    dbraisa.Companys.Add(company);
                    dbraisa.SaveChanges();
                    companyID = dbraisa.Companys.Select(i => i.ID).Max();
                    ilogrepos.ActionLog($"Company successfuly inserted: {companyID}");

                    var address = new UserAddress
                    {
                        City = insertuser.City,
                        Street = insertuser.Street,
                        ZipCode = insertuser.ZipCode,
                        
                    };
                    dbraisa.UserAddresses.Add(address);
                    dbraisa.SaveChanges();
                    addressID = dbraisa.UserAddresses.Select(i => i.UserAddressID).Max();
                    ilogrepos.ActionLog($"Address successfuly inserted:{addressID}");
                    var userProf = new UserProfile
                    {
                        FirstName = insertuser.FirstName,
                        LastName = insertuser.LastName,
                        PersonalNumber = insertuser.PersonalNumber,
                        AddressID = addressID,
                        CompanyID = companyID
                    };
                    var userp = dbraisa.UserProfiles.Where(i => i.PersonalNumber == insertuser.PersonalNumber).FirstOrDefault();
                    if (userp != null)
                    {
                        ierrorrepos.Action($"Such a user profile already exists, personal number:{insertuser.PersonalNumber}", ErrorEnums.error);
                        trans.Rollback();
                    }
                    else
                    {
                        dbraisa.UserProfiles.Add(userProf); dbraisa.SaveChanges();
                        ilogrepos.ActionLog($"UserProfiles successfuly inserted:{userProfileID}");

                    }
                    userProfileID = dbraisa.UserProfiles.Select(i => i.UserProfileID).Max();
                    var user = new User
                    {
                        UserName = insertuser.UserName,
                        PasswordHash = insertuser.Password,
                        Email = insertuser.Email,
                        isActive = true,
                        UserProfileID = userProfileID
                    };
                    var users = dbraisa.Users.Where(i => i.Email == insertuser.Email).FirstOrDefault();
                    if (users == null)
                    {
                        dbraisa.Users.Add(user);
                        dbraisa.SaveChanges();
                        ilogrepos.ActionLog($"User Successfuly Inserted, UserID ->{user.Id} ");
                        trans.Commit();
                        return true;
                    }
                    else
                    {
                        trans.Rollback();
                        ilogrepos.ActionLog($"Such a user already exists");

                        return false;
                    }


                }
                catch (Exception ex)
                {
                    ierrorrepos.Action($"Error message:{ex.Message}, Error occured in Line: {ex.StackTrace}", ErrorEnums.Fatal);
                    trans.Rollback();
                    throw;
                }
            }
        }
        #endregion

        #region UpdateUser
        public bool UpdateUser(UpdateUser updateUser)
        {
            try
            {
                var userid = dbraisa.Users.Where(i => i.Id == updateUser.UserID).FirstOrDefault();
                if (userid == null)
                {
                    ilogrepos.ActionLog("No such user exists");
                    ierrorrepos.Action("No such user exists", ErrorEnums.error);
                    return false;
                }
                else
                {
                    userid.UserName = updateUser.UserName;
                    userid.Email = updateUser.Email;
                    ilogrepos.ActionLog($"Successfuly update User, UserID: {userid.Id}");
                    dbraisa.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                ierrorrepos.Action(ex.Message + "," + ex.StackTrace, ErrorEnums.Fatal);
                throw;
            }
        }
        #endregion

        #region SoftDeleteUser
        public bool SoftDeleteUser(SoftDeleteUser deleteuser)
        {
            try
            {
                var useri=dbraisa.Users.Where(i=>i.Id==deleteuser.UserId).FirstOrDefault();
                if (useri ==null)
                {
                    ierrorrepos.Action($"No user exist, userid: {deleteuser.UserId}",ErrorEnums.error);
                    return false;
                }
                else
                {
                    useri.isActive = false;
                    ilogrepos.ActionLog($"Successfuly deleted, userid: {deleteuser.UserId}");
                    dbraisa.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                ierrorrepos.Action(ex.Message + " " +ex.StackTrace, ErrorEnums.Fatal);
                throw;
            }
        }


        #endregion

        #region GetAllUsers
        public List<User> GetAllUsers()
        {
          return dbraisa.Users.ToList();
        }
        #endregion

        #region GetUserById
        public List<User> GetUserByID(GetUserbyId userid)
        {
            try
            {
                var user = dbraisa.Users.Where(i => i.Id == userid.userId).ToList() ;
                if (user == null)
                {
                    ierrorrepos.Action("No User By this ID",ErrorEnums.Info);
                }
                return user;
            }
            catch (Exception ex)
            {
                ierrorrepos.Action(ex.Message, ErrorEnums.Fatal);
                throw;
            }
        }
        #endregion


    }
}
