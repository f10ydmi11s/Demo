using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace BusinessModelLayer
{
    public class OrdersSingle
    {
        [Key]
        [Required(ErrorMessage = "OrderID is required")]
        [DisplayName("OrderID")]
        public int OrderID { get; set; }
        [DisplayName("CustomerID")]
        public string CustomerID { get; set; }
        [DisplayName("EmployeeID")]
        public int? EmployeeID { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("OrderDate")]
        public System.DateTime? OrderDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("RequiredDate")]
        public System.DateTime? RequiredDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("ShippedDate")]
        public System.DateTime? ShippedDate { get; set; }
        [DisplayName("ShipVia")]
        public int? ShipVia { get; set; }
        [DisplayName("Freight")]
        public decimal? Freight { get; set; }
        [DataType(DataType.MultilineText)]
        [DisplayName("ShipName")]
        public string ShipName { get; set; }
        [DataType(DataType.MultilineText)]
        [DisplayName("ShipAddress")]
        public string ShipAddress { get; set; }
        [DisplayName("ShipCity")]
        public string ShipCity { get; set; }
        [DisplayName("ShipRegion")]
        public string ShipRegion { get; set; }
        [DisplayName("ShipPostalCode")]
        public string ShipPostalCode { get; set; }
        [DisplayName("ShipCountry")]
        public string ShipCountry { get; set; }
    }
}
