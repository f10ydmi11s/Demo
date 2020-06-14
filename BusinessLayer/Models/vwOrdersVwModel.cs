using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace BusinessModelLayer
{

    public class Vworders
    {
        [DisplayName("Orderid")]
        public int OrderID { get; set; }
        [DisplayName("Customerid")]
        public string CustomerID { get; set; }
        [DisplayName("Employeeid")]
        public int? EmployeeID { get; set; }
        [DisplayName("Orderdate")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public System.DateTime? OrderDate { get; set; }
        [DisplayName("Requireddate")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public System.DateTime? RequiredDate { get; set; }
        [DisplayName("Shippeddate")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public System.DateTime? ShippedDate { get; set; }
        [DisplayName("Shipvia")]
        public int? ShipVia { get; set; }
        [DisplayName("Freight")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public decimal? Freight { get; set; }
        [DisplayName("Shipname")]
        public string ShipName { get; set; }
        [DisplayName("Shipaddress")]
        public string ShipAddress { get; set; }
        [DisplayName("Shipcity")]
        public string ShipCity { get; set; }
        [DisplayName("Shipregion")]
        public string ShipRegion { get; set; }
        [DisplayName("Shippostalcode")]
        public string ShipPostalCode { get; set; }
        [DisplayName("Shipcountry")]
        public string ShipCountry { get; set; }
    }
}
