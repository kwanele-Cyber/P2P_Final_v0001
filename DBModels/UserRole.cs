namespace P2P_Final_v0._001.DBModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserRole
    {
        [Key]
        public int RoleID { get; set; }

        [StringLength(50)]
        public string RoleName { get; set; }

        public int? UserID { get; set; }

        public virtual User User { get; set; }
    }
}
