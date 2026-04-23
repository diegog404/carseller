using carseller.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace carseller.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public VehicleStatus Status { get; set; }
        public VehicleType Type { get; set; }

        [Display(Name ="License Plate")]
        public string LicensePlate { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double Price { get; set; }
        public Company Company { get; set; }
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
