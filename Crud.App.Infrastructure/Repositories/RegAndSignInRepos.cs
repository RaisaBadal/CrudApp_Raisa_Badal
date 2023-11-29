using Crud.App.Core.DbContexti;
using Crud.App.Core.Interfaces;
using Crud.App.Core.Models;
using Crud.App.DataSource.Enums;
using Crud.App.DataSource.JsonDecerialize;
using Crud.App.DataSource.ResponceAndRequest;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Crud.App.Infrastructure.Repositories
{
    public class RegAndSignInRepos : IRegAndSignInRepos
    {
        public readonly DbRaisa dbraisa;
        private readonly IErrorRepos error;
        private readonly ILogRepos log;
        private readonly UserManager<User> _managUser;
        private readonly RoleManager<Roles> _rolemanager;
        private readonly IConfiguration config;
        private readonly IUserRepos usereg;
        public RegAndSignInRepos(IUserRepos usereg, DbRaisa dbraisa, UserManager<User> manager, RoleManager<Roles> rol, IConfiguration config, IErrorRepos error, ILogRepos log)
        {
            this.usereg = usereg;
            this.dbraisa = dbraisa;
            this.error = error;
            this.log = log;
            _managUser = manager;
            _rolemanager = rol;
            this.config = config;
        }

        #region RegistrationManager
        public async Task<bool> RegistrationManager(InsertManager signUp)
        {
            using (var transaction = dbraisa.Database.BeginTransaction())
            {
                try
                {
                    dbraisa.UserAddresses.Add(new UserAddress()
                    {
                        City = signUp.City,
                        Street = signUp.Street,
                        ZipCode = signUp.ZipCode
                    });
                    dbraisa.Companys.Add(new Company()
                    {
                        bs = signUp.bs,
                        catchPhrase = signUp.catchPhrase,
                        Name = signUp.Name,
                    });
                    dbraisa.SaveChanges();
                    int indexofaddres = dbraisa.UserAddresses.Max(i => i.UserAddressID);
                    int indexofcompany = dbraisa.Companys.Max(io => io.ID);
                    dbraisa.UserProfiles.Add(new UserProfile()
                    {
                        AddressID = indexofaddres,
                        CompanyID = indexofcompany,
                        FirstName = signUp.FirstName,
                        LastName = signUp.LastName,
                        PersonalNumber = signUp.PersonalNumber
                    });

                    dbraisa.SaveChanges();

                    var indexofprofile = dbraisa.UserProfiles.Max(i => i.UserProfileID);

                    User manage = new User()
                    {
                        Email = signUp.Email,
                        isActive = true,
                        UserName = signUp.UserName,
                        UserProfileID = indexofprofile,
                        EmailConfirmed = true,

                    };
                    var res = await _managUser.CreateAsync(manage, signUp.Password);
                    if (res.Succeeded)
                    {


                        string role = signUp.Role.ToUpper();
                        if (role == "ADMIN" || role == "USER" || role == "MANAGER")
                        {

                            var roleExists = await _rolemanager.RoleExistsAsync(signUp.Role.ToUpper());


                            if (!roleExists)
                            {
                                var roleResult = await _rolemanager.CreateAsync(new Roles(signUp.Role.ToUpper()));

                                if (!roleResult.Succeeded)
                                {
                                    transaction.Rollback();
                                    return false;
                                }
                            }

                            var resultofroleasign = await _managUser.AddToRoleAsync(manage, signUp.Role.ToUpper());
                            await dbraisa.SaveChangesAsync();
                            if (resultofroleasign.Succeeded)
                            {
                                transaction.Commit();
                                log.ActionLog("Manager  Succesfully Registered to the system");
                                return true;
                            }
                            else
                            {
                                transaction.Rollback();
                                return false;
                            }
                        }
                    }
                    transaction.Rollback();
                    return false;
                }

                catch (Exception ex)
                {
                    transaction.Rollback();
                    error.Action(ex.Message + " " + ex.StackTrace, ErrorEnums.Fatal);
                    throw;
                }
            }
        }


        #endregion

        #region SignIn


        public async Task<string> SignIn(GetManagerAuthent manAuth)
        {
            try
            {
                Console.WriteLine(manAuth.UserName);
                var res = await _managUser.FindByNameAsync(manAuth.UserName);
                if (res == null) return null;

                var checkedpass = await _managUser.CheckPasswordAsync(res, manAuth.Password);
                if (checkedpass)
                {
                    var roli = await _managUser.GetRolesAsync(res);
                    if (roli.FirstOrDefault() != null)
                    {
                        await Console.Out.WriteLineAsync(roli.First());
                        var re = await GenerateJwtToken(res, roli.First());
                        if (re == null) return null;
                        return re;
                    }
                }

                return null;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return null;
            }

        }

        private async Task<string> GenerateJwtToken(User user, string role)
        {
            if (user != null)
            {
                var claims = new[]
                {
              new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
              new Claim(ClaimTypes.Name,user.UserName),
              new Claim(ClaimTypes.Role,role),
              new Claim(ClaimTypes.Email,user.Email),
              new Claim(ClaimTypes.MobilePhone,user.PhoneNumber)
            };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.GetSection("JWT:KEY").Value));

                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: config.GetSection("JWT:ISSUER").Value,
                    audience: config.GetSection("JWT:AUDIENCE").Value,
                    claims: claims,
                    expires: DateTime.Now.AddHours(12),
                    signingCredentials: credentials
                );
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            return null;
        }
        #endregion

        #region getalldatafromresource
        public  bool getalldatafromresource()
        {
            string url = "https://jsonplaceholder.typicode.com/users";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    var users = JsonConvert.DeserializeObject<JsonUser[]>(jsonContent);
                    Random rand = new Random();
                    string piradi = "3454444" + rand.Next(1000, 9999).ToString();
                    foreach (var item in users)
                    {
                        Console.WriteLine("----------------1");
                        Console.WriteLine(item.address.city);
                        string[] name = item.name.Split(' ');
                        dbraisa.UserAddresses.Add(new UserAddress()
                        {
                            City = item.address.city,
                            Street = item.address.street,
                            ZipCode = item.address.zipcode
                        });
                        dbraisa.Companys.Add(new Company()
                        {
                            Name=item.company.name,
                            catchPhrase= item.company.catchPhrase,
                            bs= item.company.bs
                        });
                        dbraisa.SaveChanges();
                        int userAddressID = dbraisa.UserAddresses.Max(i=>i.UserAddressID);
                        int companyidd = dbraisa.Companys.Max(i => i.ID);
                        dbraisa.UserProfiles.Add(new UserProfile()
                        {
                            FirstName = name[0],
                            LastName = name[1],
                            AddressID= userAddressID,
                            CompanyID= companyidd,
                            PersonalNumber=piradi,
                            
                        });
                        dbraisa.SaveChanges();
                        int userprofid = dbraisa.UserProfiles.Max(i => i.UserProfileID);
                        dbraisa.Users.Add(new User()
                        {
                            Email=item.email,
                            isActive=true,
                            PasswordHash="crudapp2123",
                            UserName=item.username,
                            UserProfileID=userprofid
                        });
                        dbraisa.SaveChanges();
                       
                    }
                }
            }
            #region todo
            //todo
            string urlTodo = "https://jsonplaceholder.typicode.com/todos";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(urlTodo).Result;
                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    var todos = JsonConvert.DeserializeObject<JsonToDo[]>(jsonContent);

                    foreach (var item in todos)
                    {
                        dbraisa.ToDos.Add(new ToDo
                        {
                            Title = item.title,
                            Completed = item.completed,
                            UserId = item.userId

                        });
                        dbraisa.SaveChanges();
                    }
                }
            }
            #endregion

            #region album


            //album
            string urlalbum = "https://jsonplaceholder.typicode.com/albums";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(urlalbum).Result;
                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    var album = JsonConvert.DeserializeObject<JsonAlbum[]>(jsonContent);

                    foreach (var item in album)
                    {
                        dbraisa.Albums.Add(new Album
                        {
                            Title = item.title,
                            UserID = item.userId
                        });
                        dbraisa.SaveChanges();
                    }
                }
            }

            #endregion

            #region photo


            //photo
            string urlphoto = "https://jsonplaceholder.typicode.com/photos";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(urlphoto).Result;
                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    var photo = JsonConvert.DeserializeObject<JsonPhoto[]>(jsonContent);

                    foreach (var item in photo)
                    {
                        dbraisa.Photos.Add(new Photo
                        {
                            thumbnailUrl = item.thumbnailUrl,
                            Title = item.title,
                            Url = item.url,
                            AlbumID = item.albumId

                        });
                        dbraisa.SaveChanges();
                    }
                }
            }
            #endregion

            #region post

            //post
            string urlpost = "https://jsonplaceholder.typicode.com/posts";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(urlpost).Result;
                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    var post = JsonConvert.DeserializeObject<JsonPost[]>(jsonContent);

                    foreach (var item in post)
                    {
                        dbraisa.Posts.Add(new Post
                        {
                            Body = item.body,
                            Title = item.title,
                            UserID = item.userId

                        });
                        dbraisa.SaveChanges();
                    }
                }
            }

            #endregion

            #region comment
            //post
            string urlcomment = "https://jsonplaceholder.typicode.com/comments";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(urlcomment).Result;
                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    var comm = JsonConvert.DeserializeObject<JsonComment[]>(jsonContent);

                    foreach (var item in comm)
                    {
                        dbraisa.Comments.Add(new Comment
                        {
                            Body = item.body,
                            Email = item.email,
                            name = item.name,
                            PostID = item.postId

                        });
                        dbraisa.SaveChanges();
                    }
                }
            }
            #endregion

            return true;
        }
        #endregion
    }
}




