
--USE [Northwind]

DROP PROCEDURE [dbo].[spGetAllCategories];
	GO
CREATE PROCEDURE [dbo].[spGetAllCategories]
AS
    BEGIN
        SELECT Categoryid, 
               Categoryname, 
               Description, 
               Picture
        FROM [Categories];
    END;
	GO
DROP PROCEDURE [dbo].[spAddCategories];
	GO
CREATE PROCEDURE [dbo].[spAddCategories]
(@Categoryid   INT          = 0, 
 @Categoryname NVARCHAR(15) = '', 
 @Description  NTEXT        = '', 
 @Picture      IMAGE        = 0x424d42000000000000003e0000002800000001000000010000000100010000000000040000000000000000000000000000000000000000000000ffffff00800000000000000000000000000000000000000000000000000000000
)
AS
    BEGIN
        BEGIN TRANSACTION;
        BEGIN TRY
            INSERT INTO [Categories]
            (
            --[Categoryid]
            [Categoryname], 
            [Description], 
            [Picture]
            )
            VALUES
            (
            --@Categoryid
            @Categoryname, 
            @Description, 
            @Picture
            );
        END TRY
        BEGIN CATCH
            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION;
            DECLARE @ErrorNO VARCHAR(50);
            DECLARE @ErrorSE VARCHAR(10);
            DECLARE @ErrorST VARCHAR(10);
            DECLARE @ErrorMG VARCHAR(MAX);
            SET @ErrorNO = 'Error Number: ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '; ' + 'Error Line: ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '; ';
            SET @ErrorSE = CAST(ERROR_SEVERITY() AS VARCHAR(10)) + '; ';
            SET @ErrorST = CAST(ERROR_STATE() AS VARCHAR(10)) + '; ';
            SET @ErrorMG = ERROR_MESSAGE();
            EXEC [dbo].[spAddTbl_Exceptionloggingtodatabase] 
                 0, 
                 @ErrorMG, 
                 @ErrorSE, 
                 @ErrorST, 
                 @ErrorNO, 
                 NULL;
        END CATCH;
        IF @@TRANCOUNT > 0
            COMMIT TRANSACTION;
    END;
	GO
DROP PROCEDURE [dbo].[spUpdateCategories];
	GO
CREATE PROCEDURE [dbo].[spUpdateCategories]
(@Categoryid   INT          = 0, 
 @Categoryname NVARCHAR(15) = '', 
 @Description  NTEXT        = NULL, 
 @Picture      IMAGE        = NULL
)
AS
    BEGIN
        BEGIN TRANSACTION;
        BEGIN TRY
            UPDATE [Categories]
              SET 
                  Categoryname = @Categoryname, 
                  Description = @Description, 
                  Picture = @Picture
            WHERE Categoryid = @Categoryid;
        END TRY
        BEGIN CATCH
            --SELECT ERROR_NUMBER() AS ErrorNumber, 
            --       ERROR_SEVERITY() AS ErrorSeverity, 
            --       ERROR_STATE() AS ErrorState, 
            --       ERROR_PROCEDURE() AS ErrorProcedure, 
            --       ERROR_LINE() AS ErrorLine, 
            --       ERROR_MESSAGE() AS ErrorMessage;

            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION;
            DECLARE @ErrorNO VARCHAR(50);
            DECLARE @ErrorSE VARCHAR(10);
            DECLARE @ErrorST VARCHAR(10);
            DECLARE @ErrorMG VARCHAR(MAX);
            SET @ErrorNO = 'Error Number: ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '; ' + 'Error Line: ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '; ';
            SET @ErrorSE = CAST(ERROR_SEVERITY() AS VARCHAR(10)) + '; ';
            SET @ErrorST = CAST(ERROR_STATE() AS VARCHAR(10)) + '; ';
            SET @ErrorMG = ERROR_MESSAGE();
            EXEC [dbo].[spAddTbl_Exceptionloggingtodatabase] 
                 0, 
                 @ErrorMG, 
                 @ErrorSE, 
                 @ErrorST, 
                 @ErrorNO, 
                 NULL;
        END CATCH;
        IF @@TRANCOUNT > 0
            COMMIT TRANSACTION;
    END;
	GO
DROP PROCEDURE [dbo].[spDeleteCategories];
	GO
CREATE PROCEDURE [dbo].[spDeleteCategories](@Categoryid INT)
AS
    BEGIN
        BEGIN TRANSACTION;
        BEGIN TRY
            DELETE FROM [Categories]
            WHERE Categoryid = @Categoryid;
        END TRY
        BEGIN CATCH
            --SELECT ERROR_NUMBER() AS ErrorNumber, 
            --       ERROR_SEVERITY() AS ErrorSeverity, 
            --       ERROR_STATE() AS ErrorState, 
            --       ERROR_PROCEDURE() AS ErrorProcedure, 
            --       ERROR_LINE() AS ErrorLine, 
            --       ERROR_MESSAGE() AS ErrorMessage;

            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION;
            DECLARE @ErrorNO VARCHAR(50);
            DECLARE @ErrorSE VARCHAR(10);
            DECLARE @ErrorST VARCHAR(10);
            DECLARE @ErrorMG VARCHAR(MAX);
            SET @ErrorNO = 'Error Number: ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '; ' + 'Error Line: ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '; ';
            SET @ErrorSE = CAST(ERROR_SEVERITY() AS VARCHAR(10)) + '; ';
            SET @ErrorST = CAST(ERROR_STATE() AS VARCHAR(10)) + '; ';
            SET @ErrorMG = ERROR_MESSAGE();
            EXEC [dbo].[spAddTbl_Exceptionloggingtodatabase] 
                 0, 
                 @ErrorMG, 
                 @ErrorSE, 
                 @ErrorST, 
                 @ErrorNO, 
                 NULL;
        END CATCH;
        IF @@TRANCOUNT > 0
            COMMIT TRANSACTION;
    END;
	GO
DROP VIEW [dbo].[vwCategories];
	GO
CREATE VIEW [dbo].[vwCategories]
AS
     SELECT CategoryID, 
            CategoryName, 
            Description, 
            Picture
     FROM [Categories];
	GO
DROP PROCEDURE [dbo].[spGetAllCustomercustomerdemo];
	GO
CREATE PROCEDURE [dbo].[spGetAllCustomercustomerdemo]
AS
    BEGIN
        SELECT Customerid, 
               Customertypeid
        FROM [CustomerCustomerDemo];
    END;
	GO
DROP PROCEDURE [dbo].[spAddCustomercustomerdemo];
	GO
CREATE PROCEDURE [dbo].[spAddCustomercustomerdemo]
(@Customerid     NCHAR(5)  = '', 
 @Customertypeid NCHAR(10) = ''
)
AS
    BEGIN
        BEGIN TRANSACTION;
        BEGIN TRY
            INSERT INTO [CustomerCustomerDemo]
            ([Customerid], 
             [Customertypeid]
            )
            VALUES
            (@Customerid, 
             @Customertypeid
            );
        END TRY
        BEGIN CATCH
            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION;
            DECLARE @ErrorNO VARCHAR(50);
            DECLARE @ErrorSE VARCHAR(10);
            DECLARE @ErrorST VARCHAR(10);
            DECLARE @ErrorMG VARCHAR(MAX);
            SET @ErrorNO = 'Error Number: ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '; ' + 'Error Line: ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '; ';
            SET @ErrorSE = CAST(ERROR_SEVERITY() AS VARCHAR(10)) + '; ';
            SET @ErrorST = CAST(ERROR_STATE() AS VARCHAR(10)) + '; ';
            SET @ErrorMG = ERROR_MESSAGE();
            EXEC [dbo].[spAddTbl_Exceptionloggingtodatabase] 
                 0, 
                 @ErrorMG, 
                 @ErrorSE, 
                 @ErrorST, 
                 @ErrorNO, 
                 NULL;
        END CATCH;
        IF @@TRANCOUNT > 0
            COMMIT TRANSACTION;
    END;
	GO
DROP PROCEDURE [dbo].[spUpdateCustomercustomerdemo];
	GO
CREATE PROCEDURE [dbo].[spUpdateCustomercustomerdemo]
(@Customerid     NCHAR(5)  = '', 
 @Customertypeid NCHAR(10) = ''
)
AS
    BEGIN
        BEGIN TRANSACTION;
        BEGIN TRY
            UPDATE [CustomerCustomerDemo]
              SET 
                  Customertypeid = @Customertypeid
            WHERE Customerid = @Customerid;
        END TRY
        BEGIN CATCH
            --SELECT ERROR_NUMBER() AS ErrorNumber, 
            --       ERROR_SEVERITY() AS ErrorSeverity, 
            --       ERROR_STATE() AS ErrorState, 
            --       ERROR_PROCEDURE() AS ErrorProcedure, 
            --       ERROR_LINE() AS ErrorLine, 
            --       ERROR_MESSAGE() AS ErrorMessage;

            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION;
            DECLARE @ErrorNO VARCHAR(50);
            DECLARE @ErrorSE VARCHAR(10);
            DECLARE @ErrorST VARCHAR(10);
            DECLARE @ErrorMG VARCHAR(MAX);
            SET @ErrorNO = 'Error Number: ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '; ' + 'Error Line: ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '; ';
            SET @ErrorSE = CAST(ERROR_SEVERITY() AS VARCHAR(10)) + '; ';
            SET @ErrorST = CAST(ERROR_STATE() AS VARCHAR(10)) + '; ';
            SET @ErrorMG = ERROR_MESSAGE();
            EXEC [dbo].[spAddTbl_Exceptionloggingtodatabase] 
                 0, 
                 @ErrorMG, 
                 @ErrorSE, 
                 @ErrorST, 
                 @ErrorNO, 
                 NULL;
        END CATCH;
        IF @@TRANCOUNT > 0
            COMMIT TRANSACTION;
    END;
	GO
DROP PROCEDURE [dbo].[spDeleteCustomercustomerdemo];
	GO
CREATE PROCEDURE [dbo].[spDeleteCustomercustomerdemo](@Customerid NCHAR(5))
AS
    BEGIN
        BEGIN TRANSACTION;
        BEGIN TRY
            DELETE FROM [CustomerCustomerDemo]
            WHERE Customerid = @Customerid;
        END TRY
        BEGIN CATCH
            --SELECT ERROR_NUMBER() AS ErrorNumber, 
            --       ERROR_SEVERITY() AS ErrorSeverity, 
            --       ERROR_STATE() AS ErrorState, 
            --       ERROR_PROCEDURE() AS ErrorProcedure, 
            --       ERROR_LINE() AS ErrorLine, 
            --       ERROR_MESSAGE() AS ErrorMessage;

            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION;
            DECLARE @ErrorNO VARCHAR(50);
            DECLARE @ErrorSE VARCHAR(10);
            DECLARE @ErrorST VARCHAR(10);
            DECLARE @ErrorMG VARCHAR(MAX);
            SET @ErrorNO = 'Error Number: ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '; ' + 'Error Line: ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '; ';
            SET @ErrorSE = CAST(ERROR_SEVERITY() AS VARCHAR(10)) + '; ';
            SET @ErrorST = CAST(ERROR_STATE() AS VARCHAR(10)) + '; ';
            SET @ErrorMG = ERROR_MESSAGE();
            EXEC [dbo].[spAddTbl_Exceptionloggingtodatabase] 
                 0, 
                 @ErrorMG, 
                 @ErrorSE, 
                 @ErrorST, 
                 @ErrorNO, 
                 NULL;
        END CATCH;
        IF @@TRANCOUNT > 0
            COMMIT TRANSACTION;
    END;
	GO
DROP VIEW [dbo].[vwCustomercustomerdemo];
	GO
CREATE VIEW [dbo].[vwCustomercustomerdemo]
AS
     SELECT CustomerID, 
            CustomerTypeID
     FROM [CustomerCustomerDemo];
	GO
DROP PROCEDURE [dbo].[spGetAllCustomerdemographics];
	GO
CREATE PROCEDURE [dbo].[spGetAllCustomerdemographics]
AS
    BEGIN
        SELECT Customertypeid, 
               Customerdesc
        FROM [CustomerDemographics];
    END;
	GO
DROP PROCEDURE [dbo].[spAddCustomerdemographics];
	GO
CREATE PROCEDURE [dbo].[spAddCustomerdemographics]
(@Customertypeid NCHAR(10) = '', 
 @Customerdesc   NTEXT     = ''
)
AS
    BEGIN
        BEGIN TRANSACTION;
        BEGIN TRY
            INSERT INTO [CustomerDemographics]
            ([Customertypeid], 
             [Customerdesc]
            )
            VALUES
            (@Customertypeid, 
             @Customerdesc
            );
        END TRY
        BEGIN CATCH
            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION;
            DECLARE @ErrorNO VARCHAR(50);
            DECLARE @ErrorSE VARCHAR(10);
            DECLARE @ErrorST VARCHAR(10);
            DECLARE @ErrorMG VARCHAR(MAX);
            SET @ErrorNO = 'Error Number: ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '; ' + 'Error Line: ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '; ';
            SET @ErrorSE = CAST(ERROR_SEVERITY() AS VARCHAR(10)) + '; ';
            SET @ErrorST = CAST(ERROR_STATE() AS VARCHAR(10)) + '; ';
            SET @ErrorMG = ERROR_MESSAGE();
            EXEC [dbo].[spAddTbl_Exceptionloggingtodatabase] 
                 0, 
                 @ErrorMG, 
                 @ErrorSE, 
                 @ErrorST, 
                 @ErrorNO, 
                 NULL;
        END CATCH;
        IF @@TRANCOUNT > 0
            COMMIT TRANSACTION;
    END;
	GO
DROP PROCEDURE [dbo].[spUpdateCustomerdemographics];
	GO
CREATE PROCEDURE [dbo].[spUpdateCustomerdemographics]
(@Customertypeid NCHAR(10) = '', 
 @Customerdesc   NTEXT     = NULL
)
AS
    BEGIN
        BEGIN TRANSACTION;
        BEGIN TRY
            UPDATE [CustomerDemographics]
              SET 
                  Customerdesc = @Customerdesc
            WHERE Customertypeid = @Customertypeid;
        END TRY
        BEGIN CATCH
            --SELECT ERROR_NUMBER() AS ErrorNumber, 
            --       ERROR_SEVERITY() AS ErrorSeverity, 
            --       ERROR_STATE() AS ErrorState, 
            --       ERROR_PROCEDURE() AS ErrorProcedure, 
            --       ERROR_LINE() AS ErrorLine, 
            --       ERROR_MESSAGE() AS ErrorMessage;

            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION;
            DECLARE @ErrorNO VARCHAR(50);
            DECLARE @ErrorSE VARCHAR(10);
            DECLARE @ErrorST VARCHAR(10);
            DECLARE @ErrorMG VARCHAR(MAX);
            SET @ErrorNO = 'Error Number: ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '; ' + 'Error Line: ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '; ';
            SET @ErrorSE = CAST(ERROR_SEVERITY() AS VARCHAR(10)) + '; ';
            SET @ErrorST = CAST(ERROR_STATE() AS VARCHAR(10)) + '; ';
            SET @ErrorMG = ERROR_MESSAGE();
            EXEC [dbo].[spAddTbl_Exceptionloggingtodatabase] 
                 0, 
                 @ErrorMG, 
                 @ErrorSE, 
                 @ErrorST, 
                 @ErrorNO, 
                 NULL;
        END CATCH;
        IF @@TRANCOUNT > 0
            COMMIT TRANSACTION;
    END;
	GO
DROP PROCEDURE [dbo].[spDeleteCustomerdemographics];
	GO
CREATE PROCEDURE [dbo].[spDeleteCustomerdemographics](@Customertypeid NCHAR(10))
AS
    BEGIN
        BEGIN TRANSACTION;
        BEGIN TRY
            DELETE FROM [CustomerDemographics]
            WHERE Customertypeid = @Customertypeid;
        END TRY
        BEGIN CATCH
            --SELECT ERROR_NUMBER() AS ErrorNumber, 
            --       ERROR_SEVERITY() AS ErrorSeverity, 
            --       ERROR_STATE() AS ErrorState, 
            --       ERROR_PROCEDURE() AS ErrorProcedure, 
            --       ERROR_LINE() AS ErrorLine, 
            --       ERROR_MESSAGE() AS ErrorMessage;

            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION;
            DECLARE @ErrorNO VARCHAR(50);
            DECLARE @ErrorSE VARCHAR(10);
            DECLARE @ErrorST VARCHAR(10);
            DECLARE @ErrorMG VARCHAR(MAX);
            SET @ErrorNO = 'Error Number: ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '; ' + 'Error Line: ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '; ';
            SET @ErrorSE = CAST(ERROR_SEVERITY() AS VARCHAR(10)) + '; ';
            SET @ErrorST = CAST(ERROR_STATE() AS VARCHAR(10)) + '; ';
            SET @ErrorMG = ERROR_MESSAGE();
            EXEC [dbo].[spAddTbl_Exceptionloggingtodatabase] 
                 0, 
                 @ErrorMG, 
                 @ErrorSE, 
                 @ErrorST, 
                 @ErrorNO, 
                 NULL;
        END CATCH;
        IF @@TRANCOUNT > 0
            COMMIT TRANSACTION;
    END;
	GO
DROP VIEW [dbo].[vwCustomerdemographics];
	GO
CREATE VIEW [dbo].[vwCustomerdemographics]
AS
     SELECT CustomerTypeID, 
            CustomerDesc
     FROM [CustomerDemographics];
	GO
DROP PROCEDURE [dbo].[spGetAllCustomers];
	GO
CREATE PROCEDURE [dbo].[spGetAllCustomers]
AS
    BEGIN
        SELECT Customerid, 
               Companyname, 
               Contactname, 
               Contacttitle, 
               Address, 
               City, 
               Region, 
               Postalcode, 
               Country, 
               Phone, 
               Fax
        FROM [Customers];
    END;
	GO
DROP PROCEDURE [dbo].[spAddCustomers];
	GO
CREATE PROCEDURE [dbo].[spAddCustomers]
(@Customerid   NCHAR(5)     = '', 
 @Companyname  NVARCHAR(40) = '', 
 @Contactname  NVARCHAR(30) = NULL, 
 @Contacttitle NVARCHAR(30) = NULL, 
 @Address      NVARCHAR(60) = NULL, 
 @City         NVARCHAR(15) = NULL, 
 @Region       NVARCHAR(15) = NULL, 
 @Postalcode   NVARCHAR(10) = NULL, 
 @Country      NVARCHAR(15) = NULL, 
 @Phone        NVARCHAR(24) = NULL, 
 @Fax          NVARCHAR(24) = NULL
)
AS
    BEGIN
        BEGIN TRANSACTION;
        BEGIN TRY
            INSERT INTO [Customers]
            ([Customerid], 
             [Companyname], 
             [Contactname], 
             [Contacttitle], 
             [Address], 
             [City], 
             [Region], 
             [Postalcode], 
             [Country], 
             [Phone], 
             [Fax]
            )
            VALUES
            (@Customerid, 
             @Companyname, 
             @Contactname, 
             @Contacttitle, 
             @Address, 
             @City, 
             @Region, 
             @Postalcode, 
             @Country, 
             @Phone, 
             @Fax
            );
        END TRY
        BEGIN CATCH
            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION;
            DECLARE @ErrorNO VARCHAR(50);
            DECLARE @ErrorSE VARCHAR(10);
            DECLARE @ErrorST VARCHAR(10);
            DECLARE @ErrorMG VARCHAR(MAX);
            SET @ErrorNO = 'Error Number: ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '; ' + 'Error Line: ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '; ';
            SET @ErrorSE = CAST(ERROR_SEVERITY() AS VARCHAR(10)) + '; ';
            SET @ErrorST = CAST(ERROR_STATE() AS VARCHAR(10)) + '; ';
            SET @ErrorMG = ERROR_MESSAGE();
            EXEC [dbo].[spAddTbl_Exceptionloggingtodatabase] 
                 0, 
                 @ErrorMG, 
                 @ErrorSE, 
                 @ErrorST, 
                 @ErrorNO, 
                 NULL;
        END CATCH;
        IF @@TRANCOUNT > 0
            COMMIT TRANSACTION;
    END;
	GO
DROP PROCEDURE [dbo].[spUpdateCustomers];
	GO
CREATE PROCEDURE [dbo].[spUpdateCustomers]
(@Customerid   NCHAR(5)     = '', 
 @Companyname  NVARCHAR(40) = '', 
 @Contactname  NVARCHAR(30) = NULL, 
 @Contacttitle NVARCHAR(30) = NULL, 
 @Address      NVARCHAR(60) = NULL, 
 @City         NVARCHAR(15) = NULL, 
 @Region       NVARCHAR(15) = NULL, 
 @Postalcode   NVARCHAR(10) = NULL, 
 @Country      NVARCHAR(15) = NULL, 
 @Phone        NVARCHAR(24) = NULL, 
 @Fax          NVARCHAR(24) = NULL
)
AS
    BEGIN
        BEGIN TRANSACTION;
        BEGIN TRY
            UPDATE [Customers]
              SET 
                  Companyname = @Companyname, 
                  Contactname = @Contactname, 
                  Contacttitle = @Contacttitle, 
                  Address = @Address, 
                  City = @City, 
                  Region = @Region, 
                  Postalcode = @Postalcode, 
                  Country = @Country, 
                  Phone = @Phone, 
                  Fax = @Fax
            WHERE Customerid = @Customerid;
        END TRY
        BEGIN CATCH
            --SELECT ERROR_NUMBER() AS ErrorNumber, 
            --       ERROR_SEVERITY() AS ErrorSeverity, 
            --       ERROR_STATE() AS ErrorState, 
            --       ERROR_PROCEDURE() AS ErrorProcedure, 
            --       ERROR_LINE() AS ErrorLine, 
            --       ERROR_MESSAGE() AS ErrorMessage;

            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION;
            DECLARE @ErrorNO VARCHAR(50);
            DECLARE @ErrorSE VARCHAR(10);
            DECLARE @ErrorST VARCHAR(10);
            DECLARE @ErrorMG VARCHAR(MAX);
            SET @ErrorNO = 'Error Number: ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '; ' + 'Error Line: ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '; ';
            SET @ErrorSE = CAST(ERROR_SEVERITY() AS VARCHAR(10)) + '; ';
            SET @ErrorST = CAST(ERROR_STATE() AS VARCHAR(10)) + '; ';
            SET @ErrorMG = ERROR_MESSAGE();
            EXEC [dbo].[spAddTbl_Exceptionloggingtodatabase] 
                 0, 
                 @ErrorMG, 
                 @ErrorSE, 
                 @ErrorST, 
                 @ErrorNO, 
                 NULL;
        END CATCH;
        IF @@TRANCOUNT > 0
            COMMIT TRANSACTION;
    END;
	GO
DROP PROCEDURE [dbo].[spDeleteCustomers];
	GO
CREATE PROCEDURE [dbo].[spDeleteCustomers](@Customerid NCHAR(5))
AS
    BEGIN
        BEGIN TRANSACTION;
        BEGIN TRY
            DELETE FROM [Customers]
            WHERE Customerid = @Customerid;
        END TRY
        BEGIN CATCH
            --SELECT ERROR_NUMBER() AS ErrorNumber, 
            --       ERROR_SEVERITY() AS ErrorSeverity, 
            --       ERROR_STATE() AS ErrorState, 
            --       ERROR_PROCEDURE() AS ErrorProcedure, 
            --       ERROR_LINE() AS ErrorLine, 
            --       ERROR_MESSAGE() AS ErrorMessage;

            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION;
            DECLARE @ErrorNO VARCHAR(50);
            DECLARE @ErrorSE VARCHAR(10);
            DECLARE @ErrorST VARCHAR(10);
            DECLARE @ErrorMG VARCHAR(MAX);
            SET @ErrorNO = 'Error Number: ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '; ' + 'Error Line: ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '; ';
            SET @ErrorSE = CAST(ERROR_SEVERITY() AS VARCHAR(10)) + '; ';
            SET @ErrorST = CAST(ERROR_STATE() AS VARCHAR(10)) + '; ';
            SET @ErrorMG = ERROR_MESSAGE();
            EXEC [dbo].[spAddTbl_Exceptionloggingtodatabase] 
                 0, 
                 @ErrorMG, 
                 @ErrorSE, 
                 @ErrorST, 
                 @ErrorNO, 
                 NULL;
        END CATCH;
        IF @@TRANCOUNT > 0
            COMMIT TRANSACTION;
    END;
	GO
DROP VIEW [dbo].[vwCustomers];
	GO
CREATE VIEW [dbo].[vwCustomers]
AS
     SELECT CustomerID, 
            CompanyName, 
            ContactName, 
            ContactTitle, 
            Address, 
            City, 
            Region, 
            PostalCode, 
            Country, 
            Phone, 
            Fax
     FROM [Customers];
	GO
DROP PROCEDURE [dbo].[spGetAllEmployees];
	GO
CREATE PROCEDURE [dbo].[spGetAllEmployees]
AS
    BEGIN
        SELECT Employeeid, 
               Lastname, 
               Firstname, 
               Title, 
               Titleofcourtesy, 
               Birthdate, 
               Hiredate, 
               Address, 
               City, 
               Region, 
               Postalcode, 
               Country, 
               Homephone, 
               Extension, 
               Photo, 
               Notes, 
               Reportsto, 
               Photopath
        FROM [Employees];
    END;
	GO
DROP PROCEDURE [dbo].[spAddEmployees];
	GO
CREATE PROCEDURE [dbo].[spAddEmployees]
(@Employeeid      INT           = 0, 
 @Lastname        NVARCHAR(20)  = '', 
 @Firstname       NVARCHAR(10)  = '', 
 @Title           NVARCHAR(30)  = NULL, 
 @Titleofcourtesy NVARCHAR(25)  = NULL, 
 @Birthdate       DATETIME      = NULL, 
 @Hiredate        DATETIME      = NULL, 
 @Address         NVARCHAR(60)  = NULL, 
 @City            NVARCHAR(15)  = NULL, 
 @Region          NVARCHAR(15)  = NULL, 
 @Postalcode      NVARCHAR(10)  = NULL, 
 @Country         NVARCHAR(15)  = NULL, 
 @Homephone       NVARCHAR(24)  = NULL, 
 @Extension       NVARCHAR(4)   = NULL, 
 @Photo           IMAGE         = 0x424d42000000000000003e0000002800000001000000010000000100010000000000040000000000000000000000000000000000000000000000ffffff00800000000000000000000000000000000000000000000000000000000, 
 @Notes           NTEXT         = '', 
 @Reportsto       INT           = 0, 
 @Photopath       NVARCHAR(255) = NULL
)
AS
    BEGIN
        BEGIN TRANSACTION;
        BEGIN TRY
            INSERT INTO [Employees]
            (
            --[Employeeid]
            [Lastname], 
            [Firstname], 
            [Title], 
            [Titleofcourtesy], 
            [Birthdate], 
            [Hiredate], 
            [Address], 
            [City], 
            [Region], 
            [Postalcode], 
            [Country], 
            [Homephone], 
            [Extension], 
            [Photo], 
            [Notes], 
            [Reportsto], 
            [Photopath]
            )
            VALUES
            (
            --@Employeeid
            @Lastname, 
            @Firstname, 
            @Title, 
            @Titleofcourtesy, 
            @Birthdate, 
            @Hiredate, 
            @Address, 
            @City, 
            @Region, 
            @Postalcode, 
            @Country, 
            @Homephone, 
            @Extension, 
            @Photo, 
            @Notes, 
            @Reportsto, 
            @Photopath
            );
        END TRY
        BEGIN CATCH
            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION;
            DECLARE @ErrorNO VARCHAR(50);
            DECLARE @ErrorSE VARCHAR(10);
            DECLARE @ErrorST VARCHAR(10);
            DECLARE @ErrorMG VARCHAR(MAX);
            SET @ErrorNO = 'Error Number: ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '; ' + 'Error Line: ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '; ';
            SET @ErrorSE = CAST(ERROR_SEVERITY() AS VARCHAR(10)) + '; ';
            SET @ErrorST = CAST(ERROR_STATE() AS VARCHAR(10)) + '; ';
            SET @ErrorMG = ERROR_MESSAGE();
            EXEC [dbo].[spAddTbl_Exceptionloggingtodatabase] 
                 0, 
                 @ErrorMG, 
                 @ErrorSE, 
                 @ErrorST, 
                 @ErrorNO, 
                 NULL;
        END CATCH;
        IF @@TRANCOUNT > 0
            COMMIT TRANSACTION;
    END;
	GO
DROP PROCEDURE [dbo].[spUpdateEmployees];
	GO
CREATE PROCEDURE [dbo].[spUpdateEmployees]
(@Employeeid      INT           = 0, 
 @Lastname        NVARCHAR(20)  = '', 
 @Firstname       NVARCHAR(10)  = '', 
 @Title           NVARCHAR(30)  = NULL, 
 @Titleofcourtesy NVARCHAR(25)  = NULL, 
 @Birthdate       DATETIME      = NULL, 
 @Hiredate        DATETIME      = NULL, 
 @Address         NVARCHAR(60)  = NULL, 
 @City            NVARCHAR(15)  = NULL, 
 @Region          NVARCHAR(15)  = NULL, 
 @Postalcode      NVARCHAR(10)  = NULL, 
 @Country         NVARCHAR(15)  = NULL, 
 @Homephone       NVARCHAR(24)  = NULL, 
 @Extension       NVARCHAR(4)   = NULL, 
 @Photo           IMAGE         = NULL, 
 @Notes           NTEXT         = NULL, 
 @Reportsto       INT           = NULL, 
 @Photopath       NVARCHAR(255) = NULL
)
AS
    BEGIN
        BEGIN TRANSACTION;
        BEGIN TRY
            UPDATE [Employees]
              SET 
                  Lastname = @Lastname, 
                  Firstname = @Firstname, 
                  Title = @Title, 
                  Titleofcourtesy = @Titleofcourtesy, 
                  Birthdate = @Birthdate, 
                  Hiredate = @Hiredate, 
                  Address = @Address, 
                  City = @City, 
                  Region = @Region, 
                  Postalcode = @Postalcode, 
                  Country = @Country, 
                  Homephone = @Homephone, 
                  Extension = @Extension, 
                  Photo = @Photo, 
                  Notes = @Notes, 
                  Reportsto = @Reportsto, 
                  Photopath = @Photopath
            WHERE Employeeid = @Employeeid;
        END TRY
        BEGIN CATCH
            --SELECT ERROR_NUMBER() AS ErrorNumber, 
            --       ERROR_SEVERITY() AS ErrorSeverity, 
            --       ERROR_STATE() AS ErrorState, 
            --       ERROR_PROCEDURE() AS ErrorProcedure, 
            --       ERROR_LINE() AS ErrorLine, 
            --       ERROR_MESSAGE() AS ErrorMessage;

            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION;
            DECLARE @ErrorNO VARCHAR(50);
            DECLARE @ErrorSE VARCHAR(10);
            DECLARE @ErrorST VARCHAR(10);
            DECLARE @ErrorMG VARCHAR(MAX);
            SET @ErrorNO = 'Error Number: ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '; ' + 'Error Line: ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '; ';
            SET @ErrorSE = CAST(ERROR_SEVERITY() AS VARCHAR(10)) + '; ';
            SET @ErrorST = CAST(ERROR_STATE() AS VARCHAR(10)) + '; ';
            SET @ErrorMG = ERROR_MESSAGE();
            EXEC [dbo].[spAddTbl_Exceptionloggingtodatabase] 
                 0, 
                 @ErrorMG, 
                 @ErrorSE, 
                 @ErrorST, 
                 @ErrorNO, 
                 NULL;
        END CATCH;
        IF @@TRANCOUNT > 0
            COMMIT TRANSACTION;
    END;
	GO
DROP PROCEDURE [dbo].[spDeleteEmployees];
	GO
CREATE PROCEDURE [dbo].[spDeleteEmployees](@Employeeid INT)
AS
    BEGIN
        BEGIN TRANSACTION;
        BEGIN TRY
            DELETE FROM [Employees]
            WHERE Employeeid = @Employeeid;
        END TRY
        BEGIN CATCH
            --SELECT ERROR_NUMBER() AS ErrorNumber, 
            --       ERROR_SEVERITY() AS ErrorSeverity, 
            --       ERROR_STATE() AS ErrorState, 
            --       ERROR_PROCEDURE() AS ErrorProcedure, 
            --       ERROR_LINE() AS ErrorLine, 
            --       ERROR_MESSAGE() AS ErrorMessage;

            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION;
            DECLARE @ErrorNO VARCHAR(50);
            DECLARE @ErrorSE VARCHAR(10);
            DECLARE @ErrorST VARCHAR(10);
            DECLARE @ErrorMG VARCHAR(MAX);
            SET @ErrorNO = 'Error Number: ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '; ' + 'Error Line: ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '; ';
            SET @ErrorSE = CAST(ERROR_SEVERITY() AS VARCHAR(10)) + '; ';
            SET @ErrorST = CAST(ERROR_STATE() AS VARCHAR(10)) + '; ';
            SET @ErrorMG = ERROR_MESSAGE();
            EXEC [dbo].[spAddTbl_Exceptionloggingtodatabase] 
                 0, 
                 @ErrorMG, 
                 @ErrorSE, 
                 @ErrorST, 
                 @ErrorNO, 
                 NULL;
        END CATCH;
        IF @@TRANCOUNT > 0
            COMMIT TRANSACTION;
    END;
	GO
DROP VIEW [dbo].[vwEmployees];
	GO
CREATE VIEW [dbo].[vwEmployees]
AS
     SELECT EmployeeID, 
            LastName, 
            FirstName, 
            Title, 
            TitleOfCourtesy, 
            BirthDate, 
            HireDate, 
            Address, 
            City, 
            Region, 
            PostalCode, 
            Country, 
            HomePhone, 
            Extension, 
            Photo, 
            Notes, 
            ReportsTo, 
            PhotoPath
     FROM [Employees];
	GO
DROP PROCEDURE [dbo].[spGetAllEmployeeterritories];
	GO
CREATE PROCEDURE [dbo].[spGetAllEmployeeterritories]
AS
    BEGIN
        SELECT Employeeid, 
               Territoryid
        FROM [EmployeeTerritories];
    END;
	GO
DROP PROCEDURE [dbo].[spAddEmployeeterritories];
	GO
CREATE PROCEDURE [dbo].[spAddEmployeeterritories]
(@Employeeid  INT          = 0, 
 @Territoryid NVARCHAR(20) = ''
)
AS
    BEGIN
        BEGIN TRANSACTION;
        BEGIN TRY
            INSERT INTO [EmployeeTerritories]
            ([Employeeid], 
             [Territoryid]
            )
            VALUES
            (@Employeeid, 
             @Territoryid
            );
        END TRY
        BEGIN CATCH
            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION;
            DECLARE @ErrorNO VARCHAR(50);
            DECLARE @ErrorSE VARCHAR(10);
            DECLARE @ErrorST VARCHAR(10);
            DECLARE @ErrorMG VARCHAR(MAX);
            SET @ErrorNO = 'Error Number: ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '; ' + 'Error Line: ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '; ';
            SET @ErrorSE = CAST(ERROR_SEVERITY() AS VARCHAR(10)) + '; ';
            SET @ErrorST = CAST(ERROR_STATE() AS VARCHAR(10)) + '; ';
            SET @ErrorMG = ERROR_MESSAGE();
            EXEC [dbo].[spAddTbl_Exceptionloggingtodatabase] 
                 0, 
                 @ErrorMG, 
                 @ErrorSE, 
                 @ErrorST, 
                 @ErrorNO, 
                 NULL;
        END CATCH;
        IF @@TRANCOUNT > 0
            COMMIT TRANSACTION;
    END;
	GO
DROP PROCEDURE [dbo].[spUpdateEmployeeterritories];
	GO
CREATE PROCEDURE [dbo].[spUpdateEmployeeterritories]
(@Employeeid  INT          = 0, 
 @Territoryid NVARCHAR(20) = ''
)
AS
    BEGIN
        BEGIN TRANSACTION;
        BEGIN TRY
            UPDATE [EmployeeTerritories]
              SET 
                  Territoryid = @Territoryid
            WHERE Employeeid = @Employeeid;
        END TRY
        BEGIN CATCH
            --SELECT ERROR_NUMBER() AS ErrorNumber, 
            --       ERROR_SEVERITY() AS ErrorSeverity, 
            --       ERROR_STATE() AS ErrorState, 
            --       ERROR_PROCEDURE() AS ErrorProcedure, 
            --       ERROR_LINE() AS ErrorLine, 
            --       ERROR_MESSAGE() AS ErrorMessage;

            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION;
            DECLARE @ErrorNO VARCHAR(50);
            DECLARE @ErrorSE VARCHAR(10);
            DECLARE @ErrorST VARCHAR(10);
            DECLARE @ErrorMG VARCHAR(MAX);
            SET @ErrorNO = 'Error Number: ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '; ' + 'Error Line: ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '; ';
            SET @ErrorSE = CAST(ERROR_SEVERITY() AS VARCHAR(10)) + '; ';
            SET @ErrorST = CAST(ERROR_STATE() AS VARCHAR(10)) + '; ';
            SET @ErrorMG = ERROR_MESSAGE();
            EXEC [dbo].[spAddTbl_Exceptionloggingtodatabase] 
                 0, 
                 @ErrorMG, 
                 @ErrorSE, 
                 @ErrorST, 
                 @ErrorNO, 
                 NULL;
        END CATCH;
        IF @@TRANCOUNT > 0
            COMMIT TRANSACTION;
    END;
	GO
DROP PROCEDURE [dbo].[spDeleteEmployeeterritories];
	GO
CREATE PROCEDURE [dbo].[spDeleteEmployeeterritories](@Employeeid INT)
AS
    BEGIN
        BEGIN TRANSACTION;
        BEGIN TRY
            DELETE FROM [EmployeeTerritories]
            WHERE Employeeid = @Employeeid;
        END TRY
        BEGIN CATCH
            --SELECT ERROR_NUMBER() AS ErrorNumber, 
            --       ERROR_SEVERITY() AS ErrorSeverity, 
            --       ERROR_STATE() AS ErrorState, 
            --       ERROR_PROCEDURE() AS ErrorProcedure, 
            --       ERROR_LINE() AS ErrorLine, 
            --       ERROR_MESSAGE() AS ErrorMessage;

            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION;
            DECLARE @ErrorNO VARCHAR(50);
            DECLARE @ErrorSE VARCHAR(10);
            DECLARE @ErrorST VARCHAR(10);
            DECLARE @ErrorMG VARCHAR(MAX);
            SET @ErrorNO = 'Error Number: ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '; ' + 'Error Line: ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '; ';
            SET @ErrorSE = CAST(ERROR_SEVERITY() AS VARCHAR(10)) + '; ';
            SET @ErrorST = CAST(ERROR_STATE() AS VARCHAR(10)) + '; ';
            SET @ErrorMG = ERROR_MESSAGE();
            EXEC [dbo].[spAddTbl_Exceptionloggingtodatabase] 
                 0, 
                 @ErrorMG, 
                 @ErrorSE, 
                 @ErrorST, 
                 @ErrorNO, 
                 NULL;
        END CATCH;
        IF @@TRANCOUNT > 0
            COMMIT TRANSACTION;
    END;
	GO
DROP VIEW [dbo].[vwEmployeeterritories];
	GO
CREATE VIEW [dbo].[vwEmployeeterritories]
AS
     SELECT EmployeeID, 
            TerritoryID
     FROM [EmployeeTerritories];
	GO
DROP PROCEDURE [dbo].[spGetAllOrder_Details];
	GO
CREATE PROCEDURE [dbo].[spGetAllOrder_Details]
AS
    BEGIN
        SELECT Orderid, 
               Productid, 
               Unitprice, 
               Quantity, 
               Discount
        FROM [Order Details];
    END;
	GO
DROP PROCEDURE [dbo].[spAddOrder_Details];
	GO
CREATE PROCEDURE [dbo].[spAddOrder_Details]
(@Orderid   INT      = 0, 
 @Productid INT      = 0, 
 @Unitprice MONEY    = 0, 
 @Quantity  SMALLINT = 0, 
 @Discount  REAL     = 0
)
AS
    BEGIN
        BEGIN TRANSACTION;
        BEGIN TRY
            INSERT INTO [Order Details]
            ([Orderid], 
             [Productid], 
             [Unitprice], 
             [Quantity], 
             [Discount]
            )
            VALUES
            (@Orderid, 
             @Productid, 
             @Unitprice, 
             @Quantity, 
             @Discount
            );
        END TRY
        BEGIN CATCH
            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION;
            DECLARE @ErrorNO VARCHAR(50);
            DECLARE @ErrorSE VARCHAR(10);
            DECLARE @ErrorST VARCHAR(10);
            DECLARE @ErrorMG VARCHAR(MAX);
            SET @ErrorNO = 'Error Number: ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '; ' + 'Error Line: ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '; ';
            SET @ErrorSE = CAST(ERROR_SEVERITY() AS VARCHAR(10)) + '; ';
            SET @ErrorST = CAST(ERROR_STATE() AS VARCHAR(10)) + '; ';
            SET @ErrorMG = ERROR_MESSAGE();
            EXEC [dbo].[spAddTbl_Exceptionloggingtodatabase] 
                 0, 
                 @ErrorMG, 
                 @ErrorSE, 
                 @ErrorST, 
                 @ErrorNO, 
                 NULL;
        END CATCH;
        IF @@TRANCOUNT > 0
            COMMIT TRANSACTION;
    END;
	GO
DROP PROCEDURE [dbo].[spUpdateOrder_Details];
	GO
CREATE PROCEDURE [dbo].[spUpdateOrder_Details]
(@Orderid   INT      = 0, 
 @Productid INT      = 0, 
 @Unitprice MONEY    = 0, 
 @Quantity  SMALLINT = 0, 
 @Discount  REAL     = 0
)
AS
    BEGIN
        BEGIN TRANSACTION;
        BEGIN TRY
            UPDATE [Order Details]
              SET 
                  Productid = @Productid, 
                  Unitprice = @Unitprice, 
                  Quantity = @Quantity, 
                  Discount = @Discount
            WHERE Orderid = @Orderid;
        END TRY
        BEGIN CATCH
            --SELECT ERROR_NUMBER() AS ErrorNumber, 
            --       ERROR_SEVERITY() AS ErrorSeverity, 
            --       ERROR_STATE() AS ErrorState, 
            --       ERROR_PROCEDURE() AS ErrorProcedure, 
            --       ERROR_LINE() AS ErrorLine, 
            --       ERROR_MESSAGE() AS ErrorMessage;

            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION;
            DECLARE @ErrorNO VARCHAR(50);
            DECLARE @ErrorSE VARCHAR(10);
            DECLARE @ErrorST VARCHAR(10);
            DECLARE @ErrorMG VARCHAR(MAX);
            SET @ErrorNO = 'Error Number: ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '; ' + 'Error Line: ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '; ';
            SET @ErrorSE = CAST(ERROR_SEVERITY() AS VARCHAR(10)) + '; ';
            SET @ErrorST = CAST(ERROR_STATE() AS VARCHAR(10)) + '; ';
            SET @ErrorMG = ERROR_MESSAGE();
            EXEC [dbo].[spAddTbl_Exceptionloggingtodatabase] 
                 0, 
                 @ErrorMG, 
                 @ErrorSE, 
                 @ErrorST, 
                 @ErrorNO, 
                 NULL;
        END CATCH;
        IF @@TRANCOUNT > 0
            COMMIT TRANSACTION;
    END;
	GO
DROP PROCEDURE [dbo].[spDeleteOrder_Details];
	GO
CREATE PROCEDURE [dbo].[spDeleteOrder_Details](@Orderid INT)
AS
    BEGIN
        BEGIN TRANSACTION;
        BEGIN TRY
            DELETE FROM [Order Details]
            WHERE Orderid = @Orderid;
        END TRY
        BEGIN CATCH
            --SELECT ERROR_NUMBER() AS ErrorNumber, 
            --       ERROR_SEVERITY() AS ErrorSeverity, 
            --       ERROR_STATE() AS ErrorState, 
            --       ERROR_PROCEDURE() AS ErrorProcedure, 
            --       ERROR_LINE() AS ErrorLine, 
            --       ERROR_MESSAGE() AS ErrorMessage;

            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION;
            DECLARE @ErrorNO VARCHAR(50);
            DECLARE @ErrorSE VARCHAR(10);
            DECLARE @ErrorST VARCHAR(10);
            DECLARE @ErrorMG VARCHAR(MAX);
            SET @ErrorNO = 'Error Number: ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '; ' + 'Error Line: ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '; ';
            SET @ErrorSE = CAST(ERROR_SEVERITY() AS VARCHAR(10)) + '; ';
            SET @ErrorST = CAST(ERROR_STATE() AS VARCHAR(10)) + '; ';
            SET @ErrorMG = ERROR_MESSAGE();
            EXEC [dbo].[spAddTbl_Exceptionloggingtodatabase] 
                 0, 
                 @ErrorMG, 
                 @ErrorSE, 
                 @ErrorST, 
                 @ErrorNO, 
                 NULL;
        END CATCH;
        IF @@TRANCOUNT > 0
            COMMIT TRANSACTION;
    END;
	GO
DROP VIEW [dbo].[vwOrder_Details];
	GO
CREATE VIEW [dbo].[vwOrder_Details]
AS
     SELECT OrderID, 
            ProductID, 
            UnitPrice, 
            Quantity, 
            Discount
     FROM [Order Details];
	GO
DROP PROCEDURE [dbo].[spGetAllOrders];
	GO
CREATE PROCEDURE [dbo].[spGetAllOrders]
AS
    BEGIN
        SELECT Orderid, 
               Customerid, 
               Employeeid, 
               Orderdate, 
               Requireddate, 
               Shippeddate, 
               Shipvia, 
               Freight, 
               Shipname, 
               Shipaddress, 
               Shipcity, 
               Shipregion, 
               Shippostalcode, 
               Shipcountry
        FROM [Orders];
    END;
	GO
DROP PROCEDURE [dbo].[spAddOrders];
	GO
CREATE PROCEDURE [dbo].[spAddOrders]
(@Orderid        INT          = 0, 
 @Customerid     NCHAR(5)     = NULL, 
 @Employeeid     INT          = 0, 
 @Orderdate      DATETIME     = NULL, 
 @Requireddate   DATETIME     = NULL, 
 @Shippeddate    DATETIME     = NULL, 
 @Shipvia        INT          = 0, 
 @Freight        MONEY        = 0, 
 @Shipname       NVARCHAR(40) = NULL, 
 @Shipaddress    NVARCHAR(60) = NULL, 
 @Shipcity       NVARCHAR(15) = NULL, 
 @Shipregion     NVARCHAR(15) = NULL, 
 @Shippostalcode NVARCHAR(10) = NULL, 
 @Shipcountry    NVARCHAR(15) = NULL
)
AS
    BEGIN
        BEGIN TRANSACTION;
        BEGIN TRY
            INSERT INTO [Orders]
            (
            --[Orderid]
            [Customerid], 
            [Employeeid], 
            [Orderdate], 
            [Requireddate], 
            [Shippeddate], 
            [Shipvia], 
            [Freight], 
            [Shipname], 
            [Shipaddress], 
            [Shipcity], 
            [Shipregion], 
            [Shippostalcode], 
            [Shipcountry]
            )
            VALUES
            (
            --@Orderid
            @Customerid, 
            @Employeeid, 
            @Orderdate, 
            @Requireddate, 
            @Shippeddate, 
            @Shipvia, 
            @Freight, 
            @Shipname, 
            @Shipaddress, 
            @Shipcity, 
            @Shipregion, 
            @Shippostalcode, 
            @Shipcountry
            );
        END TRY
        BEGIN CATCH
            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION;
            DECLARE @ErrorNO VARCHAR(50);
            DECLARE @ErrorSE VARCHAR(10);
            DECLARE @ErrorST VARCHAR(10);
            DECLARE @ErrorMG VARCHAR(MAX);
            SET @ErrorNO = 'Error Number: ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '; ' + 'Error Line: ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '; ';
            SET @ErrorSE = CAST(ERROR_SEVERITY() AS VARCHAR(10)) + '; ';
            SET @ErrorST = CAST(ERROR_STATE() AS VARCHAR(10)) + '; ';
            SET @ErrorMG = ERROR_MESSAGE();
            EXEC [dbo].[spAddTbl_Exceptionloggingtodatabase] 
                 0, 
                 @ErrorMG, 
                 @ErrorSE, 
                 @ErrorST, 
                 @ErrorNO, 
                 NULL;
        END CATCH;
        IF @@TRANCOUNT > 0
            COMMIT TRANSACTION;
    END;
	GO
DROP PROCEDURE [dbo].[spUpdateOrders];
	GO
CREATE PROCEDURE [dbo].[spUpdateOrders]
(@Orderid        INT          = 0, 
 @Customerid     NCHAR(5)     = NULL, 
 @Employeeid     INT          = NULL, 
 @Orderdate      DATETIME     = NULL, 
 @Requireddate   DATETIME     = NULL, 
 @Shippeddate    DATETIME     = NULL, 
 @Shipvia        INT          = NULL, 
 @Freight        MONEY        = NULL, 
 @Shipname       NVARCHAR(40) = NULL, 
 @Shipaddress    NVARCHAR(60) = NULL, 
 @Shipcity       NVARCHAR(15) = NULL, 
 @Shipregion     NVARCHAR(15) = NULL, 
 @Shippostalcode NVARCHAR(10) = NULL, 
 @Shipcountry    NVARCHAR(15) = NULL
)
AS
    BEGIN
        BEGIN TRANSACTION;
        BEGIN TRY
            UPDATE [Orders]
              SET 
                  Customerid = @Customerid, 
                  Employeeid = @Employeeid, 
                  Orderdate = @Orderdate, 
                  Requireddate = @Requireddate, 
                  Shippeddate = @Shippeddate, 
                  Shipvia = @Shipvia, 
                  Freight = @Freight, 
                  Shipname = @Shipname, 
                  Shipaddress = @Shipaddress, 
                  Shipcity = @Shipcity, 
                  Shipregion = @Shipregion, 
                  Shippostalcode = @Shippostalcode, 
                  Shipcountry = @Shipcountry
            WHERE Orderid = @Orderid;
        END TRY
        BEGIN CATCH
            --SELECT ERROR_NUMBER() AS ErrorNumber, 
            --       ERROR_SEVERITY() AS ErrorSeverity, 
            --       ERROR_STATE() AS ErrorState, 
            --       ERROR_PROCEDURE() AS ErrorProcedure, 
            --       ERROR_LINE() AS ErrorLine, 
            --       ERROR_MESSAGE() AS ErrorMessage;

            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION;
            DECLARE @ErrorNO VARCHAR(50);
            DECLARE @ErrorSE VARCHAR(10);
            DECLARE @ErrorST VARCHAR(10);
            DECLARE @ErrorMG VARCHAR(MAX);
            SET @ErrorNO = 'Error Number: ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '; ' + 'Error Line: ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '; ';
            SET @ErrorSE = CAST(ERROR_SEVERITY() AS VARCHAR(10)) + '; ';
            SET @ErrorST = CAST(ERROR_STATE() AS VARCHAR(10)) + '; ';
            SET @ErrorMG = ERROR_MESSAGE();
            EXEC [dbo].[spAddTbl_Exceptionloggingtodatabase] 
                 0, 
                 @ErrorMG, 
                 @ErrorSE, 
                 @ErrorST, 
                 @ErrorNO, 
                 NULL;
        END CATCH;
        IF @@TRANCOUNT > 0
            COMMIT TRANSACTION;
    END;
	GO
DROP PROCEDURE [dbo].[spDeleteOrders];
	GO
CREATE PROCEDURE [dbo].[spDeleteOrders](@Orderid INT)
AS
    BEGIN
        BEGIN TRANSACTION;
        BEGIN TRY
            DELETE FROM [Orders]
            WHERE Orderid = @Orderid;
        END TRY
        BEGIN CATCH
            --SELECT ERROR_NUMBER() AS ErrorNumber, 
            --       ERROR_SEVERITY() AS ErrorSeverity, 
            --       ERROR_STATE() AS ErrorState, 
            --       ERROR_PROCEDURE() AS ErrorProcedure, 
            --       ERROR_LINE() AS ErrorLine, 
            --       ERROR_MESSAGE() AS ErrorMessage;

            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION;
            DECLARE @ErrorNO VARCHAR(50);
            DECLARE @ErrorSE VARCHAR(10);
            DECLARE @ErrorST VARCHAR(10);
            DECLARE @ErrorMG VARCHAR(MAX);
            SET @ErrorNO = 'Error Number: ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '; ' + 'Error Line: ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '; ';
            SET @ErrorSE = CAST(ERROR_SEVERITY() AS VARCHAR(10)) + '; ';
            SET @ErrorST = CAST(ERROR_STATE() AS VARCHAR(10)) + '; ';
            SET @ErrorMG = ERROR_MESSAGE();
            EXEC [dbo].[spAddTbl_Exceptionloggingtodatabase] 
                 0, 
                 @ErrorMG, 
                 @ErrorSE, 
                 @ErrorST, 
                 @ErrorNO, 
                 NULL;
        END CATCH;
        IF @@TRANCOUNT > 0
            COMMIT TRANSACTION;
    END;
	GO
DROP VIEW [dbo].[vwOrders];
	GO
CREATE VIEW [dbo].[vwOrders]
AS
     SELECT OrderID, 
            CustomerID, 
            EmployeeID, 
            OrderDate, 
            RequiredDate, 
            ShippedDate, 
            ShipVia, 
            Freight, 
            ShipName, 
            ShipAddress, 
            ShipCity, 
            ShipRegion, 
            ShipPostalCode, 
            ShipCountry
     FROM [Orders];
	GO
DROP PROCEDURE [dbo].[spGetAllProducts];
	GO
CREATE PROCEDURE [dbo].[spGetAllProducts]
AS
    BEGIN
        SELECT Productid, 
               Productname, 
               Supplierid, 
               Categoryid, 
               Quantityperunit, 
               Unitprice, 
               Unitsinstock, 
               Unitsonorder, 
               Reorderlevel, 
               Discontinued
        FROM [Products];
    END;
	GO
DROP PROCEDURE [dbo].[spAddProducts];
	GO
CREATE PROCEDURE [dbo].[spAddProducts]
(@Productid       INT          = 0, 
 @Productname     NVARCHAR(40) = '', 
 @Supplierid      INT          = 0, 
 @Categoryid      INT          = 0, 
 @Quantityperunit NVARCHAR(20) = NULL, 
 @Unitprice       MONEY        = 0, 
 @Unitsinstock    SMALLINT     = 0, 
 @Unitsonorder    SMALLINT     = 0, 
 @Reorderlevel    SMALLINT     = 0, 
 @Discontinued    BIT          = NULL
)
AS
    BEGIN
        BEGIN TRANSACTION;
        BEGIN TRY
            INSERT INTO [Products]
            (
            --[Productid]
            [Productname], 
            [Supplierid], 
            [Categoryid], 
            [Quantityperunit], 
            [Unitprice], 
            [Unitsinstock], 
            [Unitsonorder], 
            [Reorderlevel], 
            [Discontinued]
            )
            VALUES
            (
            --@Productid
            @Productname, 
            @Supplierid, 
            @Categoryid, 
            @Quantityperunit, 
            @Unitprice, 
            @Unitsinstock, 
            @Unitsonorder, 
            @Reorderlevel, 
            @Discontinued
            );
        END TRY
        BEGIN CATCH
            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION;
            DECLARE @ErrorNO VARCHAR(50);
            DECLARE @ErrorSE VARCHAR(10);
            DECLARE @ErrorST VARCHAR(10);
            DECLARE @ErrorMG VARCHAR(MAX);
            SET @ErrorNO = 'Error Number: ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '; ' + 'Error Line: ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '; ';
            SET @ErrorSE = CAST(ERROR_SEVERITY() AS VARCHAR(10)) + '; ';
            SET @ErrorST = CAST(ERROR_STATE() AS VARCHAR(10)) + '; ';
            SET @ErrorMG = ERROR_MESSAGE();
            EXEC [dbo].[spAddTbl_Exceptionloggingtodatabase] 
                 0, 
                 @ErrorMG, 
                 @ErrorSE, 
                 @ErrorST, 
                 @ErrorNO, 
                 NULL;
        END CATCH;
        IF @@TRANCOUNT > 0
            COMMIT TRANSACTION;
    END;
	GO
DROP PROCEDURE [dbo].[spUpdateProducts];
	GO
CREATE PROCEDURE [dbo].[spUpdateProducts]
(@Productid       INT          = 0, 
 @Productname     NVARCHAR(40) = '', 
 @Supplierid      INT          = NULL, 
 @Categoryid      INT          = NULL, 
 @Quantityperunit NVARCHAR(20) = NULL, 
 @Unitprice       MONEY        = NULL, 
 @Unitsinstock    SMALLINT     = NULL, 
 @Unitsonorder    SMALLINT     = NULL, 
 @Reorderlevel    SMALLINT     = NULL, 
 @Discontinued    BIT          = NULL
)
AS
    BEGIN
        BEGIN TRANSACTION;
        BEGIN TRY
            UPDATE [Products]
              SET 
                  Productname = @Productname, 
                  Supplierid = @Supplierid, 
                  Categoryid = @Categoryid, 
                  Quantityperunit = @Quantityperunit, 
                  Unitprice = @Unitprice, 
                  Unitsinstock = @Unitsinstock, 
                  Unitsonorder = @Unitsonorder, 
                  Reorderlevel = @Reorderlevel, 
                  Discontinued = @Discontinued
            WHERE Productid = @Productid;
        END TRY
        BEGIN CATCH
            --SELECT ERROR_NUMBER() AS ErrorNumber, 
            --       ERROR_SEVERITY() AS ErrorSeverity, 
            --       ERROR_STATE() AS ErrorState, 
            --       ERROR_PROCEDURE() AS ErrorProcedure, 
            --       ERROR_LINE() AS ErrorLine, 
            --       ERROR_MESSAGE() AS ErrorMessage;

            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION;
            DECLARE @ErrorNO VARCHAR(50);
            DECLARE @ErrorSE VARCHAR(10);
            DECLARE @ErrorST VARCHAR(10);
            DECLARE @ErrorMG VARCHAR(MAX);
            SET @ErrorNO = 'Error Number: ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '; ' + 'Error Line: ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '; ';
            SET @ErrorSE = CAST(ERROR_SEVERITY() AS VARCHAR(10)) + '; ';
            SET @ErrorST = CAST(ERROR_STATE() AS VARCHAR(10)) + '; ';
            SET @ErrorMG = ERROR_MESSAGE();
            EXEC [dbo].[spAddTbl_Exceptionloggingtodatabase] 
                 0, 
                 @ErrorMG, 
                 @ErrorSE, 
                 @ErrorST, 
                 @ErrorNO, 
                 NULL;
        END CATCH;
        IF @@TRANCOUNT > 0
            COMMIT TRANSACTION;
    END;
	GO
DROP PROCEDURE [dbo].[spDeleteProducts];
	GO
CREATE PROCEDURE [dbo].[spDeleteProducts](@Productid INT)
AS
    BEGIN
        BEGIN TRANSACTION;
        BEGIN TRY
            DELETE FROM [Products]
            WHERE Productid = @Productid;
        END TRY
        BEGIN CATCH
            --SELECT ERROR_NUMBER() AS ErrorNumber, 
            --       ERROR_SEVERITY() AS ErrorSeverity, 
            --       ERROR_STATE() AS ErrorState, 
            --       ERROR_PROCEDURE() AS ErrorProcedure, 
            --       ERROR_LINE() AS ErrorLine, 
            --       ERROR_MESSAGE() AS ErrorMessage;

            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION;
            DECLARE @ErrorNO VARCHAR(50);
            DECLARE @ErrorSE VARCHAR(10);
            DECLARE @ErrorST VARCHAR(10);
            DECLARE @ErrorMG VARCHAR(MAX);
            SET @ErrorNO = 'Error Number: ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '; ' + 'Error Line: ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '; ';
            SET @ErrorSE = CAST(ERROR_SEVERITY() AS VARCHAR(10)) + '; ';
            SET @ErrorST = CAST(ERROR_STATE() AS VARCHAR(10)) + '; ';
            SET @ErrorMG = ERROR_MESSAGE();
            EXEC [dbo].[spAddTbl_Exceptionloggingtodatabase] 
                 0, 
                 @ErrorMG, 
                 @ErrorSE, 
                 @ErrorST, 
                 @ErrorNO, 
                 NULL;
        END CATCH;
        IF @@TRANCOUNT > 0
            COMMIT TRANSACTION;
    END;
	GO
DROP VIEW [dbo].[vwProducts];
	GO
CREATE VIEW [dbo].[vwProducts]
AS
     SELECT ProductID, 
            ProductName, 
            SupplierID, 
            CategoryID, 
            QuantityPerUnit, 
            UnitPrice, 
            UnitsInStock, 
            UnitsOnOrder, 
            ReorderLevel, 
            Discontinued
     FROM [Products];
	GO
DROP PROCEDURE [dbo].[spGetAllRegion];
	GO
CREATE PROCEDURE [dbo].[spGetAllRegion]
AS
    BEGIN
        SELECT Regionid, 
               Regiondescription
        FROM [Region];
    END;
	GO
DROP PROCEDURE [dbo].[spAddRegion];
	GO
CREATE PROCEDURE [dbo].[spAddRegion]
(@Regionid          INT       = 0, 
 @Regiondescription NCHAR(50) = ''
)
AS
    BEGIN
        BEGIN TRANSACTION;
        BEGIN TRY
            INSERT INTO [Region]
            ([Regionid], 
             [Regiondescription]
            )
            VALUES
            (@Regionid, 
             @Regiondescription
            );
        END TRY
        BEGIN CATCH
            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION;
            DECLARE @ErrorNO VARCHAR(50);
            DECLARE @ErrorSE VARCHAR(10);
            DECLARE @ErrorST VARCHAR(10);
            DECLARE @ErrorMG VARCHAR(MAX);
            SET @ErrorNO = 'Error Number: ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '; ' + 'Error Line: ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '; ';
            SET @ErrorSE = CAST(ERROR_SEVERITY() AS VARCHAR(10)) + '; ';
            SET @ErrorST = CAST(ERROR_STATE() AS VARCHAR(10)) + '; ';
            SET @ErrorMG = ERROR_MESSAGE();
            EXEC [dbo].[spAddTbl_Exceptionloggingtodatabase] 
                 0, 
                 @ErrorMG, 
                 @ErrorSE, 
                 @ErrorST, 
                 @ErrorNO, 
                 NULL;
        END CATCH;
        IF @@TRANCOUNT > 0
            COMMIT TRANSACTION;
    END;
	GO
DROP PROCEDURE [dbo].[spUpdateRegion];
	GO
CREATE PROCEDURE [dbo].[spUpdateRegion]
(@Regionid          INT       = 0, 
 @Regiondescription NCHAR(50) = ''
)
AS
    BEGIN
        BEGIN TRANSACTION;
        BEGIN TRY
            UPDATE [Region]
              SET 
                  Regiondescription = @Regiondescription
            WHERE Regionid = @Regionid;
        END TRY
        BEGIN CATCH
            --SELECT ERROR_NUMBER() AS ErrorNumber, 
            --       ERROR_SEVERITY() AS ErrorSeverity, 
            --       ERROR_STATE() AS ErrorState, 
            --       ERROR_PROCEDURE() AS ErrorProcedure, 
            --       ERROR_LINE() AS ErrorLine, 
            --       ERROR_MESSAGE() AS ErrorMessage;

            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION;
            DECLARE @ErrorNO VARCHAR(50);
            DECLARE @ErrorSE VARCHAR(10);
            DECLARE @ErrorST VARCHAR(10);
            DECLARE @ErrorMG VARCHAR(MAX);
            SET @ErrorNO = 'Error Number: ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '; ' + 'Error Line: ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '; ';
            SET @ErrorSE = CAST(ERROR_SEVERITY() AS VARCHAR(10)) + '; ';
            SET @ErrorST = CAST(ERROR_STATE() AS VARCHAR(10)) + '; ';
            SET @ErrorMG = ERROR_MESSAGE();
            EXEC [dbo].[spAddTbl_Exceptionloggingtodatabase] 
                 0, 
                 @ErrorMG, 
                 @ErrorSE, 
                 @ErrorST, 
                 @ErrorNO, 
                 NULL;
        END CATCH;
        IF @@TRANCOUNT > 0
            COMMIT TRANSACTION;
    END;
	GO
DROP PROCEDURE [dbo].[spDeleteRegion];
	GO
CREATE PROCEDURE [dbo].[spDeleteRegion](@Regionid INT)
AS
    BEGIN
        BEGIN TRANSACTION;
        BEGIN TRY
            DELETE FROM [Region]
            WHERE Regionid = @Regionid;
        END TRY
        BEGIN CATCH
            --SELECT ERROR_NUMBER() AS ErrorNumber, 
            --       ERROR_SEVERITY() AS ErrorSeverity, 
            --       ERROR_STATE() AS ErrorState, 
            --       ERROR_PROCEDURE() AS ErrorProcedure, 
            --       ERROR_LINE() AS ErrorLine, 
            --       ERROR_MESSAGE() AS ErrorMessage;

            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION;
            DECLARE @ErrorNO VARCHAR(50);
            DECLARE @ErrorSE VARCHAR(10);
            DECLARE @ErrorST VARCHAR(10);
            DECLARE @ErrorMG VARCHAR(MAX);
            SET @ErrorNO = 'Error Number: ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '; ' + 'Error Line: ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '; ';
            SET @ErrorSE = CAST(ERROR_SEVERITY() AS VARCHAR(10)) + '; ';
            SET @ErrorST = CAST(ERROR_STATE() AS VARCHAR(10)) + '; ';
            SET @ErrorMG = ERROR_MESSAGE();
            EXEC [dbo].[spAddTbl_Exceptionloggingtodatabase] 
                 0, 
                 @ErrorMG, 
                 @ErrorSE, 
                 @ErrorST, 
                 @ErrorNO, 
                 NULL;
        END CATCH;
        IF @@TRANCOUNT > 0
            COMMIT TRANSACTION;
    END;
	GO
DROP VIEW [dbo].[vwRegion];
	GO
CREATE VIEW [dbo].[vwRegion]
AS
     SELECT RegionID, 
            RegionDescription
     FROM [Region];
	GO
DROP PROCEDURE [dbo].[spGetAllShippers];
	GO
CREATE PROCEDURE [dbo].[spGetAllShippers]
AS
    BEGIN
        SELECT Shipperid, 
               Companyname, 
               Phone
        FROM [Shippers];
    END;
	GO
DROP PROCEDURE [dbo].[spAddShippers];
	GO
CREATE PROCEDURE [dbo].[spAddShippers]
(@Shipperid   INT          = 0, 
 @Companyname NVARCHAR(40) = '', 
 @Phone       NVARCHAR(24) = NULL
)
AS
    BEGIN
        BEGIN TRANSACTION;
        BEGIN TRY
            INSERT INTO [Shippers]
            (
            --[Shipperid]
            [Companyname], 
            [Phone]
            )
            VALUES
            (
            --@Shipperid
            @Companyname, 
            @Phone
            );
        END TRY
        BEGIN CATCH
            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION;
            DECLARE @ErrorNO VARCHAR(50);
            DECLARE @ErrorSE VARCHAR(10);
            DECLARE @ErrorST VARCHAR(10);
            DECLARE @ErrorMG VARCHAR(MAX);
            SET @ErrorNO = 'Error Number: ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '; ' + 'Error Line: ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '; ';
            SET @ErrorSE = CAST(ERROR_SEVERITY() AS VARCHAR(10)) + '; ';
            SET @ErrorST = CAST(ERROR_STATE() AS VARCHAR(10)) + '; ';
            SET @ErrorMG = ERROR_MESSAGE();
            EXEC [dbo].[spAddTbl_Exceptionloggingtodatabase] 
                 0, 
                 @ErrorMG, 
                 @ErrorSE, 
                 @ErrorST, 
                 @ErrorNO, 
                 NULL;
        END CATCH;
        IF @@TRANCOUNT > 0
            COMMIT TRANSACTION;
    END;
	GO
DROP PROCEDURE [dbo].[spUpdateShippers];
	GO
CREATE PROCEDURE [dbo].[spUpdateShippers]
(@Shipperid   INT          = 0, 
 @Companyname NVARCHAR(40) = '', 
 @Phone       NVARCHAR(24) = NULL
)
AS
    BEGIN
        BEGIN TRANSACTION;
        BEGIN TRY
            UPDATE [Shippers]
              SET 
                  Companyname = @Companyname, 
                  Phone = @Phone
            WHERE Shipperid = @Shipperid;
        END TRY
        BEGIN CATCH
            --SELECT ERROR_NUMBER() AS ErrorNumber, 
            --       ERROR_SEVERITY() AS ErrorSeverity, 
            --       ERROR_STATE() AS ErrorState, 
            --       ERROR_PROCEDURE() AS ErrorProcedure, 
            --       ERROR_LINE() AS ErrorLine, 
            --       ERROR_MESSAGE() AS ErrorMessage;

            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION;
            DECLARE @ErrorNO VARCHAR(50);
            DECLARE @ErrorSE VARCHAR(10);
            DECLARE @ErrorST VARCHAR(10);
            DECLARE @ErrorMG VARCHAR(MAX);
            SET @ErrorNO = 'Error Number: ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '; ' + 'Error Line: ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '; ';
            SET @ErrorSE = CAST(ERROR_SEVERITY() AS VARCHAR(10)) + '; ';
            SET @ErrorST = CAST(ERROR_STATE() AS VARCHAR(10)) + '; ';
            SET @ErrorMG = ERROR_MESSAGE();
            EXEC [dbo].[spAddTbl_Exceptionloggingtodatabase] 
                 0, 
                 @ErrorMG, 
                 @ErrorSE, 
                 @ErrorST, 
                 @ErrorNO, 
                 NULL;
        END CATCH;
        IF @@TRANCOUNT > 0
            COMMIT TRANSACTION;
    END;
	GO
DROP PROCEDURE [dbo].[spDeleteShippers];
	GO
CREATE PROCEDURE [dbo].[spDeleteShippers](@Shipperid INT)
AS
    BEGIN
        BEGIN TRANSACTION;
        BEGIN TRY
            DELETE FROM [Shippers]
            WHERE Shipperid = @Shipperid;
        END TRY
        BEGIN CATCH
            --SELECT ERROR_NUMBER() AS ErrorNumber, 
            --       ERROR_SEVERITY() AS ErrorSeverity, 
            --       ERROR_STATE() AS ErrorState, 
            --       ERROR_PROCEDURE() AS ErrorProcedure, 
            --       ERROR_LINE() AS ErrorLine, 
            --       ERROR_MESSAGE() AS ErrorMessage;

            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION;
            DECLARE @ErrorNO VARCHAR(50);
            DECLARE @ErrorSE VARCHAR(10);
            DECLARE @ErrorST VARCHAR(10);
            DECLARE @ErrorMG VARCHAR(MAX);
            SET @ErrorNO = 'Error Number: ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '; ' + 'Error Line: ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '; ';
            SET @ErrorSE = CAST(ERROR_SEVERITY() AS VARCHAR(10)) + '; ';
            SET @ErrorST = CAST(ERROR_STATE() AS VARCHAR(10)) + '; ';
            SET @ErrorMG = ERROR_MESSAGE();
            EXEC [dbo].[spAddTbl_Exceptionloggingtodatabase] 
                 0, 
                 @ErrorMG, 
                 @ErrorSE, 
                 @ErrorST, 
                 @ErrorNO, 
                 NULL;
        END CATCH;
        IF @@TRANCOUNT > 0
            COMMIT TRANSACTION;
    END;
	GO
DROP VIEW [dbo].[vwShippers];
	GO
CREATE VIEW [dbo].[vwShippers]
AS
     SELECT ShipperID, 
            CompanyName, 
            Phone
     FROM [Shippers];
	GO
DROP PROCEDURE [dbo].[spGetAllSuppliers];
	GO
CREATE PROCEDURE [dbo].[spGetAllSuppliers]
AS
    BEGIN
        SELECT Supplierid, 
               Companyname, 
               Contactname, 
               Contacttitle, 
               Address, 
               City, 
               Region, 
               Postalcode, 
               Country, 
               Phone, 
               Fax, 
               Homepage
        FROM [Suppliers];
    END;
	GO
DROP PROCEDURE [dbo].[spAddSuppliers];
	GO
CREATE PROCEDURE [dbo].[spAddSuppliers]
(@Supplierid   INT          = 0, 
 @Companyname  NVARCHAR(40) = '', 
 @Contactname  NVARCHAR(30) = NULL, 
 @Contacttitle NVARCHAR(30) = NULL, 
 @Address      NVARCHAR(60) = NULL, 
 @City         NVARCHAR(15) = NULL, 
 @Region       NVARCHAR(15) = NULL, 
 @Postalcode   NVARCHAR(10) = NULL, 
 @Country      NVARCHAR(15) = NULL, 
 @Phone        NVARCHAR(24) = NULL, 
 @Fax          NVARCHAR(24) = NULL, 
 @Homepage     NTEXT        = ''
)
AS
    BEGIN
        BEGIN TRANSACTION;
        BEGIN TRY
            INSERT INTO [Suppliers]
            (
            --[Supplierid]
            [Companyname], 
            [Contactname], 
            [Contacttitle], 
            [Address], 
            [City], 
            [Region], 
            [Postalcode], 
            [Country], 
            [Phone], 
            [Fax], 
            [Homepage]
            )
            VALUES
            (
            --@Supplierid
            @Companyname, 
            @Contactname, 
            @Contacttitle, 
            @Address, 
            @City, 
            @Region, 
            @Postalcode, 
            @Country, 
            @Phone, 
            @Fax, 
            @Homepage
            );
        END TRY
        BEGIN CATCH
            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION;
            DECLARE @ErrorNO VARCHAR(50);
            DECLARE @ErrorSE VARCHAR(10);
            DECLARE @ErrorST VARCHAR(10);
            DECLARE @ErrorMG VARCHAR(MAX);
            SET @ErrorNO = 'Error Number: ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '; ' + 'Error Line: ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '; ';
            SET @ErrorSE = CAST(ERROR_SEVERITY() AS VARCHAR(10)) + '; ';
            SET @ErrorST = CAST(ERROR_STATE() AS VARCHAR(10)) + '; ';
            SET @ErrorMG = ERROR_MESSAGE();
            EXEC [dbo].[spAddTbl_Exceptionloggingtodatabase] 
                 0, 
                 @ErrorMG, 
                 @ErrorSE, 
                 @ErrorST, 
                 @ErrorNO, 
                 NULL;
        END CATCH;
        IF @@TRANCOUNT > 0
            COMMIT TRANSACTION;
    END;
	GO
DROP PROCEDURE [dbo].[spUpdateSuppliers];
	GO
CREATE PROCEDURE [dbo].[spUpdateSuppliers]
(@Supplierid   INT          = 0, 
 @Companyname  NVARCHAR(40) = '', 
 @Contactname  NVARCHAR(30) = NULL, 
 @Contacttitle NVARCHAR(30) = NULL, 
 @Address      NVARCHAR(60) = NULL, 
 @City         NVARCHAR(15) = NULL, 
 @Region       NVARCHAR(15) = NULL, 
 @Postalcode   NVARCHAR(10) = NULL, 
 @Country      NVARCHAR(15) = NULL, 
 @Phone        NVARCHAR(24) = NULL, 
 @Fax          NVARCHAR(24) = NULL, 
 @Homepage     NTEXT        = NULL
)
AS
    BEGIN
        BEGIN TRANSACTION;
        BEGIN TRY
            UPDATE [Suppliers]
              SET 
                  Companyname = @Companyname, 
                  Contactname = @Contactname, 
                  Contacttitle = @Contacttitle, 
                  Address = @Address, 
                  City = @City, 
                  Region = @Region, 
                  Postalcode = @Postalcode, 
                  Country = @Country, 
                  Phone = @Phone, 
                  Fax = @Fax, 
                  Homepage = @Homepage
            WHERE Supplierid = @Supplierid;
        END TRY
        BEGIN CATCH
            --SELECT ERROR_NUMBER() AS ErrorNumber, 
            --       ERROR_SEVERITY() AS ErrorSeverity, 
            --       ERROR_STATE() AS ErrorState, 
            --       ERROR_PROCEDURE() AS ErrorProcedure, 
            --       ERROR_LINE() AS ErrorLine, 
            --       ERROR_MESSAGE() AS ErrorMessage;

            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION;
            DECLARE @ErrorNO VARCHAR(50);
            DECLARE @ErrorSE VARCHAR(10);
            DECLARE @ErrorST VARCHAR(10);
            DECLARE @ErrorMG VARCHAR(MAX);
            SET @ErrorNO = 'Error Number: ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '; ' + 'Error Line: ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '; ';
            SET @ErrorSE = CAST(ERROR_SEVERITY() AS VARCHAR(10)) + '; ';
            SET @ErrorST = CAST(ERROR_STATE() AS VARCHAR(10)) + '; ';
            SET @ErrorMG = ERROR_MESSAGE();
            EXEC [dbo].[spAddTbl_Exceptionloggingtodatabase] 
                 0, 
                 @ErrorMG, 
                 @ErrorSE, 
                 @ErrorST, 
                 @ErrorNO, 
                 NULL;
        END CATCH;
        IF @@TRANCOUNT > 0
            COMMIT TRANSACTION;
    END;
	GO
DROP PROCEDURE [dbo].[spDeleteSuppliers];
	GO
CREATE PROCEDURE [dbo].[spDeleteSuppliers](@Supplierid INT)
AS
    BEGIN
        BEGIN TRANSACTION;
        BEGIN TRY
            DELETE FROM [Suppliers]
            WHERE Supplierid = @Supplierid;
        END TRY
        BEGIN CATCH
            --SELECT ERROR_NUMBER() AS ErrorNumber, 
            --       ERROR_SEVERITY() AS ErrorSeverity, 
            --       ERROR_STATE() AS ErrorState, 
            --       ERROR_PROCEDURE() AS ErrorProcedure, 
            --       ERROR_LINE() AS ErrorLine, 
            --       ERROR_MESSAGE() AS ErrorMessage;

            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION;
            DECLARE @ErrorNO VARCHAR(50);
            DECLARE @ErrorSE VARCHAR(10);
            DECLARE @ErrorST VARCHAR(10);
            DECLARE @ErrorMG VARCHAR(MAX);
            SET @ErrorNO = 'Error Number: ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '; ' + 'Error Line: ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '; ';
            SET @ErrorSE = CAST(ERROR_SEVERITY() AS VARCHAR(10)) + '; ';
            SET @ErrorST = CAST(ERROR_STATE() AS VARCHAR(10)) + '; ';
            SET @ErrorMG = ERROR_MESSAGE();
            EXEC [dbo].[spAddTbl_Exceptionloggingtodatabase] 
                 0, 
                 @ErrorMG, 
                 @ErrorSE, 
                 @ErrorST, 
                 @ErrorNO, 
                 NULL;
        END CATCH;
        IF @@TRANCOUNT > 0
            COMMIT TRANSACTION;
    END;
	GO
DROP VIEW [dbo].[vwSuppliers];
	GO
CREATE VIEW [dbo].[vwSuppliers]
AS
     SELECT SupplierID, 
            CompanyName, 
            ContactName, 
            ContactTitle, 
            Address, 
            City, 
            Region, 
            PostalCode, 
            Country, 
            Phone, 
            Fax, 
            HomePage
     FROM [Suppliers];
	GO
DROP PROCEDURE [dbo].[spGetAllTbl_Exceptionloggingtodatabase];
	GO
CREATE PROCEDURE [dbo].[spGetAllTbl_Exceptionloggingtodatabase]
AS
    BEGIN
        SELECT Logid, 
               Exceptionmsg, 
               Exceptiontype, 
               Exceptionsource, 
               Exceptionurl, 
               Logdate
        FROM [tbl_ExceptionLoggingToDataBase];
    END;
	GO
DROP PROCEDURE [dbo].[spAddTbl_Exceptionloggingtodatabase];
	GO
CREATE PROCEDURE [dbo].[spAddTbl_Exceptionloggingtodatabase]
(@Logid           BIGINT        = 0, 
 @Exceptionmsg    VARCHAR(100)  = NULL, 
 @Exceptiontype   VARCHAR(100)  = NULL, 
 @Exceptionsource NVARCHAR(MAX) = NULL, 
 @Exceptionurl    VARCHAR(100)  = NULL, 
 @Logdate         DATETIME      = NULL
)
AS
    BEGIN
        BEGIN TRANSACTION;
        BEGIN TRY
            INSERT INTO [tbl_ExceptionLoggingToDataBase]
            (
            --[Logid]
            [Exceptionmsg], 
            [Exceptiontype], 
            [Exceptionsource], 
            [Exceptionurl], 
            [Logdate]
            )
            VALUES
            (
            --@Logid
            @Exceptionmsg, 
            @Exceptiontype, 
            @Exceptionsource, 
            @Exceptionurl, 
            GETDATE()
            );
        END TRY
        BEGIN CATCH
            SELECT ERROR_NUMBER() AS ErrorNumber, 
                   ERROR_SEVERITY() AS ErrorSeverity, 
                   ERROR_STATE() AS ErrorState, 
                   ERROR_PROCEDURE() AS ErrorProcedure, 
                   ERROR_LINE() AS ErrorLine, 
                   ERROR_MESSAGE() AS ErrorMessage;
            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION;
        END CATCH;
        IF @@TRANCOUNT > 0
            COMMIT TRANSACTION;
    END;
	GO
DROP PROCEDURE [dbo].[spUpdateTbl_Exceptionloggingtodatabase];
	GO
CREATE PROCEDURE [dbo].[spUpdateTbl_Exceptionloggingtodatabase]
(@Logid           BIGINT        = 0, 
 @Exceptionmsg    VARCHAR(100)  = NULL, 
 @Exceptiontype   VARCHAR(100)  = NULL, 
 @Exceptionsource NVARCHAR(MAX) = NULL, 
 @Exceptionurl    VARCHAR(100)  = NULL, 
 @Logdate         DATETIME      = NULL
)
AS
    BEGIN
        BEGIN TRANSACTION;
        BEGIN TRY
            UPDATE [tbl_ExceptionLoggingToDataBase]
              SET 
                  Exceptionmsg = @Exceptionmsg, 
                  Exceptiontype = @Exceptiontype, 
                  Exceptionsource = @Exceptionsource, 
                  Exceptionurl = @Exceptionurl, 
                  Logdate = @Logdate
            WHERE Logid = @Logid;
        END TRY
        BEGIN CATCH
            --SELECT ERROR_NUMBER() AS ErrorNumber, 
            --       ERROR_SEVERITY() AS ErrorSeverity, 
            --       ERROR_STATE() AS ErrorState, 
            --       ERROR_PROCEDURE() AS ErrorProcedure, 
            --       ERROR_LINE() AS ErrorLine, 
            --       ERROR_MESSAGE() AS ErrorMessage;

            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION;
            DECLARE @ErrorNO VARCHAR(50);
            DECLARE @ErrorSE VARCHAR(10);
            DECLARE @ErrorST VARCHAR(10);
            DECLARE @ErrorMG VARCHAR(MAX);
            SET @ErrorNO = 'Error Number: ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '; ' + 'Error Line: ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '; ';
            SET @ErrorSE = CAST(ERROR_SEVERITY() AS VARCHAR(10)) + '; ';
            SET @ErrorST = CAST(ERROR_STATE() AS VARCHAR(10)) + '; ';
            SET @ErrorMG = ERROR_MESSAGE();
            EXEC [dbo].[spAddTbl_Exceptionloggingtodatabase] 
                 0, 
                 @ErrorMG, 
                 @ErrorSE, 
                 @ErrorST, 
                 @ErrorNO, 
                 NULL;
        END CATCH;
        IF @@TRANCOUNT > 0
            COMMIT TRANSACTION;
    END;
	GO
DROP PROCEDURE [dbo].[spDeleteTbl_Exceptionloggingtodatabase];
	GO
CREATE PROCEDURE [dbo].[spDeleteTbl_Exceptionloggingtodatabase](@Logid BIGINT)
AS
    BEGIN
        BEGIN TRANSACTION;
        BEGIN TRY
            DELETE FROM [tbl_ExceptionLoggingToDataBase]
            WHERE Logid = @Logid;
        END TRY
        BEGIN CATCH
            --SELECT ERROR_NUMBER() AS ErrorNumber, 
            --       ERROR_SEVERITY() AS ErrorSeverity, 
            --       ERROR_STATE() AS ErrorState, 
            --       ERROR_PROCEDURE() AS ErrorProcedure, 
            --       ERROR_LINE() AS ErrorLine, 
            --       ERROR_MESSAGE() AS ErrorMessage;

            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION;
            DECLARE @ErrorNO VARCHAR(50);
            DECLARE @ErrorSE VARCHAR(10);
            DECLARE @ErrorST VARCHAR(10);
            DECLARE @ErrorMG VARCHAR(MAX);
            SET @ErrorNO = 'Error Number: ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '; ' + 'Error Line: ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '; ';
            SET @ErrorSE = CAST(ERROR_SEVERITY() AS VARCHAR(10)) + '; ';
            SET @ErrorST = CAST(ERROR_STATE() AS VARCHAR(10)) + '; ';
            SET @ErrorMG = ERROR_MESSAGE();
            EXEC [dbo].[spAddTbl_Exceptionloggingtodatabase] 
                 0, 
                 @ErrorMG, 
                 @ErrorSE, 
                 @ErrorST, 
                 @ErrorNO, 
                 NULL;
        END CATCH;
        IF @@TRANCOUNT > 0
            COMMIT TRANSACTION;
    END;
	GO
DROP VIEW [dbo].[vwTbl_Exceptionloggingtodatabase];
	GO
CREATE VIEW [dbo].[vwTbl_Exceptionloggingtodatabase]
AS
     SELECT Logid, 
            ExceptionMsg, 
            ExceptionType, 
            ExceptionSource, 
            ExceptionURL, 
            Logdate
     FROM [tbl_ExceptionLoggingToDataBase];
	GO
DROP PROCEDURE [dbo].[spGetAllTbl_Login];
	GO
CREATE PROCEDURE [dbo].[spGetAllTbl_Login]
AS
    BEGIN
        SELECT Username, 
               Password, 
               Roles, 
               Activestatus
        FROM [tbl_Login];
    END;
	GO
DROP PROCEDURE [dbo].[spAddTbl_Login];
	GO
CREATE PROCEDURE [dbo].[spAddTbl_Login]
(@Username     NVARCHAR(20)  = '', 
 @Password     NVARCHAR(20)  = '', 
 @Roles        NVARCHAR(500) = '', 
 @Activestatus BIT           = NULL
)
AS
    BEGIN
        BEGIN TRANSACTION;
        BEGIN TRY
            INSERT INTO [tbl_Login]
            ([Username], 
             [Password], 
             [Roles], 
             [Activestatus]
            )
            VALUES
            (@Username, 
             @Password, 
             @Roles, 
             @Activestatus
            );
        END TRY
        BEGIN CATCH
            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION;
            DECLARE @ErrorNO VARCHAR(50);
            DECLARE @ErrorSE VARCHAR(10);
            DECLARE @ErrorST VARCHAR(10);
            DECLARE @ErrorMG VARCHAR(MAX);
            SET @ErrorNO = 'Error Number: ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '; ' + 'Error Line: ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '; ';
            SET @ErrorSE = CAST(ERROR_SEVERITY() AS VARCHAR(10)) + '; ';
            SET @ErrorST = CAST(ERROR_STATE() AS VARCHAR(10)) + '; ';
            SET @ErrorMG = ERROR_MESSAGE();
            EXEC [dbo].[spAddTbl_Exceptionloggingtodatabase] 
                 0, 
                 @ErrorMG, 
                 @ErrorSE, 
                 @ErrorST, 
                 @ErrorNO, 
                 NULL;
        END CATCH;
        IF @@TRANCOUNT > 0
            COMMIT TRANSACTION;
    END;
	GO
DROP PROCEDURE [dbo].[spUpdateTbl_Login];
	GO
CREATE PROCEDURE [dbo].[spUpdateTbl_Login]
(@Username     NVARCHAR(20)  = '', 
 @Password     NVARCHAR(20)  = '', 
 @Roles        NVARCHAR(500) = '', 
 @Activestatus BIT           = NULL
)
AS
    BEGIN
        BEGIN TRANSACTION;
        BEGIN TRY
            UPDATE [tbl_Login]
              SET 
                  Password = @Password, 
                  Roles = @Roles, 
                  Activestatus = @Activestatus
            WHERE Username = @Username;
        END TRY
        BEGIN CATCH
            --SELECT ERROR_NUMBER() AS ErrorNumber, 
            --       ERROR_SEVERITY() AS ErrorSeverity, 
            --       ERROR_STATE() AS ErrorState, 
            --       ERROR_PROCEDURE() AS ErrorProcedure, 
            --       ERROR_LINE() AS ErrorLine, 
            --       ERROR_MESSAGE() AS ErrorMessage;

            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION;
            DECLARE @ErrorNO VARCHAR(50);
            DECLARE @ErrorSE VARCHAR(10);
            DECLARE @ErrorST VARCHAR(10);
            DECLARE @ErrorMG VARCHAR(MAX);
            SET @ErrorNO = 'Error Number: ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '; ' + 'Error Line: ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '; ';
            SET @ErrorSE = CAST(ERROR_SEVERITY() AS VARCHAR(10)) + '; ';
            SET @ErrorST = CAST(ERROR_STATE() AS VARCHAR(10)) + '; ';
            SET @ErrorMG = ERROR_MESSAGE();
            EXEC [dbo].[spAddTbl_Exceptionloggingtodatabase] 
                 0, 
                 @ErrorMG, 
                 @ErrorSE, 
                 @ErrorST, 
                 @ErrorNO, 
                 NULL;
        END CATCH;
        IF @@TRANCOUNT > 0
            COMMIT TRANSACTION;
    END;
	GO
DROP PROCEDURE [dbo].[spDeleteTbl_Login];
	GO
CREATE PROCEDURE [dbo].[spDeleteTbl_Login](@Username NVARCHAR(20))
AS
    BEGIN
        BEGIN TRANSACTION;
        BEGIN TRY
            DELETE FROM [tbl_Login]
            WHERE Username = @Username;
        END TRY
        BEGIN CATCH
            --SELECT ERROR_NUMBER() AS ErrorNumber, 
            --       ERROR_SEVERITY() AS ErrorSeverity, 
            --       ERROR_STATE() AS ErrorState, 
            --       ERROR_PROCEDURE() AS ErrorProcedure, 
            --       ERROR_LINE() AS ErrorLine, 
            --       ERROR_MESSAGE() AS ErrorMessage;

            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION;
            DECLARE @ErrorNO VARCHAR(50);
            DECLARE @ErrorSE VARCHAR(10);
            DECLARE @ErrorST VARCHAR(10);
            DECLARE @ErrorMG VARCHAR(MAX);
            SET @ErrorNO = 'Error Number: ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '; ' + 'Error Line: ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '; ';
            SET @ErrorSE = CAST(ERROR_SEVERITY() AS VARCHAR(10)) + '; ';
            SET @ErrorST = CAST(ERROR_STATE() AS VARCHAR(10)) + '; ';
            SET @ErrorMG = ERROR_MESSAGE();
            EXEC [dbo].[spAddTbl_Exceptionloggingtodatabase] 
                 0, 
                 @ErrorMG, 
                 @ErrorSE, 
                 @ErrorST, 
                 @ErrorNO, 
                 NULL;
        END CATCH;
        IF @@TRANCOUNT > 0
            COMMIT TRANSACTION;
    END;
	GO
DROP VIEW [dbo].[vwTbl_Login];
	GO
CREATE VIEW [dbo].[vwTbl_Login]
AS
     SELECT Username, 
            Password, 
            Roles, 
            ActiveStatus
     FROM [tbl_Login];
	GO
DROP PROCEDURE [dbo].[spGetAllTerritories];
	GO
CREATE PROCEDURE [dbo].[spGetAllTerritories]
AS
    BEGIN
        SELECT Territoryid, 
               Territorydescription, 
               Regionid
        FROM [Territories];
    END;
	GO
DROP PROCEDURE [dbo].[spAddTerritories];
	GO
CREATE PROCEDURE [dbo].[spAddTerritories]
(@Territoryid          NVARCHAR(20) = '', 
 @Territorydescription NCHAR(50)    = '', 
 @Regionid             INT          = 0
)
AS
    BEGIN
        BEGIN TRANSACTION;
        BEGIN TRY
            INSERT INTO [Territories]
            ([Territoryid], 
             [Territorydescription], 
             [Regionid]
            )
            VALUES
            (@Territoryid, 
             @Territorydescription, 
             @Regionid
            );
        END TRY
        BEGIN CATCH
            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION;
            DECLARE @ErrorNO VARCHAR(50);
            DECLARE @ErrorSE VARCHAR(10);
            DECLARE @ErrorST VARCHAR(10);
            DECLARE @ErrorMG VARCHAR(MAX);
            SET @ErrorNO = 'Error Number: ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '; ' + 'Error Line: ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '; ';
            SET @ErrorSE = CAST(ERROR_SEVERITY() AS VARCHAR(10)) + '; ';
            SET @ErrorST = CAST(ERROR_STATE() AS VARCHAR(10)) + '; ';
            SET @ErrorMG = ERROR_MESSAGE();
            EXEC [dbo].[spAddTbl_Exceptionloggingtodatabase] 
                 0, 
                 @ErrorMG, 
                 @ErrorSE, 
                 @ErrorST, 
                 @ErrorNO, 
                 NULL;
        END CATCH;
        IF @@TRANCOUNT > 0
            COMMIT TRANSACTION;
    END;
	GO
DROP PROCEDURE [dbo].[spUpdateTerritories];
	GO
CREATE PROCEDURE [dbo].[spUpdateTerritories]
(@Territoryid          NVARCHAR(20) = '', 
 @Territorydescription NCHAR(50)    = '', 
 @Regionid             INT          = 0
)
AS
    BEGIN
        BEGIN TRANSACTION;
        BEGIN TRY
            UPDATE [Territories]
              SET 
                  Territorydescription = @Territorydescription, 
                  Regionid = @Regionid
            WHERE Territoryid = @Territoryid;
        END TRY
        BEGIN CATCH
            --SELECT ERROR_NUMBER() AS ErrorNumber, 
            --       ERROR_SEVERITY() AS ErrorSeverity, 
            --       ERROR_STATE() AS ErrorState, 
            --       ERROR_PROCEDURE() AS ErrorProcedure, 
            --       ERROR_LINE() AS ErrorLine, 
            --       ERROR_MESSAGE() AS ErrorMessage;

            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION;
            DECLARE @ErrorNO VARCHAR(50);
            DECLARE @ErrorSE VARCHAR(10);
            DECLARE @ErrorST VARCHAR(10);
            DECLARE @ErrorMG VARCHAR(MAX);
            SET @ErrorNO = 'Error Number: ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '; ' + 'Error Line: ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '; ';
            SET @ErrorSE = CAST(ERROR_SEVERITY() AS VARCHAR(10)) + '; ';
            SET @ErrorST = CAST(ERROR_STATE() AS VARCHAR(10)) + '; ';
            SET @ErrorMG = ERROR_MESSAGE();
            EXEC [dbo].[spAddTbl_Exceptionloggingtodatabase] 
                 0, 
                 @ErrorMG, 
                 @ErrorSE, 
                 @ErrorST, 
                 @ErrorNO, 
                 NULL;
        END CATCH;
        IF @@TRANCOUNT > 0
            COMMIT TRANSACTION;
    END;
	GO
DROP PROCEDURE [dbo].[spDeleteTerritories];
	GO
CREATE PROCEDURE [dbo].[spDeleteTerritories](@Territoryid NVARCHAR(20))
AS
    BEGIN
        BEGIN TRANSACTION;
        BEGIN TRY
            DELETE FROM [Territories]
            WHERE Territoryid = @Territoryid;
        END TRY
        BEGIN CATCH
            --SELECT ERROR_NUMBER() AS ErrorNumber, 
            --       ERROR_SEVERITY() AS ErrorSeverity, 
            --       ERROR_STATE() AS ErrorState, 
            --       ERROR_PROCEDURE() AS ErrorProcedure, 
            --       ERROR_LINE() AS ErrorLine, 
            --       ERROR_MESSAGE() AS ErrorMessage;

            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION;
            DECLARE @ErrorNO VARCHAR(50);
            DECLARE @ErrorSE VARCHAR(10);
            DECLARE @ErrorST VARCHAR(10);
            DECLARE @ErrorMG VARCHAR(MAX);
            SET @ErrorNO = 'Error Number: ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '; ' + 'Error Line: ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '; ';
            SET @ErrorSE = CAST(ERROR_SEVERITY() AS VARCHAR(10)) + '; ';
            SET @ErrorST = CAST(ERROR_STATE() AS VARCHAR(10)) + '; ';
            SET @ErrorMG = ERROR_MESSAGE();
            EXEC [dbo].[spAddTbl_Exceptionloggingtodatabase] 
                 0, 
                 @ErrorMG, 
                 @ErrorSE, 
                 @ErrorST, 
                 @ErrorNO, 
                 NULL;
        END CATCH;
        IF @@TRANCOUNT > 0
            COMMIT TRANSACTION;
    END;
	GO
DROP VIEW [dbo].[vwTerritories];
	GO
CREATE VIEW [dbo].[vwTerritories]
AS
     SELECT TerritoryID, 
            TerritoryDescription, 
            RegionID
     FROM [Territories];
	GO