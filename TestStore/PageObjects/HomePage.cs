using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestStore.PageObjects
{
    public class HomePage
    {
        private readonly IWebDriver _driver;
        private readonly By _acceptAllButton = By.XPath("//button[text()='Accept all']");
        private readonly By _categoryALink = By.CssSelector("a[href='/c/c1-cwxxeg']");

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void AcceptCookies()
        {
            _driver.FindElement(_acceptAllButton).Click();
        }

        public void GoToCategoryA()
        {
            _driver.FindElement(_categoryALink).Click();
        }
    }

}
