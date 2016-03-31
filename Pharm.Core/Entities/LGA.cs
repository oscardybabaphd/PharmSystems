using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharm.Core.Entities
{
    public class LGA
    {
        public LGA()
        {
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [StringLength(100)]
        [Required]
        public string Name { get; set; }
        [StringLength(10)]
        [Required]
        public string Code { get; set; }
        [Required]
        public int StateID { get; set; }
        [ForeignKey("StateID")]
        public virtual State State { get; set; }
    }
}
