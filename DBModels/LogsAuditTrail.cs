namespace P2P_Final_v0._001.DBModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LogsAuditTrail
    {
        [Key]
        public int LogID { get; set; }

        public int? UserID { get; set; }

        [Column(TypeName = "text")]
        public string Action { get; set; }

        public DateTime? Timestamp { get; set; }

        public virtual User User { get; set; }
    }
}
