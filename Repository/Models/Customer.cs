namespace Repository.Models
{
    public class Customer
    {
        public string Name { get; set; }

        public decimal TotalLoan { get; set; }

        public decimal Interest { get; set; }

        public int Years { get; set; }
    }
}