using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace BusinessModelLayer
{
    public class Region : RegionBusinessModelLayers
    {

        public class RegionMasterDetailModel
        {
            // MASTER TABLE
            public BusinessModelLayer.RegionSingle Region { get; set; }
            // LIST TABLE		
            public BusinessModelLayer.Vwregion VwRegion { get; set; }
            // DETAILS TABLES
            public BusinessModelLayer.Territories Territories { get; set; }
            public IEnumerable<BusinessModelLayer.TerritoriesSingle> TerritoriesDetl { get; set; }
            public IEnumerable<BusinessModelLayer.Vwterritories> TerritoriesVwDetl { get; set; }

        }
    }
}
