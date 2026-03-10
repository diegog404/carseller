namespace carseller1.Models.ViewModels
{
    public class SaleFormViewModel
    {
        public Sale Sale{ get; set; }
        public ICollection<Client> Clients{ get; set; }
        public ICollection<User> Users{ get; set; }
    }
}
