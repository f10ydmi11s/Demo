using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace BusinessModelLayer
{

    public class Vwproducts
    {
        [DisplayName("Productid")]
        public int ProductID { get; set; }
        [DisplayName("Productname")]
        public string ProductName { get; set; }
        [DisplayName("Supplierid")]
        public int? SupplierID { get; set; }
        [DisplayName("Categoryid")]
        public int? CategoryID { get; set; }
        [DisplayName("Quantityperunit")]
        public string QuantityPerUnit { get; set; }
        [DisplayName("Unitprice")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public decimal? UnitPrice { get; set; }
        [DisplayName("Unitsinstock")]
        public short? UnitsInStock { get; set; }
        [DisplayName("Unitsonorder")]
        public short? UnitsOnOrder { get; set; }
        [DisplayName("Reorderlevel")]
        public short? ReorderLevel { get; set; }
        [DisplayName("Discontinued")]
        public bool Discontinued { get; set; }
    }
}
