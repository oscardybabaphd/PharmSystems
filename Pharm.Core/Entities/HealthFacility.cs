using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharm.Core.Entities
{
    public class HealthFacility
    {
        public HealthFacility()
        {

        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [StringLength(100)]
        [Required]
        public string Name { get; set; }
        [StringLength(10, MinimumLength = 3)]
        [Required]
        public string Code { get; set; }
        public FacilityType FacilityType { get; set; }
        public OwnerShip OwnerShip { get; set; }
        [Required]
        public int WardID { get; set; }
        [ForeignKey("WardID")]
        public virtual  Ward Ward { get; set; }
    }
    public enum FacilityType
    {
        Primary = 1,
        Secondary = 2
    }

    public enum OwnerShip
    {
        Private = 1,
        Public = 2
    }
}
