using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Gazprom.Models
{
    public class EmployeeBT
    {
        [Key]
        [StringLength(10)]
        public string Login { get; set; }

        public int ID_subdivision { get; set; }
        public string NameSubdivision { get; set; }
        public int ID_access { get; set; }
        public int? ID_branch{ get; set; }


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

        [Key]
        public Guid ID_businesstrip { get; set; }

        [Required]
        [StringLength(30)]
        public string Region { get; set; }

        [Required]
        [StringLength(30)]
        public string District { get; set; }

        [Required]
        [StringLength(30)]
        public string Locality { get; set; }

        public int ID_CP { get; set; }

        [Required]
        [StringLength(30)]
        public string Counterparty { get; set; }

        [Required]
        [StringLength(30)]
        public string Purpose { get; set; }

        [Column(TypeName = "date")]
        public DateTime StartBT { get; set; }

        [Column(TypeName = "date")]
        public DateTime EndBT { get; set; }

        public int Howlong { get; set; }

        public int Cost { get; set; }

        public int SummDay { get; set; }

        public int OvernightStay { get; set; }

        public int CostLiving { get; set; }

        public int Summhome{ get; set; }

        public int Fare { get; set; }

        public int All { get; set; }

    }
}