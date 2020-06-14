using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace BusinessModelLayer
{

    public class Vworder_details
    {
        [DisplayName("Orderid")]
        public int OrderID { get; set; }
        [DisplayName("Productid")]
        public int ProductID { get; set; }
        [DisplayName("Unitprice")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public decimal UnitPrice { get; set; }
        [DisplayName("Quantity")]
        public short Quantity { get; set; }
        [DisplayName("Discount")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public float Discount { get; set; }
    }
}
