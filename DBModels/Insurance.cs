namespace P2P_Final_v0._001.DBModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Insurance")]
    public partial class Insurance
    {
        public int InsuranceID { get; set; }

        public int? BookingID { get; set; }

        [Column(TypeName = "text")]
        public string CoverageDetails { get; set; }

        public decimal? Cost { get; set; }

        [Column(TypeName = "date")]
        public DateTime? StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }

        public virtual Booking Booking { get; set; }
    }
}
