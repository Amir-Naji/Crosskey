using System.ComponentModel.DataAnnotations;

namespace Repository.Models
{
    public class Customer
    {
        public string Name { get; set; }

        [Range(0, double.MaxValue,
            ErrorMessage = "Please enter valid doubleNumber")]

        public double TotalLoan { get; set; }

        public double Interest { get; set; }

        public int Years { get; set; }
    }
}