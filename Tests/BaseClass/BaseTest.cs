using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.BaseClass
{
    public class BaseTest
    {
        public IWebDriver local_driver;
        public string BS_prefix_url = "https://localhost:44319";

        //[SetUp]
        [OneTimeSetUp]
        public void Open()
        {

            local_driver = new ChromeDriver
            {
                //local_driver.Manage().Window.Maximize();
                Url = BS_prefix_url + "/Home/Index"
            };

        }

        //[TearDown]
        [OneTimeTearDown]
        public void Close()
        {
            local_driver.Quit();
        }
    }
}
