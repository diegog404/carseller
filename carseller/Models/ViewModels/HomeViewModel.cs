namespace carseller.Models.ViewModels
{
    public class HomeViewModel
    {
        public ICollection<Sale> SalesInProgress { get; set; }

        public ICollection<Sale> BilledSales { get; set; }

        public double MonthlyComission { get; set; }

        public double ExpectedComission { get; set; }

        public double MonthlyNewClients { get; set;  }

        public double MonthlyNewCompanies { get; set; }
    }

}
