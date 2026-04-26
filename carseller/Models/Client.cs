using System.ComponentModel.DataAnnotations;

namespace carseller.Models
{
    public class Client
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Phone Number")]
        public int PhoneNumber { get; set; }

        [Required(ErrorMessage = "{0} required")]
        public string State { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name ="Observation")]
        public string Obervation { get; set; }
        public ICollection<Sale> Sales { get; set; } = new List<Sale>();

        public Client()
        {

        }

        public Client(int id, string name, int phoneNumber, string state, string obervation)
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
            State = state;
            Obervation = obervation;
        }

        public void AddSales(Sale sa)
        {
            Sales.Add(sa);
        }

        public void RemoveSales(Sale sa)
        {
            Sales.Remove(sa);
        }
    }
}
