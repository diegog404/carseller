using carseller.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace carseller.Models
{
    public class Vehicle
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} required")]
        public VehicleStatus Status { get; set; }

        [Required(ErrorMessage = "{0} required")]
        public VehicleType Type { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name ="License Plate")]
        public string LicensePlate { get; set; }

        [Required(ErrorMessage = "{0} required")]
        public string Model { get; set; }

        [Required(ErrorMessage = "{0} required")]
        public int Year { get; set; }

        [Required(ErrorMessage = "{0} required")]
        public double Price { get; set; }

        public Company? Company { get; set; }
        public int CompanyId { get; set; }
        public Sale? Sale { get; set; }

        public Vehicle()
        {

        }

        public Vehicle(int id, VehicleStatus status, VehicleType type, string licensePlate, string model, int year, double price, Sale sale, Company company)
        {
            Id = id;
            Status = status;
            Type = type;
            LicensePlate = licensePlate;
            Model = model;
            Year = year;
            Price = price;
            Sale = sale;
            Company = company;
        }
    }
}
