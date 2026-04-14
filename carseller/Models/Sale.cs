using carseller.Models.Enums;

namespace carseller.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public double Value { get; set; }
        public double Comission { get; set; }
        public DateTime Date { get; set; }
        public SaleStatus Status { get; set; }
        public Client Client { get; set; }
        public User User { get; set; }
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
