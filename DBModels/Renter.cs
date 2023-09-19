namespace P2P_Final_v0._001.DBModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Renter")]
    public partial class Renter
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Renter()
        {
            Bookings = new HashSet<Booking>();
            ReviewRatings = new HashSet<ReviewRating>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RenterID { get; set; }

        public int? UserID { get; set; }

        [StringLength(20)]
        public string DriverLicenseNumber { get; set; }

        [StringLength(100)]
        public string PaymentMethod { get; set; }

        [StringLength(255)]
        public string BankAccountDetails { get; set; }

        [Required]
        [StringLength(30)]
        public string VerificationStatus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Booking> Bookings { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReviewRating> ReviewRatings { get; set; }
    }
}
