using System;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NamuDarbai.Page;

namespace NamuDarbai.Test
{
    public class CheckboxTest
    {
        private static IWebDriver chromeDriver;

        [OneTimeSetUp]
        public static void OneTimeSetup()
        {
            chromeDriver = new ChromeDriver();
            chromeDriver.Manage().Window.Maximize();
            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            chromeDriver.Quit();
        }

        [Test]
        [Order(3)]
        public static void OneCheckboxTest()
        {
            CheckboxPage page = new CheckboxPage(chromeDriver);
            page.NavigateToPage();
            page.OneCheckboxTest();

        }


        [Test]
        [Order(1)]
        public static void CheckboxesTest()
        {
            CheckboxPage page = new CheckboxPage(chromeDriver);
            page.NavigateToPage();
            page.CheckboxesTest();
        }


        [Test]
        [Order(2)]
        public static void UncheckCheckboxesTest()
        {
            CheckboxPage page = new CheckboxPage(chromeDriver);
            page.NavigateToPage();
            page.UncheckCheckboxesTest();

        }

    }
}