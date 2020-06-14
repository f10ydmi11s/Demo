using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace BusinessModelLayer
{
    public class CustomercustomerdemoSingle
    {
        [Key]
        [Required(ErrorMessage = "CustomerID is required")]
        [DisplayName("CustomerID")]
        public string CustomerID { get; set; }
        [Key]
        [Required(ErrorMessage = "CustomerTypeID is required")]
        [DisplayName("CustomerTypeID")]
        public string CustomerTypeID { get; set; }
    }
}
