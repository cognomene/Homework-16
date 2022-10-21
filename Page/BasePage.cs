using System;
using OpenQA.Selenium;

namespace NamuDarbai.Page
{
    public class BasePage
    {
        protected static IWebDriver Driver;

        public BasePage(IWebDriver webdriver)
        {
            Driver = webdriver;
        }




    }
}