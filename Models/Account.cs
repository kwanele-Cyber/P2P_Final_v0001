using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;

namespace P2P_Final_v0._001.Models
{
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("AccountID")]
        public int AccountID { get; set; }
        [DisplayName("Name")]
        public string Name { get; set; }
        [DisplayName("Surname")]
        public string Surname { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }
        [DisplayName("CellPhone")]
        public string CellphoneNumber { get; set; }
        [DisplayName("UserName")]
        public string Username { get; set; }
        [DisplayName("Password")]
        public string Password { get; set; }
        [BindProperty, DataType(DataType.Date)]
        [DisplayName("DateOfBirth")]
        public DateTime DateOfBirth { get; set; }
        [DisplayName("AccountType")]
        public Account_Type AccountType { get; set; }
        [DisplayName("Profile Picture")]
        public string ProfilePic { get; set; } //image url


        public enum Account_Type
        {
            Renter,
            Owner,
            Admin
        }

        public int GetCarListing()
        {
            int a = 0;
            //will do something here very soon...
            return a;
        }

        public int GetCarsRented()
        {
            int a = 0;
            //will do something here very soon...
            return a;
        }
        
    }
}