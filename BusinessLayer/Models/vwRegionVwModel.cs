using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace BusinessModelLayer
{

    public class Vwregion
    {
        [DisplayName("Regionid")]
        public int RegionID { get; set; }
        [DisplayName("Regiondescription")]
        public string RegionDescription { get; set; }
    }
}
