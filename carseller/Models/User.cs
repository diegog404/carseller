namespace carseller.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
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
