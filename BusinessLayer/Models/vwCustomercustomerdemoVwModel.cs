using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace BusinessModelLayer
{

    public class Vwcustomercustomerdemo
    {
        [DisplayName("Customerid")]
        public string CustomerID { get; set; }
        [DisplayName("Customertypeid")]
        public string CustomerTypeID { get; set; }
    }
}
