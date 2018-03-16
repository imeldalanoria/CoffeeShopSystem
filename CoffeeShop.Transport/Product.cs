using System.ComponentModel.DataAnnotations;

namespace CoffeeShop.Transport
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int Unit { get; set; }
        public int OfficeID { get; set; }
        public virtual Office OfficeInfo { get; set; }
    }
}