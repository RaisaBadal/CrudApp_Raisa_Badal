using Crud.App.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Crud.App.Core.DbContexti
{
    public class DbRaisa:IdentityDbContext<User,Roles,int>
    {
        public DbRaisa()
        {

        }
        public DbRaisa(DbContextOptions<DbRaisa> ops) : base(ops) { }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Error> Errors { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<Company> Companys { get; set; }

    }
}
