using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharm.Core.Entities
{
    public class State
    {
        public State()
        {

        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [StringLength(50, MinimumLength = 2)]
        [Required]
        public string Name { get; set; }
        [StringLength(10, MinimumLength = 3)]
        [Required]
        public string Code { get; set; }
    }
}
