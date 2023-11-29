using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.App.Core.Models
{
    [Table ("Users")]
    public class User:IdentityUser<int>
    {
        [Key]
        override
        public int Id { get; set; }
     
        public bool? isActive { get; set; }
        public DateTime? ExpireDate { get; set; }

        [ForeignKey("userProfile")]
        public int UserProfileID { get; set; }
        public UserProfile userProfile { get; set; }
        public List<Post> post { get; set; }
        public List<Album> album { get; set; }
        public List<ToDo> todo { get; set; }
    }
}
