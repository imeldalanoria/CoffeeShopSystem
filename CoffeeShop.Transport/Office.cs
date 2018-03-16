using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeShop.Transport
{
    public class Office
    {
        public Office()
        {
            this.ProductInfos = new List<Product>();
        }

        [Key]
        public int OfficeID { get; set; }
        public string OfficeName { get; set; }
        public string PantryName { get; set; }
        [ForeignKey("OfficeID")]
        public virtual ICollection<Product> ProductInfos { get; set; }
    }
}
