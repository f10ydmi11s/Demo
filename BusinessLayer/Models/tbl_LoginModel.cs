using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace BusinessModelLayer
{
    public class Tbl_Login : Tbl_LoginBusinessModelLayers
    {

        public class Tbl_LoginMasterDetailModel
        {
            // MASTER TABLE
            public BusinessModelLayer.Tbl_LoginSingle Tbl_Login { get; set; }
            // LIST TABLE		
            public BusinessModelLayer.Vwtbl_login VwTbl_Login { get; set; }
            // DETAILS TABLES

        }
    }
}
