using System;
using System.ComponentModel.DataAnnotations;

namespace CoffeeShop.Model
{
    public class OrderItemModel
    {
        public int ID { get; set; }
        [Display(Name = "Order Name")]
        public string OrderName { get; set; }
        [Display(Name = "Client Name")]
        public string ClientName { get; set; }
        public int OfficeID { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime AddedDate { get; set; }
    }
}
