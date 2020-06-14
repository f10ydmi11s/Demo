using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace BusinessModelLayer
{

    public class Vwsuppliers
    {
        [DisplayName("Supplierid")]
        public int SupplierID { get; set; }
        [DisplayName("Companyname")]
        public string CompanyName { get; set; }
        [DisplayName("Contactname")]
        public string ContactName { get; set; }
        [DisplayName("Contacttitle")]
        public string ContactTitle { get; set; }
        [DisplayName("Address")]
        public string Address { get; set; }
        [DisplayName("City")]
        public string City { get; set; }
        [DisplayName("Region")]
        public string Region { get; set; }
        [DisplayName("Postalcode")]
        public string PostalCode { get; set; }
        [DisplayName("Country")]
        public string Country { get; set; }
        [DisplayName("Phone")]
        public string Phone { get; set; }
        [DisplayName("Fax")]
        public string Fax { get; set; }
        [DisplayName("Homepage")]
        public string HomePage { get; set; }
    }
}
