using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RestService.Models
{
    public partial class DemoFacility
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DemoFacility()
        {
            DemoHotels = new HashSet<DemoHotel>();
        }

        [Key]
        public int Facility_Id { get; set; }

        [Required]
        [StringLength(30)]
        public string FacilityName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DemoHotel> DemoHotels { get; set; }
    }
}
