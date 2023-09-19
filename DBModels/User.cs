namespace P2P_Final_v0._001.DBModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            CarOwners = new HashSet<CarOwner>();
            LogsAuditTrails = new HashSet<LogsAuditTrail>();
            Renters = new HashSet<Renter>();
            UserRoles = new HashSet<UserRole>();
        }

        public int UserID { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        [StringLength(100)]
        public string ResetPasswordCode { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(15)]
        public string PhoneNumber { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string Code { get; set; }

        [StringLength(50)]
        public string Province { get; set; }

        [StringLength(50)]
        public string Gender { get; set; }

        public Guid? ActivationCode { get; set; }

        public bool? IsEmailVerified { get; set; }

        public string ID { get; set; }

        public string BankStat { get; set; }

        public string Licence { get; set; }

        public string ProofOfAd { get; set; }

        public string ProfilePicture { get; set; }

        public DateTime? RegistrationDate { get; set; }

        [StringLength(30)]
        public string UserType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarOwner> CarOwners { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LogsAuditTrail> LogsAuditTrails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Renter> Renters { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
