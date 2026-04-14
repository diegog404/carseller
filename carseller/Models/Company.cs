namespace carseller.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public string Address { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();

        public Company()
        {

        }

        public Company(int id, string name, int phoneNumber, string address)
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
            Address = address;
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
