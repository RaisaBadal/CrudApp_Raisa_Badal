using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.App.Core.Models
{
    [Table("Photos")]
    public class Photo
    {
        [Key]
        public int PhotoID { get; set; }
        public string? Title { get; set; }
        public string? Url { get; set; }
        public string? thumbnailUrl { get; set; }
        [ForeignKey("album")]
        public int AlbumID { get; set; }
        public Album album { get; set; }
    }
}
