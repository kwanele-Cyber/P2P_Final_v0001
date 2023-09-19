using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace P2P_Final_v0._001.DBModels
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<CarListing> CarListings { get; set; }
        public virtual DbSet<CarOwner> CarOwners { get; set; }
        public virtual DbSet<Insurance> Insurances { get; set; }
        public virtual DbSet<LocationGeoData> LocationGeoDatas { get; set; }
        public virtual DbSet<LogsAuditTrail> LogsAuditTrails { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Renter> Renters { get; set; }
        public virtual DbSet<ReviewRating> ReviewRatings { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>()
                .Property(e => e.BookingDate)
                .IsFixedLength();

            modelBuilder.Entity<Booking>()
                .Property(e => e.TotalCost)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Booking>()
                .Property(e => e.PaymentStatus)
                .IsUnicode(false);

            modelBuilder.Entity<CarListing>()
                .Property(e => e.Make)
                .IsUnicode(false);

            modelBuilder.Entity<CarListing>()
                .Property(e => e.Model)
                .IsUnicode(false);

            modelBuilder.Entity<CarListing>()
                .Property(e => e.RentalPrice)
                .HasPrecision(10, 2);

            modelBuilder.Entity<CarListing>()
                .Property(e => e.AvailabilitySchedule)
                .IsUnicode(false);

            modelBuilder.Entity<CarListing>()
                .Property(e => e.LocationLatitude)
                .HasPrecision(10, 8);

            modelBuilder.Entity<CarListing>()
                .Property(e => e.LocationLongitude)
                .HasPrecision(11, 8);

            modelBuilder.Entity<CarListing>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<CarListing>()
                .Property(e => e.CarImage)
                .IsUnicode(false);

            modelBuilder.Entity<CarListing>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<CarOwner>()
                .Property(e => e.DriverLicenseNumber)
                .IsUnicode(false);

            modelBuilder.Entity<CarOwner>()
                .Property(e => e.PaymentMethod)
                .IsUnicode(false);

            modelBuilder.Entity<CarOwner>()
                .Property(e => e.BankAccountDetails)
                .IsUnicode(false);

            modelBuilder.Entity<CarOwner>()
                .Property(e => e.VerificationStatus)
                .IsUnicode(false);

            modelBuilder.Entity<Insurance>()
                .Property(e => e.CoverageDetails)
                .IsUnicode(false);

            modelBuilder.Entity<Insurance>()
                .Property(e => e.Cost)
                .HasPrecision(10, 2);

            modelBuilder.Entity<LocationGeoData>()
                .Property(e => e.Latitude)
                .HasPrecision(10, 8);

            modelBuilder.Entity<LocationGeoData>()
                .Property(e => e.Longitude)
                .HasPrecision(11, 8);

            modelBuilder.Entity<LocationGeoData>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<LocationGeoData>()
                .Property(e => e.RegionState)
                .IsUnicode(false);

            modelBuilder.Entity<LocationGeoData>()
                .Property(e => e.Country)
                .IsUnicode(false);

            modelBuilder.Entity<LogsAuditTrail>()
                .Property(e => e.Action)
                .IsUnicode(false);

            modelBuilder.Entity<Payment>()
                .Property(e => e.Amount)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Payment>()
                .Property(e => e.PaymentDate)
                .IsFixedLength();

            modelBuilder.Entity<Payment>()
                .Property(e => e.PaymentMethod)
                .IsUnicode(false);

            modelBuilder.Entity<Payment>()
                .Property(e => e.TransactionID)
                .IsUnicode(false);

            modelBuilder.Entity<Payment>()
                .Property(e => e.PaymentStatus)
                .IsUnicode(false);

            modelBuilder.Entity<Renter>()
                .Property(e => e.DriverLicenseNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Renter>()
                .Property(e => e.PaymentMethod)
                .IsUnicode(false);

            modelBuilder.Entity<Renter>()
                .Property(e => e.BankAccountDetails)
                .IsUnicode(false);

            modelBuilder.Entity<Renter>()
                .Property(e => e.VerificationStatus)
                .IsUnicode(false);

            modelBuilder.Entity<ReviewRating>()
                .Property(e => e.Comment)
                .IsUnicode(false);

            modelBuilder.Entity<ReviewRating>()
                .Property(e => e.Timestamp)
                .IsFixedLength();

            modelBuilder.Entity<UserRole>()
                .Property(e => e.RoleName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.ResetPasswordCode)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Province)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Gender)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.BankStat)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Licence)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.ProofOfAd)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.ProfilePicture)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserType)
                .IsUnicode(false);
        }
    }
}
