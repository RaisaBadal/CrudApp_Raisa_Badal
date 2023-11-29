using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.App.Core.Models
{
    [Table("Posts")]
    public class Post
    {
        [Key]
        public int PostID { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        [ForeignKey("Users")]
        public int UserID { get; set; }
        public User users { get; set; }
        public List<Comment> comment { get; set; }
    }
}
