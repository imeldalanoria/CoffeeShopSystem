using System.ComponentModel.DataAnnotations;

namespace CoffeeShop.Model
{
    public class OfficeModel
    {
        public int OfficeID { get; set; }
        [Display(Name = "Office Name")]
        public string OfficeName { get; set; }
        [Display(Name = "Pantry Name")]
        public string PantryName { get; set; }
        public bool HasProduct { get; set; }
    }
}
