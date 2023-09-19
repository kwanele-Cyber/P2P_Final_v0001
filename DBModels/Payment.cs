namespace P2P_Final_v0._001.DBModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Payment")]
    public partial class Payment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PaymentID { get; set; }

        public int? BookingID { get; set; }

        public decimal? Amount { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] PaymentDate { get; set; }

        [StringLength(100)]
        public string PaymentMethod { get; set; }

        [StringLength(255)]
        public string TransactionID { get; set; }

        [Required]
        [StringLength(30)]
        public string PaymentStatus { get; set; }

        public virtual Booking Booking { get; set; }
    }
}
