namespace Gazprom.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    public partial class Business_trip
    {
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

        [Required]
        [StringLength(30)]
        
        public string Purpose { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime StartBT { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime EndBT { get; set; }

        public int OvernightStay { get; set; }

        public int CostLiving { get; set; }

        public int Fare { get; set; }

        public int DifferencesDays { get; set; }

        public int SummCost { get; set; }

        public int SummLiving { get; set; }

        public int TotalSumm { get; set; }

        [Required]
        [StringLength(10)]
        public string Login { get; set; }

        public int Cost { get; set; }

        public int ID_CP { get; set; }

        public int ID_status { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Status Status { get; set; }

        public virtual Counterparty Counterparty { get; set; }

        public virtual Tariff_daily Tariff_daily { get; set; }

        
    }
}
