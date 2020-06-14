using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace BusinessModelLayer
{

    public class Vwshippers
    {
        [DisplayName("Shipperid")]
        public int ShipperID { get; set; }
        [DisplayName("Companyname")]
        public string CompanyName { get; set; }
        [DisplayName("Phone")]
        public string Phone { get; set; }
    }
}
