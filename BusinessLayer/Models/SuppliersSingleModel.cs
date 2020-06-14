using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace BusinessModelLayer
{
    public class SuppliersSingle
    {
        [Key]
        [Required(ErrorMessage = "SupplierID is required")]
        [DisplayName("SupplierID")]
        public int SupplierID { get; set; }
        [Required(ErrorMessage = "CompanyName is required")]
        [DataType(DataType.MultilineText)]
        [DisplayName("CompanyName")]
        public string CompanyName { get; set; }
        [DataType(DataType.MultilineText)]
        [DisplayName("ContactName")]
        public string ContactName { get; set; }
        [DataType(DataType.MultilineText)]
        [DisplayName("ContactTitle")]
        public string ContactTitle { get; set; }
        [DataType(DataType.MultilineText)]
        [DisplayName("Address")]
        public string Address { get; set; }
        [DisplayName("City")]
        public string City { get; set; }
        [DisplayName("Region")]
        public string Region { get; set; }
        [DisplayName("PostalCode")]
        public string PostalCode { get; set; }
        [DisplayName("Country")]
        public string Country { get; set; }
        [DataType(DataType.MultilineText)]
        [DisplayName("Phone")]
        public string Phone { get; set; }
        [DataType(DataType.MultilineText)]
        [DisplayName("Fax")]
        public string Fax { get; set; }
        [DisplayName("HomePage")]
        public string HomePage { get; set; }
    }
}
