using System.ComponentModel.DataAnnotations;

namespace carseller.Models
{
    public class Company
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name ="Phone Number")]
        public int PhoneNumber { get; set; }

        [Required(ErrorMessage = "{0} required")]
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
