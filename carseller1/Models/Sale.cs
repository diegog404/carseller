using carseller1.Models.Enums;

namespace carseller1.Models
{
    public class Sale
    {
        public int Id{ get; set; }
        public double SaleValue{ get; set; }
        public double SaleComission{ get; set; }
        public DateTime SaleDate{ get; set; }
        public SaleStatus Status{ get; set; }
        public Client Client{ get; set; }
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
