using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using Project1.Utilities;
using System;
using System.Configuration;
using System.Threading;
using WebDriverManager.DriverConfigs.Impl;

namespace Project1
{
    public class Base
    {

        private readonly ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();

        [SetUp]
        public void Setup()
        {
            string browserName = ConfigurationManager.AppSettings["browser"];
            InitBrowser(browserName);
            driver.Value.Manage().Window.Maximize();
            driver.Value.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Value.Navigate().GoToUrl("https://lyratesting2.co.nz/");

        }

        public void InitBrowser(string browserName)
        {
            switch (browserName)
            {
                case "Firefox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver.Value = new FirefoxDriver();
                    break;
                case "Chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver.Value = new ChromeDriver();
                    break;
                case "Edge":
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    driver.Value = new EdgeDriver();
                    break;
            }
        }

        public IWebDriver GeTDriver()
        {
            return driver.Value;
        }

        public static JSON_reader extractData()
        {
            return new JSON_reader();
        }

        [TearDown]
        public void AfterTest()
        {
            //driver.Value.Close();
        }


    }
}