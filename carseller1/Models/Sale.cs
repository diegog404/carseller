using carseller1.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace carseller1.Models
{
    public class Sale
    {
        public int Id{ get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Sale Value")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double SaleValue{ get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Sale Comission")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double SaleComission{ get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Sale Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime SaleDate{ get; set; }

        [Required(ErrorMessage = "{0} required")]
        public SaleStatus Status{ get; set; }

        [Required(ErrorMessage = "{0} required")]
        public Client Client{ get; set; }
        [Required(ErrorMessage = "{0} required")]
        public int ClientId { get; set; }

        [Required(ErrorMessage = "{0} required")]
        public User User{ get; set; }

        [Required(ErrorMessage = "{0} required")]
        public int UserId { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();


        public Sale()
        {

        }

        public Sale(int id, double saleValue, double saleComission, DateTime saleDate, SaleStatus status, Client client)
        {
            Id = id;
            SaleValue = saleValue;
            SaleComission = saleComission;
            SaleDate = saleDate;
            Status = status;
            Client = client;
        }

        public void AddVehicle(Vehicle vehicle)
        {
            Vehicles.Add(vehicle);
        }

        public void RemoveVehicle(Vehicle vehicle)
        {
            Vehicles.Remove(vehicle);
        }
    }
}
