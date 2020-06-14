using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace BusinessModelLayer
{
    public class Order_DetailsSingle
    {
        [Key]
        [Required(ErrorMessage = "OrderID is required")]
        [DisplayName("OrderID")]
        public int OrderID { get; set; }
        [Key]
        [Required(ErrorMessage = "ProductID is required")]
        [DisplayName("ProductID")]
        public int ProductID { get; set; }
        [Required(ErrorMessage = "UnitPrice is required")]
        [DisplayName("UnitPrice")]
        public decimal UnitPrice { get; set; }
        [Required(ErrorMessage = "Quantity is required")]
        [DisplayName("Quantity")]
        public short Quantity { get; set; }
        [Required(ErrorMessage = "Discount is required")]
        [DisplayName("Discount")]
        public float Discount { get; set; }
    }
}
