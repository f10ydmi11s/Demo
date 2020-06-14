using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace BusinessModelLayer
{
    public class Tbl_Exceptionloggingtodatabase : Tbl_ExceptionloggingtodatabaseBusinessModelLayers
    {

        public class Tbl_ExceptionloggingtodatabaseMasterDetailModel
        {
            // MASTER TABLE
            public BusinessModelLayer.Tbl_ExceptionloggingtodatabaseSingle Tbl_Exceptionloggingtodatabase { get; set; }
            // LIST TABLE		
            public BusinessModelLayer.Vwtbl_exceptionloggingtodatabase VwTbl_Exceptionloggingtodatabase { get; set; }
            // DETAILS TABLES

        }
    }
}
