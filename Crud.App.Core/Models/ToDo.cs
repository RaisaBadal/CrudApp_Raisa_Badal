using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.App.Core.Models
{
    [Table("ToDos")]
    public class ToDo
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }
        [ForeignKey("user")]
        public int UserId { get; set; }
        public User user { get; set; }
    }
}
