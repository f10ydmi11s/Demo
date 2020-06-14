using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace BusinessModelLayer
{

    public class Vwcustomerdemographics
    {
        [DisplayName("Customertypeid")]
        public string CustomerTypeID { get; set; }
        [DisplayName("Customerdesc")]
        public string CustomerDesc { get; set; }
    }
}
