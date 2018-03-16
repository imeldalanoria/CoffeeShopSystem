using System.ComponentModel.DataAnnotations;

namespace CoffeeShop.Model
{
    public class ProductModel
    {
        public int ProductID { get; set; }
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        public int Unit { get; set; }
        public int OfficeID { get; set; }
    }
}
