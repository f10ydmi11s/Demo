using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace BusinessModelLayer
{
    public class CustomerdemographicsSingle
    {
        [Key]
        [Required(ErrorMessage = "CustomerTypeID is required")]
        [DisplayName("CustomerTypeID")]
        public string CustomerTypeID { get; set; }
        [DisplayName("CustomerDesc")]
        public string CustomerDesc { get; set; }
    }
}
