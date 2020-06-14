using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace BusinessModelLayer
{
    public class TerritoriesSingle
    {
        [Key]
        [Required(ErrorMessage = "TerritoryID is required")]
        [DisplayName("TerritoryID")]
        public string TerritoryID { get; set; }
        [Required(ErrorMessage = "TerritoryDescription is required")]
        [DataType(DataType.MultilineText)]
        [DisplayName("TerritoryDescription")]
        public string TerritoryDescription { get; set; }
        [Required(ErrorMessage = "RegionID is required")]
        [DisplayName("RegionID")]
        public int RegionID { get; set; }
    }
}
