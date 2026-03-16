using carseller1.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace carseller1.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string PasswordHash { get; set; }

        [Display(Name = "Creation Date")]
        [DataType(DataType.Date)]
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
            return Sales.Where(sa => sa.SaleDate >= initial && sa.SaleDate <= final).Sum(sa => sa.SaleValue);
        }
    }
}
