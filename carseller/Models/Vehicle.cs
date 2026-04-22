using carseller.Models.Enums;

namespace carseller.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public VehicleStatus Status { get; set; }
        public VehicleType Type { get; set; }
        public string LicensePlate { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }
        public Company Company { get; set; }
        public int CompanyId { get; set; }
        public Sale Sale { get; set; }

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
