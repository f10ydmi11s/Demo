using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace BusinessModelLayer
{
    public class ShippersSingle
    {
        [Key]
        [Required(ErrorMessage = "ShipperID is required")]
        [DisplayName("ShipperID")]
        public int ShipperID { get; set; }
        [Required(ErrorMessage = "CompanyName is required")]
        [DataType(DataType.MultilineText)]
        [DisplayName("CompanyName")]
        public string CompanyName { get; set; }
        [DataType(DataType.MultilineText)]
        [DisplayName("Phone")]
        public string Phone { get; set; }
    }
}
