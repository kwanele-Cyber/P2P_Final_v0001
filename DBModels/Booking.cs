namespace P2P_Final_v0._001.DBModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Booking")]
    public partial class Booking
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Booking()
        {
            Insurances = new HashSet<Insurance>();
            Payments = new HashSet<Payment>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BookingID { get; set; }

        public int? RenterID { get; set; }

        public int? CarListingID { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] BookingDate { get; set; }

        public DateTime? RentalPeriodStart { get; set; }

        public DateTime? RentalPeriodEnd { get; set; }

        public decimal? TotalCost { get; set; }

        [Required]
        [StringLength(30)]
        public string PaymentStatus { get; set; }

        public virtual CarListing CarListing { get; set; }

        public virtual Renter Renter { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Insurance> Insurances { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
