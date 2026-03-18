using carseller1.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace carseller1.Models
{
    public class Vehicle
    {
        public int Id{ get; set; }
        [Required(ErrorMessage = "{0} required")]
        public VehicleStatus Status{ get; set; }

        [Required(ErrorMessage = "{0} required")]
        public VehicleType Type{ get; set; }

        [Required(ErrorMessage = "{0} required")]
        public string LicensePlate{ get; set; }

        [Required(ErrorMessage = "{0} required")]
        public string Model{ get; set; }

        [Required(ErrorMessage = "{0} required")]
        public int Year{ get; set; }

        [Required(ErrorMessage = "{0} required")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double Price{ get; set; }

        [Required(ErrorMessage = "{0} required")]
        public Company Company{ get; set; }

        [Required(ErrorMessage = "{0} required")]
        public int CompanyId{ get; set; }
        public Sale Sale{ get; set; }
        public int? SaleId{ get; set; }

        public Vehicle()
        {

        }

        public Vehicle(int id, VehicleStatus status, VehicleType type, string licensePlate, string model, int year, double price, Sale sale)
        {
            Id = id;
            Status = status;
            Type = type;
            LicensePlate = licensePlate;
            Model = model;
            Year = year;
            Price = price;
            Sale = sale;
        }
    }
}
