namespace P2P_Final_v0._001.DBModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ReviewRating")]
    public partial class ReviewRating
    {
        [Key]
        public int ReviewID { get; set; }

        public int? CarOwnerID { get; set; }

        public int? RenterID { get; set; }

        public int? CarListingID { get; set; }

        public int? Rating { get; set; }

        [Column(TypeName = "text")]
        public string Comment { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] Timestamp { get; set; }

        public virtual CarListing CarListing { get; set; }

        public virtual CarOwner CarOwner { get; set; }

        public virtual Renter Renter { get; set; }
    }
}
