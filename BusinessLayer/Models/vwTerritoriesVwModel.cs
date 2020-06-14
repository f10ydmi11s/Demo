using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace BusinessModelLayer
{

    public class Vwterritories
    {
        [DisplayName("Territoryid")]
        public string TerritoryID { get; set; }
        [DisplayName("Territorydescription")]
        public string TerritoryDescription { get; set; }
        [DisplayName("Regionid")]
        public int RegionID { get; set; }
    }
}
