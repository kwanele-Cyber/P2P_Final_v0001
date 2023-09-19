namespace P2P_Final_v0._001.DBModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LocationGeoData")]
    public partial class LocationGeoData
    {
        [Key]
        public int LocationID { get; set; }

        public decimal? Latitude { get; set; }

        public decimal? Longitude { get; set; }

        [StringLength(100)]
        public string City { get; set; }

        [StringLength(100)]
        public string RegionState { get; set; }

        [StringLength(100)]
        public string Country { get; set; }

        public DateTime? Timestamp { get; set; }
    }
}
