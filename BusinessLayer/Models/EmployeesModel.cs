using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace BusinessModelLayer
{
    public class Employees : EmployeesBusinessModelLayers
    {

        public class EmployeesMasterDetailModel
        {
            // MASTER TABLE
            public BusinessModelLayer.EmployeesSingle Employees { get; set; }
            // LIST TABLE		
            public BusinessModelLayer.Vwemployees VwEmployees { get; set; }
            // DETAILS TABLES
            public BusinessModelLayer.Employeeterritories Employeeterritories { get; set; }
            public IEnumerable<BusinessModelLayer.EmployeeterritoriesSingle> EmployeeterritoriesDetl { get; set; }
            public IEnumerable<BusinessModelLayer.Vwemployeeterritories> EmployeeterritoriesVwDetl { get; set; }

        }
    }
}
