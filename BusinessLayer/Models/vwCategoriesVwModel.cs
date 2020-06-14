using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace BusinessModelLayer
{

    public class Vwcategories
    {
        [DisplayName("Categoryid")]
        public int CategoryID { get; set; }
        [DisplayName("Categoryname")]
        public string CategoryName { get; set; }
        [DisplayName("Description")]
        public string Description { get; set; }
        [DisplayName("Picture")]
        public byte[] Picture { get; set; }
    }
}
