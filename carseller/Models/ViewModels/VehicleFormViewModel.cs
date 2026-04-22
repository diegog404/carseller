namespace carseller.Models.ViewModels
{
    public class VehicleFormViewModel
    {
        public Vehicle Vehicle { get; set; }
        public ICollection<Company> Companies { get; set; }
    }
}
