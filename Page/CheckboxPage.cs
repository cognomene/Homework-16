using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NamuDarbai.Page
{
    public class CheckboxPage : BasePage
    {
        private string pageAddress => "http://demo.seleniumeasy.com/basic-checkbox-demo.html";
        private IWebElement oneCheckBox => Driver.FindElement(By.Id("isAgeSelected"));
        private IWebElement resultElement => Driver.FindElement(By.Id("txtAge"));
        private IWebElement button => Driver.FindElement(By.CssSelector("#check1"));

        public CheckboxPage(IWebDriver webdriver) : base(webdriver)
        {
        }


        public void NavigateToPage()
        {
            Driver.Url = pageAddress;
        }


        public void OneCheckboxTest()
        {
            if (!oneCheckBox.Selected)
            {
                oneCheckBox.Click();
            }
            Assert.AreEqual("Success - Check box is checked", resultElement.Text, "Result text is wrong");
        }


        public  void CheckboxesTest()
        {
            CheckAllChekboxes();
            Assert.IsTrue("Uncheck All".Equals(button.GetAttribute("value")),
                "Button value is not correct");

        }


        public void UncheckCheckboxesTest()
        {
            CheckAllChekboxes();
            button.Click();

            Assert.IsTrue("Check All".Equals(button.GetAttribute("value")),
                "Button value is not correct");

            foreach (IWebElement checkbox in GetCeckboxesCollection())
            {
                Assert.That(!checkbox.Selected, "Check box was not unselected");
            }

        }


        private static IReadOnlyCollection<IWebElement> GetCeckboxesCollection()
        {
            return Driver.FindElements(By.CssSelector(".cb1-element"));
        }


        private static void CheckAllChekboxes()
        {
            IReadOnlyCollection<IWebElement> checkboxesCollection
               = GetCeckboxesCollection();

            foreach (IWebElement checkbox in checkboxesCollection)
            {
                if (!checkbox.Selected)
                {
                    checkbox.Click();
                }
            }
        }



    }
}
