using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace P2P_Final_v0._001.Models
{
    public class Car
    {
        [Key]
        [DisplayName("CarID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int carID { get; set; }
        [DisplayName("Car Make")]
        public string Make { get; set; }
        [DisplayName("Car Model")]
        public string Model { get; set; }
        [DisplayName("Varient")]
        public string Varient { get; set; }
        [DisplayName("Car Year")]
        public int Year { get; set; }
        [DisplayName("Body Type")]
        public string BodyType { get; set; }
        [DisplayName("Mileage")]
        public string Mileage { get; set; }
        [DisplayName("Car Color")]
        public string Color { get; set; }
        [DisplayName("Fuel Type")]
        public string FuelType { get; set; }
        [DisplayName("car Number Plate")]
        public string NumberPlate { get; set; }
        [DisplayName("Transmission Type")]
        public string Transmission { get; set; }
        [DisplayName("Vehicle Description")]
        public string Description { get; set; }
        [DisplayName("Location (City)")]
        public string Location { get; set; }
        [DisplayName("Full Address")]
        public string Address { get; set; }
        [DisplayName("Price")]
        public int Price { get; set; }
    }
}