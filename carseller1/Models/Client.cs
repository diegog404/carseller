namespace carseller1.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public string State { get; set; }
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
