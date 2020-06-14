using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace BusinessModelLayer
{
    public class ProductsSingle
    {
        [Key]
        [Required(ErrorMessage = "ProductID is required")]
        [DisplayName("ProductID")]
        public int ProductID { get; set; }
        [Required(ErrorMessage = "ProductName is required")]
        [DataType(DataType.MultilineText)]
        [DisplayName("ProductName")]
        public string ProductName { get; set; }
        [DisplayName("SupplierID")]
        public int? SupplierID { get; set; }
        [DisplayName("CategoryID")]
        public int? CategoryID { get; set; }
        [DisplayName("QuantityPerUnit")]
        public string QuantityPerUnit { get; set; }
        [DisplayName("UnitPrice")]
        public decimal? UnitPrice { get; set; }
        [DisplayName("UnitsInStock")]
        public short? UnitsInStock { get; set; }
        [DisplayName("UnitsOnOrder")]
        public short? UnitsOnOrder { get; set; }
        [DisplayName("ReorderLevel")]
        public short? ReorderLevel { get; set; }
        [Required(ErrorMessage = "Discontinued is required")]
        [DisplayName("Discontinued")]
        public bool Discontinued { get; set; }
    }
}
