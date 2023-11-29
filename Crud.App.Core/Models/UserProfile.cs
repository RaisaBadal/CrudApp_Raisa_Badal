using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Crud.App.Core.Models
{
    [Table("UserProfiles")]
    public class UserProfile
    {
        [Key]
        public int UserProfileID { get; set; }
        [Required]
        public string FirstName { get; set;}
        [Required]
        public string LastName { get; set; }
        [Required]
        [MaxLength(11)]
        public string PersonalNumber { get; set; }
      
        public DateTime? ExpireDate { get; set; }
        public User user { get; set; }
        [ForeignKey("userAddress")]
        public int AddressID { get; set; }
        public UserAddress userAddress{ get; set; }
        [ForeignKey("companys")]
        public int CompanyID { get; set; }
        public Company companys { get; set; }

    }
}
