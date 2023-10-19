using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace P2P_Final_v0._001.Models.CommonModel
{
    public class DeshBoard
    {
        public string TotalBookings { get; set; }
        public string TotalRevinue { get; set; }
        public string BounceRate { get; set; }
        public string TotalCustomers { get; set; }

        public IEnumerable<Account> accounts { get; set; }
    }
}