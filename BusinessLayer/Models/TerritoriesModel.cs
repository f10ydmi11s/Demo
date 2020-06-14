using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace BusinessModelLayer
{
    public class Territories : TerritoriesBusinessModelLayers
    {

        public class TerritoriesMasterDetailModel
        {
            // MASTER TABLE
            public BusinessModelLayer.TerritoriesSingle Territories { get; set; }
            // LIST TABLE		
            public BusinessModelLayer.Vwterritories VwTerritories { get; set; }
            // DETAILS TABLES
            public BusinessModelLayer.Employeeterritories Employeeterritories { get; set; }
            public IEnumerable<BusinessModelLayer.EmployeeterritoriesSingle> EmployeeterritoriesDetl { get; set; }
            public IEnumerable<BusinessModelLayer.Vwemployeeterritories> EmployeeterritoriesVwDetl { get; set; }

        }
    }
}
