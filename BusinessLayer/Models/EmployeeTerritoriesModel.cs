using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace BusinessModelLayer
{
    public class Employeeterritories : EmployeeterritoriesBusinessModelLayers
    {

        public class EmployeeterritoriesMasterDetailModel
        {
            // MASTER TABLE
            public BusinessModelLayer.EmployeeterritoriesSingle Employeeterritories { get; set; }
            // LIST TABLE		
            public BusinessModelLayer.Vwemployeeterritories VwEmployeeterritories { get; set; }
            // DETAILS TABLES

        }
    }
}
