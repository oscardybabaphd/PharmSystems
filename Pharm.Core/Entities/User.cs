using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharm.Core.Entities
{
    public class User
    {
        [Key]
        public int ID { get; set; }

        [StringLength(100)]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [StringLength(100)]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [StringLength(100, MinimumLength = 10)]
        public string AuthorizationCode { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
