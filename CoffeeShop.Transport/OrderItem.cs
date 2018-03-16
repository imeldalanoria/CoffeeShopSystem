using System;
using System.ComponentModel.DataAnnotations;

namespace CoffeeShop.Transport
{
    public class OrderItem
    {
        [Key]
        public int ID { get; set; }
        public string OrderName { get; set; }
        public string ClientName { get; set; }
        public int OfficeID { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
