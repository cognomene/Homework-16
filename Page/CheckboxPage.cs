using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NamuDarbai.Page
{
    public class CheckboxPage : BasePage
    {
        private string pageAddress => "http://demo.seleniumeasy.com/basic-checkbox-demo.html";
        //private IWebElement inputField => Driver.FindElement(By.Id("user-message"));
        //private IWebElement firstBlockButton => Driver.FindElement(By.CssSelector("#get-input > button"));
        //private IWebElement resultElement => Driver.FindElement(By.Id("display"));
        //private IWebElement inputFieldA => Driver.FindElement(By.Id("sum1"));
        //private IWebElement inputFieldB => Driver.FindElement(By.Id("sum2"));
        //private IWebElement getTotalButton => Driver.FindElement(By.CssSelector("#gettotal>button"));
        //private IWebElement totalResultElement => Driver.FindElement(By.CssSelector("#displayvalue"));

        // FIRST TEST
        private IWebElement oneCheckBox => Driver.FindElement(By.Id("isAgeSelected"));
        private IWebElement resultElement => Driver.FindElement(By.Id("txtAge"));

        // SECOND TEST
        private IWebElement button => Driver.FindElement(By.CssSelector("#check1"));


        // THIRD TEST
        //private IWebElement button => Driver.FindElement(By.CssSelector("#check1")); button is the same as line 23


        public CheckboxPage(IWebDriver webdriver) : base(webdriver)
        {
        }

        public void NavigateToPage()
        {
            Driver.Url = pageAddress;
        }


        // visi kiti metodai zemiau

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