using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.App.Core.Models
{
    [Table("Albums")]
    public class Album
    {
        [Key]
        public int AlbumID { get; set; }
        public String Title { get; set; }

        [ForeignKey("Users")]
        public int UserID { get; set; }
        public User users { get; set; }
        public List<Photo> photo { get; set;}
    }
}
