namespace P2P_Final_v0._001.DBModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CarListing")]
    public partial class CarListing
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CarListing()
        {
            Bookings = new HashSet<Booking>();
            ReviewRatings = new HashSet<ReviewRating>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CarListingID { get; set; }

        public int? CarOwnerID { get; set; }

        [StringLength(50)]
        public string Make { get; set; }

        [StringLength(50)]
        public string Model { get; set; }

        public int? Year { get; set; }

        public int? Mileage { get; set; }

        public decimal? RentalPrice { get; set; }

        [StringLength(255)]
        public string AvailabilitySchedule { get; set; }

        public decimal? LocationLatitude { get; set; }

        public decimal? LocationLongitude { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }

        [StringLength(100)]
        public string CarImage { get; set; }

        [Required]
        [StringLength(30)]
        public string Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Booking> Bookings { get; set; }

        public virtual CarOwner CarOwner { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReviewRating> ReviewRatings { get; set; }
    }
}
