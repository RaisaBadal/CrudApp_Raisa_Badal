using Crud.App.DataSource.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.App.Core.Models
{
    [Table("Logs")]
    public class Log
    {
        [Key]
        public int LogID { get; set; }
        public String LogText { get; set; }   
        public DateTime LogDate { get; set; }
    }
}
