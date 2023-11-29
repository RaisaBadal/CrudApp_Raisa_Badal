using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.App.Core.Models
{
    [Table("Companys")]
    public class Company
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string catchPhrase { get; set; }
        public string bs { get; set; }
        
        public UserProfile userProfile { get; set; }

    }
}
