using carseller.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace carseller.Models
{
    public class Sale
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [DisplayFormat(DataFormatString ="{0:F2}")]
        public double Value { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double Comission { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "{0} required")]
        public SaleStatus Status { get; set; }
        public Client? Client { get; set; }
        public int ClientId { get; set; }
        public User? User { get; set; }
        public int UserId { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();

        public Sale()
        {

        }

        public Sale(int id, double value, double comission, DateTime date, SaleStatus status, Client client, User user)
        {
            Id = id;
            Value = value;
            Comission = comission;
            Date = date;
            Status = status;
            Client = client;
            User = user;
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
