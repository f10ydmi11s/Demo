using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace BusinessModelLayer
{
    public class RegionSingle
    {
        [Key]
        [Required(ErrorMessage = "RegionID is required")]
        [DisplayName("RegionID")]
        public int RegionID { get; set; }
        [Required(ErrorMessage = "RegionDescription is required")]
        [DataType(DataType.MultilineText)]
        [DisplayName("RegionDescription")]
        public string RegionDescription { get; set; }
    }
}
