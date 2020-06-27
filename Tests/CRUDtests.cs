



using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Tests.BaseClass;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using System;

namespace Tests
{
    [TestFixture]
    public class CRUDClass : BaseTest
    {
        [Test, Order(1), Category("CRUD Testing")]
        public void TestMethodCreate_aMaster_categories()
        {
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Tbl_Login/Login");
            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Categories/Create");

            IWebElement CategoryNameTextField = local_driver.FindElement(By.XPath(".//*[@id='CategoryName']"));
            CategoryNameTextField.Clear();
            CategoryNameTextField.SendKeys("c");
            IWebElement DescriptionTextField = local_driver.FindElement(By.XPath(".//*[@id='Description']"));
            DescriptionTextField.Clear();
            DescriptionTextField.SendKeys("Hello World!");
            IWebElement PictureTextField = local_driver.FindElement(By.XPath(".//*[@id='Picture']"));
            PictureTextField.SendKeys("0x424d42000000000000003e0000002800000001000000010000000100010000000000040000000000000000000000000000000000000000000000ffffff00800000000000000000000000000000000000000000000000000000000");

            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();

            Thread.Sleep(5000);
        }
        [Test, Order(3), Category("CRUD Testing")]
        public void TestMethodRead_categories()
        {

            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Tbl_Login/Login");
            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Categories/Details?CategoryID=999");

            Thread.Sleep(5000);
        }
        [Test, Order(3), Category("CRUD Testing")]
        public void TestMethodUpdate_categories()
        {

            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Tbl_Login/Login");
            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Categories/Edit?CategoryID=999");

            IWebElement CategoryNameTextField = local_driver.FindElement(By.XPath(".//*[@id='Categories_CategoryName']"));
            CategoryNameTextField.Clear();
            CategoryNameTextField.SendKeys("abc");
            IWebElement DescriptionTextField = local_driver.FindElement(By.XPath(".//*[@id='Categories_Description']"));
            DescriptionTextField.Clear();
            DescriptionTextField.SendKeys("Hello World!");
            IWebElement PictureTextField = local_driver.FindElement(By.XPath(".//*[@id='Categories_Picture']"));
            PictureTextField.Clear();
            PictureTextField.SendKeys("0x424d42000000000000003e0000002800000001000000010000000100010000000000040000000000000000000000000000000000000000000000ffffff00800000000000000000000000000000000000000000000000000000000");

            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            Thread.Sleep(5000);
        }
        [Test, Order(3), Category("CRUD Testing")]
        public void TestMethodDelete_categories()
        {
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Tbl_Login/Login");
            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Categories/Delete?CategoryID=999");

            Thread.Sleep(5000);

            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
        }
        [Test, Order(2), Category("CRUD Testing")]
        public void TestMethodCreate_bDetail_customercustomerdemo()
        {
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Tbl_Login/Login");
            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Customercustomerdemo/Create");

            IWebElement CustomerIDTextField = local_driver.FindElement(By.XPath(".//*[@id='CustomerID']"));
            CustomerIDTextField.Clear();
            CustomerIDTextField.SendKeys("999");
            IWebElement CustomerTypeIDTextField = local_driver.FindElement(By.XPath(".//*[@id='CustomerTypeID']"));
            CustomerTypeIDTextField.Clear();
            CustomerTypeIDTextField.SendKeys("999");

            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();

            Thread.Sleep(5000);
        }
        [Test, Order(3), Category("CRUD Testing")]
        public void TestMethodRead_customercustomerdemo()
        {

            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Tbl_Login/Login");
            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Customercustomerdemo/Details?CustomerTypeID=999");

            Thread.Sleep(5000);
        }
        [Test, Order(3), Category("CRUD Testing")]
        public void TestMethodUpdate_customercustomerdemo()
        {

            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Tbl_Login/Login");
            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Customercustomerdemo/Edit?CustomerTypeID=999");

            IWebElement CustomerIDTextField = local_driver.FindElement(By.XPath(".//*[@id='Customercustomerdemo_CustomerID']"));
            CustomerIDTextField.Clear();
            CustomerIDTextField.SendKeys("999");
            IWebElement CustomerTypeIDTextField = local_driver.FindElement(By.XPath(".//*[@id='Customercustomerdemo_CustomerTypeID']"));
            CustomerTypeIDTextField.Clear();
            CustomerTypeIDTextField.SendKeys("999");

            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            Thread.Sleep(5000);
        }
        [Test, Order(3), Category("CRUD Testing")]
        public void TestMethodDelete_customercustomerdemo()
        {
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Tbl_Login/Login");
            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Customercustomerdemo/Delete?CustomerTypeID=999");

            Thread.Sleep(5000);

            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
        }
        [Test, Order(1), Category("CRUD Testing")]
        public void TestMethodCreate_aMaster_customerdemographics()
        {
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Tbl_Login/Login");
            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Customerdemographics/Create");

            IWebElement CustomerTypeIDTextField = local_driver.FindElement(By.XPath(".//*[@id='CustomerTypeID']"));
            CustomerTypeIDTextField.Clear();
            CustomerTypeIDTextField.SendKeys("999");
            IWebElement CustomerDescTextField = local_driver.FindElement(By.XPath(".//*[@id='CustomerDesc']"));
            CustomerDescTextField.Clear();
            CustomerDescTextField.SendKeys("Hello World!");

            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();

            Thread.Sleep(5000);
        }
        [Test, Order(3), Category("CRUD Testing")]
        public void TestMethodRead_customerdemographics()
        {

            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Tbl_Login/Login");
            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Customerdemographics/Details?CustomerTypeID=999");

            Thread.Sleep(5000);
        }
        [Test, Order(3), Category("CRUD Testing")]
        public void TestMethodUpdate_customerdemographics()
        {

            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Tbl_Login/Login");
            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Customerdemographics/Edit?CustomerTypeID=999");

            IWebElement CustomerTypeIDTextField = local_driver.FindElement(By.XPath(".//*[@id='Customerdemographics_CustomerTypeID']"));
            CustomerTypeIDTextField.Clear();
            CustomerTypeIDTextField.SendKeys("999");
            IWebElement CustomerDescTextField = local_driver.FindElement(By.XPath(".//*[@id='Customerdemographics_CustomerDesc']"));
            CustomerDescTextField.Clear();
            CustomerDescTextField.SendKeys("Hello World!");

            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            Thread.Sleep(5000);
        }
        [Test, Order(3), Category("CRUD Testing")]
        public void TestMethodDelete_customerdemographics()
        {
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Tbl_Login/Login");
            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Customerdemographics/Delete?CustomerTypeID=999");

            Thread.Sleep(5000);

            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
        }
        [Test, Order(1), Category("CRUD Testing")]
        public void TestMethodCreate_aMaster_customers()
        {
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Tbl_Login/Login");
            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Customers/Create");

            IWebElement CustomerIDTextField = local_driver.FindElement(By.XPath(".//*[@id='CustomerID']"));
            CustomerIDTextField.Clear();
            CustomerIDTextField.SendKeys("999");
            IWebElement CompanyNameTextField = local_driver.FindElement(By.XPath(".//*[@id='CompanyName']"));
            CompanyNameTextField.Clear();
            CompanyNameTextField.SendKeys("c");
            IWebElement ContactNameTextField = local_driver.FindElement(By.XPath(".//*[@id='ContactName']"));
            ContactNameTextField.Clear();
            ContactNameTextField.SendKeys("c");
            IWebElement ContactTitleTextField = local_driver.FindElement(By.XPath(".//*[@id='ContactTitle']"));
            ContactTitleTextField.Clear();
            ContactTitleTextField.SendKeys("c");
            IWebElement AddressTextField = local_driver.FindElement(By.XPath(".//*[@id='Address']"));
            AddressTextField.Clear();
            AddressTextField.SendKeys("c");
            IWebElement CityTextField = local_driver.FindElement(By.XPath(".//*[@id='City']"));
            CityTextField.Clear();
            CityTextField.SendKeys("c");
            IWebElement RegionTextField = local_driver.FindElement(By.XPath(".//*[@id='Region']"));
            RegionTextField.Clear();
            RegionTextField.SendKeys("c");
            IWebElement PostalCodeTextField = local_driver.FindElement(By.XPath(".//*[@id='PostalCode']"));
            PostalCodeTextField.Clear();
            PostalCodeTextField.SendKeys("c");
            IWebElement CountryTextField = local_driver.FindElement(By.XPath(".//*[@id='Country']"));
            CountryTextField.Clear();
            CountryTextField.SendKeys("c");
            IWebElement PhoneTextField = local_driver.FindElement(By.XPath(".//*[@id='Phone']"));
            PhoneTextField.Clear();
            PhoneTextField.SendKeys("c");
            IWebElement FaxTextField = local_driver.FindElement(By.XPath(".//*[@id='Fax']"));
            FaxTextField.Clear();
            FaxTextField.SendKeys("c");

            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();

            Thread.Sleep(5000);
        }
        [Test, Order(3), Category("CRUD Testing")]
        public void TestMethodRead_customers()
        {

            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Tbl_Login/Login");
            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Customers/Details?CustomerID=999");

            Thread.Sleep(5000);
        }
        [Test, Order(3), Category("CRUD Testing")]
        public void TestMethodUpdate_customers()
        {

            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Tbl_Login/Login");
            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Customers/Edit?CustomerID=999");

            IWebElement CustomerIDTextField = local_driver.FindElement(By.XPath(".//*[@id='Customers_CustomerID']"));
            CustomerIDTextField.Clear();
            CustomerIDTextField.SendKeys("999");
            IWebElement CompanyNameTextField = local_driver.FindElement(By.XPath(".//*[@id='Customers_CompanyName']"));
            CompanyNameTextField.Clear();
            CompanyNameTextField.SendKeys("abc");
            IWebElement ContactNameTextField = local_driver.FindElement(By.XPath(".//*[@id='Customers_ContactName']"));
            ContactNameTextField.Clear();
            ContactNameTextField.SendKeys("abc");
            IWebElement ContactTitleTextField = local_driver.FindElement(By.XPath(".//*[@id='Customers_ContactTitle']"));
            ContactTitleTextField.Clear();
            ContactTitleTextField.SendKeys("abc");
            IWebElement AddressTextField = local_driver.FindElement(By.XPath(".//*[@id='Customers_Address']"));
            AddressTextField.Clear();
            AddressTextField.SendKeys("abc");
            IWebElement CityTextField = local_driver.FindElement(By.XPath(".//*[@id='Customers_City']"));
            CityTextField.Clear();
            CityTextField.SendKeys("abc");
            IWebElement RegionTextField = local_driver.FindElement(By.XPath(".//*[@id='Customers_Region']"));
            RegionTextField.Clear();
            RegionTextField.SendKeys("abc");
            IWebElement PostalCodeTextField = local_driver.FindElement(By.XPath(".//*[@id='Customers_PostalCode']"));
            PostalCodeTextField.Clear();
            PostalCodeTextField.SendKeys("abc");
            IWebElement CountryTextField = local_driver.FindElement(By.XPath(".//*[@id='Customers_Country']"));
            CountryTextField.Clear();
            CountryTextField.SendKeys("abc");
            IWebElement PhoneTextField = local_driver.FindElement(By.XPath(".//*[@id='Customers_Phone']"));
            PhoneTextField.Clear();
            PhoneTextField.SendKeys("abc");
            IWebElement FaxTextField = local_driver.FindElement(By.XPath(".//*[@id='Customers_Fax']"));
            FaxTextField.Clear();
            FaxTextField.SendKeys("abc");

            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            Thread.Sleep(5000);
        }
        [Test, Order(3), Category("CRUD Testing")]
        public void TestMethodDelete_customers()
        {
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Tbl_Login/Login");
            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Customers/Delete?CustomerID=999");

            Thread.Sleep(5000);

            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
        }
        [Test, Order(1), Category("CRUD Testing")]
        public void TestMethodCreate_aMaster_employees()
        {
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Tbl_Login/Login");
            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Employees/Create");

            IWebElement LastNameTextField = local_driver.FindElement(By.XPath(".//*[@id='LastName']"));
            LastNameTextField.Clear();
            LastNameTextField.SendKeys("c");
            IWebElement FirstNameTextField = local_driver.FindElement(By.XPath(".//*[@id='FirstName']"));
            FirstNameTextField.Clear();
            FirstNameTextField.SendKeys("c");
            IWebElement TitleTextField = local_driver.FindElement(By.XPath(".//*[@id='Title']"));
            TitleTextField.Clear();
            TitleTextField.SendKeys("c");
            IWebElement TitleOfCourtesyTextField = local_driver.FindElement(By.XPath(".//*[@id='TitleOfCourtesy']"));
            TitleOfCourtesyTextField.Clear();
            TitleOfCourtesyTextField.SendKeys("c");
            IWebElement BirthDateTextField = local_driver.FindElement(By.XPath(".//*[@id='BirthDate']"));
            BirthDateTextField.Clear();
            BirthDateTextField.SendKeys(DateTime.Today.ToString("d"));
            IWebElement HireDateTextField = local_driver.FindElement(By.XPath(".//*[@id='HireDate']"));
            HireDateTextField.Clear();
            HireDateTextField.SendKeys(DateTime.Today.ToString("d"));
            IWebElement AddressTextField = local_driver.FindElement(By.XPath(".//*[@id='Address']"));
            AddressTextField.Clear();
            AddressTextField.SendKeys("c");
            IWebElement CityTextField = local_driver.FindElement(By.XPath(".//*[@id='City']"));
            CityTextField.Clear();
            CityTextField.SendKeys("c");
            IWebElement RegionTextField = local_driver.FindElement(By.XPath(".//*[@id='Region']"));
            RegionTextField.Clear();
            RegionTextField.SendKeys("c");
            IWebElement PostalCodeTextField = local_driver.FindElement(By.XPath(".//*[@id='PostalCode']"));
            PostalCodeTextField.Clear();
            PostalCodeTextField.SendKeys("c");
            IWebElement CountryTextField = local_driver.FindElement(By.XPath(".//*[@id='Country']"));
            CountryTextField.Clear();
            CountryTextField.SendKeys("c");
            IWebElement HomePhoneTextField = local_driver.FindElement(By.XPath(".//*[@id='HomePhone']"));
            HomePhoneTextField.Clear();
            HomePhoneTextField.SendKeys("c");
            IWebElement ExtensionTextField = local_driver.FindElement(By.XPath(".//*[@id='Extension']"));
            ExtensionTextField.Clear();
            ExtensionTextField.SendKeys("c");
            IWebElement PhotoTextField = local_driver.FindElement(By.XPath(".//*[@id='Photo']"));
            PhotoTextField.SendKeys("0x424d42000000000000003e0000002800000001000000010000000100010000000000040000000000000000000000000000000000000000000000ffffff00800000000000000000000000000000000000000000000000000000000");
            IWebElement NotesTextField = local_driver.FindElement(By.XPath(".//*[@id='Notes']"));
            NotesTextField.Clear();
            NotesTextField.SendKeys("Hello World!");
            IWebElement ReportsToTextField = local_driver.FindElement(By.XPath(".//*[@id='ReportsTo']"));
            ReportsToTextField.Clear();
            ReportsToTextField.SendKeys("1");
            IWebElement PhotoPathTextField = local_driver.FindElement(By.XPath(".//*[@id='PhotoPath']"));
            PhotoPathTextField.Clear();
            PhotoPathTextField.SendKeys("c");

            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();

            Thread.Sleep(5000);
        }
        [Test, Order(3), Category("CRUD Testing")]
        public void TestMethodRead_employees()
        {

            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Tbl_Login/Login");
            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Employees/Details?EmployeeID=999");

            Thread.Sleep(5000);
        }
        [Test, Order(3), Category("CRUD Testing")]
        public void TestMethodUpdate_employees()
        {

            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Tbl_Login/Login");
            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Employees/Edit?EmployeeID=999");

            IWebElement LastNameTextField = local_driver.FindElement(By.XPath(".//*[@id='Employees_LastName']"));
            LastNameTextField.Clear();
            LastNameTextField.SendKeys("abc");
            IWebElement FirstNameTextField = local_driver.FindElement(By.XPath(".//*[@id='Employees_FirstName']"));
            FirstNameTextField.Clear();
            FirstNameTextField.SendKeys("abc");
            IWebElement TitleTextField = local_driver.FindElement(By.XPath(".//*[@id='Employees_Title']"));
            TitleTextField.Clear();
            TitleTextField.SendKeys("abc");
            IWebElement TitleOfCourtesyTextField = local_driver.FindElement(By.XPath(".//*[@id='Employees_TitleOfCourtesy']"));
            TitleOfCourtesyTextField.Clear();
            TitleOfCourtesyTextField.SendKeys("abc");
            IWebElement BirthDateTextField = local_driver.FindElement(By.XPath(".//*[@id='Employees_BirthDate']"));
            BirthDateTextField.Clear();
            BirthDateTextField.SendKeys(DateTime.Today.ToString("d"));
            IWebElement HireDateTextField = local_driver.FindElement(By.XPath(".//*[@id='Employees_HireDate']"));
            HireDateTextField.Clear();
            HireDateTextField.SendKeys(DateTime.Today.ToString("d"));
            IWebElement AddressTextField = local_driver.FindElement(By.XPath(".//*[@id='Employees_Address']"));
            AddressTextField.Clear();
            AddressTextField.SendKeys("abc");
            IWebElement CityTextField = local_driver.FindElement(By.XPath(".//*[@id='Employees_City']"));
            CityTextField.Clear();
            CityTextField.SendKeys("abc");
            IWebElement RegionTextField = local_driver.FindElement(By.XPath(".//*[@id='Employees_Region']"));
            RegionTextField.Clear();
            RegionTextField.SendKeys("abc");
            IWebElement PostalCodeTextField = local_driver.FindElement(By.XPath(".//*[@id='Employees_PostalCode']"));
            PostalCodeTextField.Clear();
            PostalCodeTextField.SendKeys("abc");
            IWebElement CountryTextField = local_driver.FindElement(By.XPath(".//*[@id='Employees_Country']"));
            CountryTextField.Clear();
            CountryTextField.SendKeys("abc");
            IWebElement HomePhoneTextField = local_driver.FindElement(By.XPath(".//*[@id='Employees_HomePhone']"));
            HomePhoneTextField.Clear();
            HomePhoneTextField.SendKeys("abc");
            IWebElement ExtensionTextField = local_driver.FindElement(By.XPath(".//*[@id='Employees_Extension']"));
            ExtensionTextField.Clear();
            ExtensionTextField.SendKeys("abc");
            IWebElement PhotoTextField = local_driver.FindElement(By.XPath(".//*[@id='Employees_Photo']"));
            PhotoTextField.Clear();
            PhotoTextField.SendKeys("0x424d42000000000000003e0000002800000001000000010000000100010000000000040000000000000000000000000000000000000000000000ffffff00800000000000000000000000000000000000000000000000000000000");
            IWebElement NotesTextField = local_driver.FindElement(By.XPath(".//*[@id='Employees_Notes']"));
            NotesTextField.Clear();
            NotesTextField.SendKeys("Hello World!");
            IWebElement ReportsToTextField = local_driver.FindElement(By.XPath(".//*[@id='Employees_ReportsTo']"));
            ReportsToTextField.Clear();
            ReportsToTextField.SendKeys("1");
            IWebElement PhotoPathTextField = local_driver.FindElement(By.XPath(".//*[@id='Employees_PhotoPath']"));
            PhotoPathTextField.Clear();
            PhotoPathTextField.SendKeys("abc");

            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            Thread.Sleep(5000);
        }
        [Test, Order(3), Category("CRUD Testing")]
        public void TestMethodDelete_employees()
        {
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Tbl_Login/Login");
            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Employees/Delete?EmployeeID=999");

            Thread.Sleep(5000);

            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
        }
        [Test, Order(2), Category("CRUD Testing")]
        public void TestMethodCreate_bDetail_employeeterritories()
        {
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Tbl_Login/Login");
            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Employeeterritories/Create");

            IWebElement EmployeeIDTextField = local_driver.FindElement(By.XPath(".//*[@id='EmployeeID']"));
            EmployeeIDTextField.Clear();
            EmployeeIDTextField.SendKeys("999");
            IWebElement TerritoryIDTextField = local_driver.FindElement(By.XPath(".//*[@id='TerritoryID']"));
            TerritoryIDTextField.Clear();
            TerritoryIDTextField.SendKeys("999");

            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();

            Thread.Sleep(5000);
        }
        [Test, Order(3), Category("CRUD Testing")]
        public void TestMethodRead_employeeterritories()
        {

            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Tbl_Login/Login");
            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Employeeterritories/Details?TerritoryID=999");

            Thread.Sleep(5000);
        }
        [Test, Order(3), Category("CRUD Testing")]
        public void TestMethodUpdate_employeeterritories()
        {

            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Tbl_Login/Login");
            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Employeeterritories/Edit?TerritoryID=999");

            IWebElement EmployeeIDTextField = local_driver.FindElement(By.XPath(".//*[@id='Employeeterritories_EmployeeID']"));
            EmployeeIDTextField.Clear();
            EmployeeIDTextField.SendKeys("999");
            IWebElement TerritoryIDTextField = local_driver.FindElement(By.XPath(".//*[@id='Employeeterritories_TerritoryID']"));
            TerritoryIDTextField.Clear();
            TerritoryIDTextField.SendKeys("999");

            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            Thread.Sleep(5000);
        }
        [Test, Order(3), Category("CRUD Testing")]
        public void TestMethodDelete_employeeterritories()
        {
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Tbl_Login/Login");
            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Employeeterritories/Delete?TerritoryID=999");

            Thread.Sleep(5000);

            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
        }
        [Test, Order(2), Category("CRUD Testing")]
        public void TestMethodCreate_bDetail_order_details()
        {
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Tbl_Login/Login");
            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Order_Details/Create");

            IWebElement OrderIDTextField = local_driver.FindElement(By.XPath(".//*[@id='OrderID']"));
            OrderIDTextField.Clear();
            OrderIDTextField.SendKeys("999");
            IWebElement ProductIDTextField = local_driver.FindElement(By.XPath(".//*[@id='ProductID']"));
            ProductIDTextField.Clear();
            ProductIDTextField.SendKeys("999");
            IWebElement UnitPriceTextField = local_driver.FindElement(By.XPath(".//*[@id='UnitPrice']"));
            UnitPriceTextField.Clear();
            UnitPriceTextField.SendKeys("1");
            IWebElement QuantityTextField = local_driver.FindElement(By.XPath(".//*[@id='Quantity']"));
            QuantityTextField.Clear();
            QuantityTextField.SendKeys("1");
            IWebElement DiscountTextField = local_driver.FindElement(By.XPath(".//*[@id='Discount']"));
            DiscountTextField.Clear();
            DiscountTextField.SendKeys("1");

            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();

            Thread.Sleep(5000);
        }
        [Test, Order(3), Category("CRUD Testing")]
        public void TestMethodRead_order_details()
        {

            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Tbl_Login/Login");
            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Order_Details/Details?ProductID=999");

            Thread.Sleep(5000);
        }
        [Test, Order(3), Category("CRUD Testing")]
        public void TestMethodUpdate_order_details()
        {

            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Tbl_Login/Login");
            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Order_Details/Edit?ProductID=999");

            IWebElement OrderIDTextField = local_driver.FindElement(By.XPath(".//*[@id='Order_Details_OrderID']"));
            OrderIDTextField.Clear();
            OrderIDTextField.SendKeys("999");
            IWebElement ProductIDTextField = local_driver.FindElement(By.XPath(".//*[@id='Order_Details_ProductID']"));
            ProductIDTextField.Clear();
            ProductIDTextField.SendKeys("999");
            IWebElement UnitPriceTextField = local_driver.FindElement(By.XPath(".//*[@id='Order_Details_UnitPrice']"));
            UnitPriceTextField.Clear();
            UnitPriceTextField.SendKeys("1");
            IWebElement QuantityTextField = local_driver.FindElement(By.XPath(".//*[@id='Order_Details_Quantity']"));
            QuantityTextField.Clear();
            QuantityTextField.SendKeys("1");
            IWebElement DiscountTextField = local_driver.FindElement(By.XPath(".//*[@id='Order_Details_Discount']"));
            DiscountTextField.Clear();
            DiscountTextField.SendKeys("1");

            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            Thread.Sleep(5000);
        }
        [Test, Order(3), Category("CRUD Testing")]
        public void TestMethodDelete_order_details()
        {
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Tbl_Login/Login");
            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Order_Details/Delete?ProductID=999");

            Thread.Sleep(5000);

            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
        }
        [Test, Order(2), Category("CRUD Testing")]
        public void TestMethodCreate_bDetail_orders()
        {
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Tbl_Login/Login");
            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Orders/Create");

            IWebElement CustomerIDTextField = local_driver.FindElement(By.XPath(".//*[@id='CustomerID']"));
            CustomerIDTextField.Clear();
            CustomerIDTextField.SendKeys("c");
            IWebElement EmployeeIDTextField = local_driver.FindElement(By.XPath(".//*[@id='EmployeeID']"));
            EmployeeIDTextField.Clear();
            EmployeeIDTextField.SendKeys("1");
            IWebElement OrderDateTextField = local_driver.FindElement(By.XPath(".//*[@id='OrderDate']"));
            OrderDateTextField.Clear();
            OrderDateTextField.SendKeys(DateTime.Today.ToString("d"));
            IWebElement RequiredDateTextField = local_driver.FindElement(By.XPath(".//*[@id='RequiredDate']"));
            RequiredDateTextField.Clear();
            RequiredDateTextField.SendKeys(DateTime.Today.ToString("d"));
            IWebElement ShippedDateTextField = local_driver.FindElement(By.XPath(".//*[@id='ShippedDate']"));
            ShippedDateTextField.Clear();
            ShippedDateTextField.SendKeys(DateTime.Today.ToString("d"));
            IWebElement ShipViaTextField = local_driver.FindElement(By.XPath(".//*[@id='ShipVia']"));
            ShipViaTextField.Clear();
            ShipViaTextField.SendKeys("1");
            IWebElement FreightTextField = local_driver.FindElement(By.XPath(".//*[@id='Freight']"));
            FreightTextField.Clear();
            FreightTextField.SendKeys("1");
            IWebElement ShipNameTextField = local_driver.FindElement(By.XPath(".//*[@id='ShipName']"));
            ShipNameTextField.Clear();
            ShipNameTextField.SendKeys("c");
            IWebElement ShipAddressTextField = local_driver.FindElement(By.XPath(".//*[@id='ShipAddress']"));
            ShipAddressTextField.Clear();
            ShipAddressTextField.SendKeys("c");
            IWebElement ShipCityTextField = local_driver.FindElement(By.XPath(".//*[@id='ShipCity']"));
            ShipCityTextField.Clear();
            ShipCityTextField.SendKeys("c");
            IWebElement ShipRegionTextField = local_driver.FindElement(By.XPath(".//*[@id='ShipRegion']"));
            ShipRegionTextField.Clear();
            ShipRegionTextField.SendKeys("c");
            IWebElement ShipPostalCodeTextField = local_driver.FindElement(By.XPath(".//*[@id='ShipPostalCode']"));
            ShipPostalCodeTextField.Clear();
            ShipPostalCodeTextField.SendKeys("c");
            IWebElement ShipCountryTextField = local_driver.FindElement(By.XPath(".//*[@id='ShipCountry']"));
            ShipCountryTextField.Clear();
            ShipCountryTextField.SendKeys("c");

            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();

            Thread.Sleep(5000);
        }
        [Test, Order(3), Category("CRUD Testing")]
        public void TestMethodRead_orders()
        {

            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Tbl_Login/Login");
            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Orders/Details?OrderID=999");

            Thread.Sleep(5000);
        }
        [Test, Order(3), Category("CRUD Testing")]
        public void TestMethodUpdate_orders()
        {

            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Tbl_Login/Login");
            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Orders/Edit?OrderID=999");

            IWebElement CustomerIDTextField = local_driver.FindElement(By.XPath(".//*[@id='Orders_CustomerID']"));
            CustomerIDTextField.Clear();
            CustomerIDTextField.SendKeys("abc");
            IWebElement EmployeeIDTextField = local_driver.FindElement(By.XPath(".//*[@id='Orders_EmployeeID']"));
            EmployeeIDTextField.Clear();
            EmployeeIDTextField.SendKeys("1");
            IWebElement OrderDateTextField = local_driver.FindElement(By.XPath(".//*[@id='Orders_OrderDate']"));
            OrderDateTextField.Clear();
            OrderDateTextField.SendKeys(DateTime.Today.ToString("d"));
            IWebElement RequiredDateTextField = local_driver.FindElement(By.XPath(".//*[@id='Orders_RequiredDate']"));
            RequiredDateTextField.Clear();
            RequiredDateTextField.SendKeys(DateTime.Today.ToString("d"));
            IWebElement ShippedDateTextField = local_driver.FindElement(By.XPath(".//*[@id='Orders_ShippedDate']"));
            ShippedDateTextField.Clear();
            ShippedDateTextField.SendKeys(DateTime.Today.ToString("d"));
            IWebElement ShipViaTextField = local_driver.FindElement(By.XPath(".//*[@id='Orders_ShipVia']"));
            ShipViaTextField.Clear();
            ShipViaTextField.SendKeys("1");
            IWebElement FreightTextField = local_driver.FindElement(By.XPath(".//*[@id='Orders_Freight']"));
            FreightTextField.Clear();
            FreightTextField.SendKeys("1");
            IWebElement ShipNameTextField = local_driver.FindElement(By.XPath(".//*[@id='Orders_ShipName']"));
            ShipNameTextField.Clear();
            ShipNameTextField.SendKeys("abc");
            IWebElement ShipAddressTextField = local_driver.FindElement(By.XPath(".//*[@id='Orders_ShipAddress']"));
            ShipAddressTextField.Clear();
            ShipAddressTextField.SendKeys("abc");
            IWebElement ShipCityTextField = local_driver.FindElement(By.XPath(".//*[@id='Orders_ShipCity']"));
            ShipCityTextField.Clear();
            ShipCityTextField.SendKeys("abc");
            IWebElement ShipRegionTextField = local_driver.FindElement(By.XPath(".//*[@id='Orders_ShipRegion']"));
            ShipRegionTextField.Clear();
            ShipRegionTextField.SendKeys("abc");
            IWebElement ShipPostalCodeTextField = local_driver.FindElement(By.XPath(".//*[@id='Orders_ShipPostalCode']"));
            ShipPostalCodeTextField.Clear();
            ShipPostalCodeTextField.SendKeys("abc");
            IWebElement ShipCountryTextField = local_driver.FindElement(By.XPath(".//*[@id='Orders_ShipCountry']"));
            ShipCountryTextField.Clear();
            ShipCountryTextField.SendKeys("abc");

            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            Thread.Sleep(5000);
        }
        [Test, Order(3), Category("CRUD Testing")]
        public void TestMethodDelete_orders()
        {
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Tbl_Login/Login");
            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Orders/Delete?OrderID=999");

            Thread.Sleep(5000);

            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
        }
        [Test, Order(2), Category("CRUD Testing")]
        public void TestMethodCreate_bDetail_products()
        {
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Tbl_Login/Login");
            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Products/Create");

            IWebElement ProductNameTextField = local_driver.FindElement(By.XPath(".//*[@id='ProductName']"));
            ProductNameTextField.Clear();
            ProductNameTextField.SendKeys("c");
            IWebElement SupplierIDTextField = local_driver.FindElement(By.XPath(".//*[@id='SupplierID']"));
            SupplierIDTextField.Clear();
            SupplierIDTextField.SendKeys("1");
            IWebElement CategoryIDTextField = local_driver.FindElement(By.XPath(".//*[@id='CategoryID']"));
            CategoryIDTextField.Clear();
            CategoryIDTextField.SendKeys("1");
            IWebElement QuantityPerUnitTextField = local_driver.FindElement(By.XPath(".//*[@id='QuantityPerUnit']"));
            QuantityPerUnitTextField.Clear();
            QuantityPerUnitTextField.SendKeys("c");
            IWebElement UnitPriceTextField = local_driver.FindElement(By.XPath(".//*[@id='UnitPrice']"));
            UnitPriceTextField.Clear();
            UnitPriceTextField.SendKeys("1");
            IWebElement UnitsInStockTextField = local_driver.FindElement(By.XPath(".//*[@id='UnitsInStock']"));
            UnitsInStockTextField.Clear();
            UnitsInStockTextField.SendKeys("1");
            IWebElement UnitsOnOrderTextField = local_driver.FindElement(By.XPath(".//*[@id='UnitsOnOrder']"));
            UnitsOnOrderTextField.Clear();
            UnitsOnOrderTextField.SendKeys("1");
            IWebElement ReorderLevelTextField = local_driver.FindElement(By.XPath(".//*[@id='ReorderLevel']"));
            ReorderLevelTextField.Clear();
            ReorderLevelTextField.SendKeys("1");
            IWebElement DiscontinuedTextField = local_driver.FindElement(By.XPath(".//*[@id='Discontinued']"));
            DiscontinuedTextField.Click();

            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();

            Thread.Sleep(5000);
        }
        [Test, Order(3), Category("CRUD Testing")]
        public void TestMethodRead_products()
        {

            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Tbl_Login/Login");
            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Products/Details?ProductID=999");

            Thread.Sleep(5000);
        }
        [Test, Order(3), Category("CRUD Testing")]
        public void TestMethodUpdate_products()
        {

            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Tbl_Login/Login");
            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Products/Edit?ProductID=999");

            IWebElement ProductNameTextField = local_driver.FindElement(By.XPath(".//*[@id='Products_ProductName']"));
            ProductNameTextField.Clear();
            ProductNameTextField.SendKeys("abc");
            IWebElement SupplierIDTextField = local_driver.FindElement(By.XPath(".//*[@id='Products_SupplierID']"));
            SupplierIDTextField.Clear();
            SupplierIDTextField.SendKeys("1");
            IWebElement CategoryIDTextField = local_driver.FindElement(By.XPath(".//*[@id='Products_CategoryID']"));
            CategoryIDTextField.Clear();
            CategoryIDTextField.SendKeys("1");
            IWebElement QuantityPerUnitTextField = local_driver.FindElement(By.XPath(".//*[@id='Products_QuantityPerUnit']"));
            QuantityPerUnitTextField.Clear();
            QuantityPerUnitTextField.SendKeys("abc");
            IWebElement UnitPriceTextField = local_driver.FindElement(By.XPath(".//*[@id='Products_UnitPrice']"));
            UnitPriceTextField.Clear();
            UnitPriceTextField.SendKeys("1");
            IWebElement UnitsInStockTextField = local_driver.FindElement(By.XPath(".//*[@id='Products_UnitsInStock']"));
            UnitsInStockTextField.Clear();
            UnitsInStockTextField.SendKeys("1");
            IWebElement UnitsOnOrderTextField = local_driver.FindElement(By.XPath(".//*[@id='Products_UnitsOnOrder']"));
            UnitsOnOrderTextField.Clear();
            UnitsOnOrderTextField.SendKeys("1");
            IWebElement ReorderLevelTextField = local_driver.FindElement(By.XPath(".//*[@id='Products_ReorderLevel']"));
            ReorderLevelTextField.Clear();
            ReorderLevelTextField.SendKeys("1");
            IWebElement DiscontinuedTextField = local_driver.FindElement(By.XPath(".//*[@id='Products_Discontinued']"));
            DiscontinuedTextField.Click();

            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            Thread.Sleep(5000);
        }
        [Test, Order(3), Category("CRUD Testing")]
        public void TestMethodDelete_products()
        {
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Tbl_Login/Login");
            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Products/Delete?ProductID=999");

            Thread.Sleep(5000);

            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
        }
        [Test, Order(1), Category("CRUD Testing")]
        public void TestMethodCreate_aMaster_region()
        {
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Tbl_Login/Login");
            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Region/Create");

            IWebElement RegionIDTextField = local_driver.FindElement(By.XPath(".//*[@id='RegionID']"));
            RegionIDTextField.Clear();
            RegionIDTextField.SendKeys("999");
            IWebElement RegionDescriptionTextField = local_driver.FindElement(By.XPath(".//*[@id='RegionDescription']"));
            RegionDescriptionTextField.Clear();
            RegionDescriptionTextField.SendKeys("c");

            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();

            Thread.Sleep(5000);
        }
        [Test, Order(3), Category("CRUD Testing")]
        public void TestMethodRead_region()
        {

            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Tbl_Login/Login");
            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Region/Details?RegionID=999");

            Thread.Sleep(5000);
        }
        [Test, Order(3), Category("CRUD Testing")]
        public void TestMethodUpdate_region()
        {

            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Tbl_Login/Login");
            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Region/Edit?RegionID=999");

            IWebElement RegionIDTextField = local_driver.FindElement(By.XPath(".//*[@id='Region_RegionID']"));
            RegionIDTextField.Clear();
            RegionIDTextField.SendKeys("999");
            IWebElement RegionDescriptionTextField = local_driver.FindElement(By.XPath(".//*[@id='Region_RegionDescription']"));
            RegionDescriptionTextField.Clear();
            RegionDescriptionTextField.SendKeys("abc");

            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            Thread.Sleep(5000);
        }
        [Test, Order(3), Category("CRUD Testing")]
        public void TestMethodDelete_region()
        {
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Tbl_Login/Login");
            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Region/Delete?RegionID=999");

            Thread.Sleep(5000);

            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
        }
        [Test, Order(1), Category("CRUD Testing")]
        public void TestMethodCreate_aMaster_shippers()
        {
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Tbl_Login/Login");
            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Shippers/Create");

            IWebElement CompanyNameTextField = local_driver.FindElement(By.XPath(".//*[@id='CompanyName']"));
            CompanyNameTextField.Clear();
            CompanyNameTextField.SendKeys("c");
            IWebElement PhoneTextField = local_driver.FindElement(By.XPath(".//*[@id='Phone']"));
            PhoneTextField.Clear();
            PhoneTextField.SendKeys("c");

            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();

            Thread.Sleep(5000);
        }
        [Test, Order(3), Category("CRUD Testing")]
        public void TestMethodRead_shippers()
        {

            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Tbl_Login/Login");
            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Shippers/Details?ShipperID=999");

            Thread.Sleep(5000);
        }
        [Test, Order(3), Category("CRUD Testing")]
        public void TestMethodUpdate_shippers()
        {

            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Tbl_Login/Login");
            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Shippers/Edit?ShipperID=999");

            IWebElement CompanyNameTextField = local_driver.FindElement(By.XPath(".//*[@id='Shippers_CompanyName']"));
            CompanyNameTextField.Clear();
            CompanyNameTextField.SendKeys("abc");
            IWebElement PhoneTextField = local_driver.FindElement(By.XPath(".//*[@id='Shippers_Phone']"));
            PhoneTextField.Clear();
            PhoneTextField.SendKeys("abc");

            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            Thread.Sleep(5000);
        }
        [Test, Order(3), Category("CRUD Testing")]
        public void TestMethodDelete_shippers()
        {
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Tbl_Login/Login");
            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Shippers/Delete?ShipperID=999");

            Thread.Sleep(5000);

            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
        }
        [Test, Order(1), Category("CRUD Testing")]
        public void TestMethodCreate_aMaster_suppliers()
        {
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Tbl_Login/Login");
            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Suppliers/Create");

            IWebElement CompanyNameTextField = local_driver.FindElement(By.XPath(".//*[@id='CompanyName']"));
            CompanyNameTextField.Clear();
            CompanyNameTextField.SendKeys("c");
            IWebElement ContactNameTextField = local_driver.FindElement(By.XPath(".//*[@id='ContactName']"));
            ContactNameTextField.Clear();
            ContactNameTextField.SendKeys("c");
            IWebElement ContactTitleTextField = local_driver.FindElement(By.XPath(".//*[@id='ContactTitle']"));
            ContactTitleTextField.Clear();
            ContactTitleTextField.SendKeys("c");
            IWebElement AddressTextField = local_driver.FindElement(By.XPath(".//*[@id='Address']"));
            AddressTextField.Clear();
            AddressTextField.SendKeys("c");
            IWebElement CityTextField = local_driver.FindElement(By.XPath(".//*[@id='City']"));
            CityTextField.Clear();
            CityTextField.SendKeys("c");
            IWebElement RegionTextField = local_driver.FindElement(By.XPath(".//*[@id='Region']"));
            RegionTextField.Clear();
            RegionTextField.SendKeys("c");
            IWebElement PostalCodeTextField = local_driver.FindElement(By.XPath(".//*[@id='PostalCode']"));
            PostalCodeTextField.Clear();
            PostalCodeTextField.SendKeys("c");
            IWebElement CountryTextField = local_driver.FindElement(By.XPath(".//*[@id='Country']"));
            CountryTextField.Clear();
            CountryTextField.SendKeys("c");
            IWebElement PhoneTextField = local_driver.FindElement(By.XPath(".//*[@id='Phone']"));
            PhoneTextField.Clear();
            PhoneTextField.SendKeys("c");
            IWebElement FaxTextField = local_driver.FindElement(By.XPath(".//*[@id='Fax']"));
            FaxTextField.Clear();
            FaxTextField.SendKeys("c");
            IWebElement HomePageTextField = local_driver.FindElement(By.XPath(".//*[@id='HomePage']"));
            HomePageTextField.Clear();
            HomePageTextField.SendKeys("Hello World!");

            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();

            Thread.Sleep(5000);
        }
        [Test, Order(3), Category("CRUD Testing")]
        public void TestMethodRead_suppliers()
        {

            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Tbl_Login/Login");
            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Suppliers/Details?SupplierID=999");

            Thread.Sleep(5000);
        }
        [Test, Order(3), Category("CRUD Testing")]
        public void TestMethodUpdate_suppliers()
        {

            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Tbl_Login/Login");
            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Suppliers/Edit?SupplierID=999");

            IWebElement CompanyNameTextField = local_driver.FindElement(By.XPath(".//*[@id='Suppliers_CompanyName']"));
            CompanyNameTextField.Clear();
            CompanyNameTextField.SendKeys("abc");
            IWebElement ContactNameTextField = local_driver.FindElement(By.XPath(".//*[@id='Suppliers_ContactName']"));
            ContactNameTextField.Clear();
            ContactNameTextField.SendKeys("abc");
            IWebElement ContactTitleTextField = local_driver.FindElement(By.XPath(".//*[@id='Suppliers_ContactTitle']"));
            ContactTitleTextField.Clear();
            ContactTitleTextField.SendKeys("abc");
            IWebElement AddressTextField = local_driver.FindElement(By.XPath(".//*[@id='Suppliers_Address']"));
            AddressTextField.Clear();
            AddressTextField.SendKeys("abc");
            IWebElement CityTextField = local_driver.FindElement(By.XPath(".//*[@id='Suppliers_City']"));
            CityTextField.Clear();
            CityTextField.SendKeys("abc");
            IWebElement RegionTextField = local_driver.FindElement(By.XPath(".//*[@id='Suppliers_Region']"));
            RegionTextField.Clear();
            RegionTextField.SendKeys("abc");
            IWebElement PostalCodeTextField = local_driver.FindElement(By.XPath(".//*[@id='Suppliers_PostalCode']"));
            PostalCodeTextField.Clear();
            PostalCodeTextField.SendKeys("abc");
            IWebElement CountryTextField = local_driver.FindElement(By.XPath(".//*[@id='Suppliers_Country']"));
            CountryTextField.Clear();
            CountryTextField.SendKeys("abc");
            IWebElement PhoneTextField = local_driver.FindElement(By.XPath(".//*[@id='Suppliers_Phone']"));
            PhoneTextField.Clear();
            PhoneTextField.SendKeys("abc");
            IWebElement FaxTextField = local_driver.FindElement(By.XPath(".//*[@id='Suppliers_Fax']"));
            FaxTextField.Clear();
            FaxTextField.SendKeys("abc");
            IWebElement HomePageTextField = local_driver.FindElement(By.XPath(".//*[@id='Suppliers_HomePage']"));
            HomePageTextField.Clear();
            HomePageTextField.SendKeys("Hello World!");

            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            Thread.Sleep(5000);
        }
        [Test, Order(3), Category("CRUD Testing")]
        public void TestMethodDelete_suppliers()
        {
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Tbl_Login/Login");
            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Suppliers/Delete?SupplierID=999");

            Thread.Sleep(5000);

            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
        }
        [Test, Order(1), Category("CRUD Testing")]
        public void TestMethodCreate_aMaster_tbl_exceptionloggingtodatabase()
        {
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Tbl_Login/Login");
            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Tbl_Exceptionloggingtodatabase/Create");

            IWebElement ExceptionMsgTextField = local_driver.FindElement(By.XPath(".//*[@id='ExceptionMsg']"));
            ExceptionMsgTextField.Clear();
            ExceptionMsgTextField.SendKeys("c");
            IWebElement ExceptionTypeTextField = local_driver.FindElement(By.XPath(".//*[@id='ExceptionType']"));
            ExceptionTypeTextField.Clear();
            ExceptionTypeTextField.SendKeys("c");
            IWebElement ExceptionSourceTextField = local_driver.FindElement(By.XPath(".//*[@id='ExceptionSource']"));
            ExceptionSourceTextField.Clear();
            ExceptionSourceTextField.SendKeys("c");
            IWebElement ExceptionURLTextField = local_driver.FindElement(By.XPath(".//*[@id='ExceptionURL']"));
            ExceptionURLTextField.Clear();
            ExceptionURLTextField.SendKeys("c");
            IWebElement LogdateTextField = local_driver.FindElement(By.XPath(".//*[@id='Logdate']"));
            LogdateTextField.Clear();
            LogdateTextField.SendKeys(DateTime.Today.ToString("d"));

            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();

            Thread.Sleep(5000);
        }
        [Test, Order(3), Category("CRUD Testing")]
        public void TestMethodRead_tbl_exceptionloggingtodatabase()
        {

            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Tbl_Login/Login");
            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Tbl_Exceptionloggingtodatabase/Details?Logid=999");

            Thread.Sleep(5000);
        }
        [Test, Order(3), Category("CRUD Testing")]
        public void TestMethodUpdate_tbl_exceptionloggingtodatabase()
        {

            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Tbl_Login/Login");
            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Tbl_Exceptionloggingtodatabase/Edit?Logid=999");

            IWebElement ExceptionMsgTextField = local_driver.FindElement(By.XPath(".//*[@id='Tbl_Exceptionloggingtodatabase_ExceptionMsg']"));
            ExceptionMsgTextField.Clear();
            ExceptionMsgTextField.SendKeys("abc");
            IWebElement ExceptionTypeTextField = local_driver.FindElement(By.XPath(".//*[@id='Tbl_Exceptionloggingtodatabase_ExceptionType']"));
            ExceptionTypeTextField.Clear();
            ExceptionTypeTextField.SendKeys("abc");
            IWebElement ExceptionSourceTextField = local_driver.FindElement(By.XPath(".//*[@id='Tbl_Exceptionloggingtodatabase_ExceptionSource']"));
            ExceptionSourceTextField.Clear();
            ExceptionSourceTextField.SendKeys("abc");
            IWebElement ExceptionURLTextField = local_driver.FindElement(By.XPath(".//*[@id='Tbl_Exceptionloggingtodatabase_ExceptionURL']"));
            ExceptionURLTextField.Clear();
            ExceptionURLTextField.SendKeys("abc");
            IWebElement LogdateTextField = local_driver.FindElement(By.XPath(".//*[@id='Tbl_Exceptionloggingtodatabase_Logdate']"));
            LogdateTextField.Clear();
            LogdateTextField.SendKeys(DateTime.Today.ToString("d"));

            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            Thread.Sleep(5000);
        }
        [Test, Order(3), Category("CRUD Testing")]
        public void TestMethodDelete_tbl_exceptionloggingtodatabase()
        {
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Tbl_Login/Login");
            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Tbl_Exceptionloggingtodatabase/Delete?Logid=999");

            Thread.Sleep(5000);

            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
        }
        [Test, Order(1), Category("CRUD Testing")]
        public void TestMethodCreate_aMaster_tbl_login()
        {
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Tbl_Login/Login");
            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Tbl_Login/Create");

            IWebElement UsernameTextField = local_driver.FindElement(By.XPath(".//*[@id='Username']"));
            UsernameTextField.Clear();
            UsernameTextField.SendKeys("999");
            IWebElement PasswordTextField = local_driver.FindElement(By.XPath(".//*[@id='Password']"));
            PasswordTextField.Clear();
            PasswordTextField.SendKeys("c");
            IWebElement RolesTextField = local_driver.FindElement(By.XPath(".//*[@id='Roles']"));
            RolesTextField.Clear();
            RolesTextField.SendKeys("c");
            IWebElement ActiveStatusTextField = local_driver.FindElement(By.XPath(".//*[@id='ActiveStatus']"));
            ActiveStatusTextField.Click();

            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();

            Thread.Sleep(5000);
        }
        [Test, Order(3), Category("CRUD Testing")]
        public void TestMethodRead_tbl_login()
        {

            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Tbl_Login/Login");
            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Tbl_Login/Details?Username=999");

            Thread.Sleep(5000);
        }
        [Test, Order(3), Category("CRUD Testing")]
        public void TestMethodUpdate_tbl_login()
        {

            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Tbl_Login/Login");
            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Tbl_Login/Edit?Username=999");

            IWebElement UsernameTextField = local_driver.FindElement(By.XPath(".//*[@id='Tbl_Login_Username']"));
            UsernameTextField.Clear();
            UsernameTextField.SendKeys("999");
            IWebElement PasswordTextField = local_driver.FindElement(By.XPath(".//*[@id='Tbl_Login_Password']"));
            PasswordTextField.Clear();
            PasswordTextField.SendKeys("abc");
            IWebElement RolesTextField = local_driver.FindElement(By.XPath(".//*[@id='Tbl_Login_Roles']"));
            RolesTextField.Clear();
            RolesTextField.SendKeys("abc");
            IWebElement ActiveStatusTextField = local_driver.FindElement(By.XPath(".//*[@id='Tbl_Login_ActiveStatus']"));
            ActiveStatusTextField.Click();

            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            Thread.Sleep(5000);
        }
        [Test, Order(3), Category("CRUD Testing")]
        public void TestMethodDelete_tbl_login()
        {
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Tbl_Login/Login");
            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Tbl_Login/Delete?Username=999");

            Thread.Sleep(5000);

            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
        }
        [Test, Order(2), Category("CRUD Testing")]
        public void TestMethodCreate_bDetail_territories()
        {
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Tbl_Login/Login");
            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Territories/Create");

            IWebElement TerritoryIDTextField = local_driver.FindElement(By.XPath(".//*[@id='TerritoryID']"));
            TerritoryIDTextField.Clear();
            TerritoryIDTextField.SendKeys("999");
            IWebElement TerritoryDescriptionTextField = local_driver.FindElement(By.XPath(".//*[@id='TerritoryDescription']"));
            TerritoryDescriptionTextField.Clear();
            TerritoryDescriptionTextField.SendKeys("c");
            IWebElement RegionIDTextField = local_driver.FindElement(By.XPath(".//*[@id='RegionID']"));
            RegionIDTextField.Clear();
            RegionIDTextField.SendKeys("1");

            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();

            Thread.Sleep(5000);
        }
        [Test, Order(3), Category("CRUD Testing")]
        public void TestMethodRead_territories()
        {

            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Tbl_Login/Login");
            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Territories/Details?TerritoryID=999");

            Thread.Sleep(5000);
        }
        [Test, Order(3), Category("CRUD Testing")]
        public void TestMethodUpdate_territories()
        {

            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Tbl_Login/Login");
            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Territories/Edit?TerritoryID=999");

            IWebElement TerritoryIDTextField = local_driver.FindElement(By.XPath(".//*[@id='Territories_TerritoryID']"));
            TerritoryIDTextField.Clear();
            TerritoryIDTextField.SendKeys("999");
            IWebElement TerritoryDescriptionTextField = local_driver.FindElement(By.XPath(".//*[@id='Territories_TerritoryDescription']"));
            TerritoryDescriptionTextField.Clear();
            TerritoryDescriptionTextField.SendKeys("abc");
            IWebElement RegionIDTextField = local_driver.FindElement(By.XPath(".//*[@id='Territories_RegionID']"));
            RegionIDTextField.Clear();
            RegionIDTextField.SendKeys("1");

            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            Thread.Sleep(5000);
        }
        [Test, Order(3), Category("CRUD Testing")]
        public void TestMethodDelete_territories()
        {
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Tbl_Login/Login");
            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
            local_driver.Navigate().GoToUrl(BS_prefix_url + "/Territories/Delete?TerritoryID=999");

            Thread.Sleep(5000);

            local_driver.FindElement(By.XPath(".//*[@type='submit']")).Click();
        }
    }
}
