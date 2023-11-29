using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.App.Core.Models
{
    [Table("UserAddresses")]
    public class UserAddress
    {
        [Key]
        public int UserAddressID { get; set; }

        public string? City { get; set; }
        public string? Street { get; set; }
        public string? ZipCode { get; set; }
        public UserProfile userProfile { get; set; }
    }
}
