using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.App.Core.Models
{
    [Table("Comments")]
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }
        public string name { get; set; }
        public string Email { get; set; }
        public string Body { get; set; }
        [ForeignKey("Posts")]
        public int PostID { get; set; }
        public Post posts { get; set; }
    }
}
