
namespace Gazprom.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("Employee")]
    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            Business_trip = new HashSet<Business_trip>();
        }

        [Key]
        [StringLength(10)]
        public string Login { get; set; }

        [Required]
        [StringLength(30)]
        public string Lastname { get; set; }

        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }

        [StringLength(30)]
        public string Patronymic { get; set; }

        [Required]
        [StringLength(30)]
        public string Position { get; set; }

        [StringLength(30)]
        public string Password { get; set; }

        public int ID_subdivision { get; set; }

        public int ID_access { get; set; }

        public int? ID_branch { get; set; }

        public virtual Branch Branch { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Business_trip> Business_trip { get; set; }

        public virtual Code_access Code_access { get; set; }

        public virtual Subdivision Subdivision { get; set; }
    }
}