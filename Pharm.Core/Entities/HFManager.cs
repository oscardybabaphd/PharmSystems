using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharm.Core.Entities
{
    public class HFManager
    {
        public HFManager()
        {

        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [StringLength(100, MinimumLength = 5)]
        [Required]
        public string ManagerFullName { get; set; }

        [StringLength(200, MinimumLength = 10)]
        [Required]
        public string ManagerHomeAddress { get; set; }
        public Region Region { get; set; }
        [Required]
        public int ActiveStaff { get; set; }
        public bool IsActive { get; set; }
        [Required]
        public int HFID { get; set; }
        [ForeignKey("HFID")]
        public virtual HealthFacility HealthFacility { get; set; }
    }
    public enum Region
    {
        NorthCentral = 1,
        NorthEast = 2,
        NorthWest = 3,
        SouthEast = 4,
        SouthSouth = 5,
        SouthWest = 6
    }
}
