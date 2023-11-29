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
    [Table("Errors")]
    public class Error
    {
        [Key]
        public int ErrorID { get; set; }
        public string Text { get; set; }
        public ErrorEnums ErrorType { get; set; }
        public DateTime TimeofOccured { get; set; }
    }
}
