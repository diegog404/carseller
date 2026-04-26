using System.ComponentModel.DataAnnotations;

namespace carseller.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [EmailAddress(ErrorMessage ="Insira um email válido.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string PasswordHash { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name ="Creation Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreationDate { get; set; }
        public ICollection<Sale> Sales { get; set; } = new List<Sale>();

        public User()
        {

        }

        public User(int id, string name, string email, string passwordHash, DateTime creationDate)
        {
            Id = id;
            Name = name;
            Email = email;
            PasswordHash = passwordHash;
            CreationDate = creationDate;
        }

        public void AddSales(Sale sa)
        {
            Sales.Add(sa);
        }

        public void RemoveSales(Sale sa)
        {
            Sales.Remove(sa);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(sa => sa.Date >= initial && sa.Date <= final).Sum(sa => sa.Value);
        }
    }
}
