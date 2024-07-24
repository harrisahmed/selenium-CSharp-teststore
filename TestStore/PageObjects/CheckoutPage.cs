using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestStore.PageObjects
{
    public class CheckoutPage
    {
        private readonly IWebDriver _driver;
        private readonly By _checkoutButton = By.XPath("//a[.//p[text()='Go to payment']]");
        private readonly By _guestLoginButton = By.XPath("//*[@data-testid='guestLogin']");
        private readonly By _confirmOrderButton = By.CssSelector("[data-testid='goToNextStep']");
        private readonly By _orderSuccessMessage = By.XPath("//*[text()='Your order has been placed successfully.']");

        public CheckoutPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void ProceedToCheckout()
        {
            _driver.FindElement(_checkoutButton).Click();
        }

        public void ChooseShoppingAsGuest(string email)
        {
            var emailField = _driver.FindElement(By.Name("email"));
            emailField.SendKeys(email);
            _driver.FindElement(_guestLoginButton).Click();
        }

        public void EnterShippingInformation(string firstName, string surName, string phone, string city, string country, string postal, string address, string additional)
        {
            var inputFirstName = _driver.FindElement(By.Name("shippingAddress.firstName"));
            var inputSurName = _driver.FindElement(By.Name("shippingAddress.lastName"));
            var inputPhone = _driver.FindElement(By.Name("shippingAddress.phone"));

            inputFirstName.SendKeys(firstName);
            inputSurName.SendKeys(surName);
            inputPhone.SendKeys(phone);

            var clickCountry = _driver.FindElement(By.XPath("//*[@data-testid='toggleAutocomplete']"));
            clickCountry.Click();

            var ulElement = _driver.FindElement(By.CssSelector("[role='listbox']"));
            var liElements = ulElement.FindElements(By.TagName("li"));
            foreach (var li in liElements)
            {
                if (li.Text == country)
                {
                    li.Click();
                    break;
                }
            }

            var getCity = _driver.FindElement(By.CssSelector("[data-testid='googleAutocomplete'] input"));
            getCity.SendKeys(city);

            var ulCityElement = _driver.FindElement(By.CssSelector("[role='listbox']"));
            var liCityElements = ulCityElement.FindElements(By.TagName("li"));
            foreach (var li in liCityElements)
            {
                if (li.Text == city)
                {
                    li.Click();
                    break;
                }
            }

            var inputPostCode = _driver.FindElement(By.Name("shippingAddress.postCode"));
            var inputAddress = _driver.FindElement(By.Name("shippingAddress.address"));
            var inputAdditionalInfo = _driver.FindElement(By.Name("comment"));

            inputPostCode.SendKeys(postal);
            inputAddress.SendKeys(address);
            inputAdditionalInfo.SendKeys(additional);
        }

        public void ConfirmOrder()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.CssSelector("[data-testid='costOfDeliveryRadioGroup']")).Displayed);

            _driver.FindElement(_confirmOrderButton).Click();
        }

        public bool IsOrderSuccessful()
        {
            return _driver.FindElement(_orderSuccessMessage).Displayed;
        }
    }
}
