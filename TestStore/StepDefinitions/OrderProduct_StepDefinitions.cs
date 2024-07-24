using NUnit.Framework;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestStore.PageObjects;

namespace TestStore.StepDefinitions
{
    [Binding]
    public class OrderProduct_StepDefinitions
    {
        private IWebDriver driver;
        private HomePage homePage;
        private ProductPage productPage;
        private CheckoutPage checkoutPage;

        [BeforeScenario]
        public void Setup()
        {
            var options = new ChromeOptions();
            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);

            homePage = new HomePage(driver);
            productPage = new ProductPage(driver);
            checkoutPage = new CheckoutPage(driver);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Given(@"I navigate to the home page")]
        public void GivenINavigateToTheHomePage()
        {
            driver.Navigate().GoToUrl("https://teststoreforsouthafri.nextbasket.shop/");
        }

        [When(@"I clicked on Category A")]
        public void WhenIClickedOnCategoryA()
        {
            homePage.AcceptCookies();
            homePage.GoToCategoryA();
        }

        [When(@"I filter out in stock products\.")]
        public void WhenIFilterOutInStockProducts_()
        {
            productPage.FilterInStockProducts();
        }

        [When(@"I buy the first in-stock non-promo product")]
        public void WhenISelectTheFirstIn_StockNon_PromoProduct()
        {
            productPage.BuyFirstInStockNonPromoProduct();
        }

        [Then(@"the product should be successfully added to the cart")]
        public void ThenTheProductShouldBeSuccessfullyAddedToTheCart()
        {
            var cssSelector = By.CssSelector("div[role='status'] svg");
            driver.FindElement(cssSelector).Click();
            var basketMenu = By.CssSelector("div[aria-label='Open basket menu']");
            driver.FindElement(basketMenu).Click();
        }

        [When(@"I proceed to checkout\.")]
        public void WhenIProceedToCheckout_()
        {
            checkoutPage.ProceedToCheckout();
        }

        [When(@"I chose shoping as a guest")]
        public void WhenIChoseShopingAsAGuest(Table table)
        {
            var email = table.Rows[0]["value"];
            checkoutPage.ChooseShoppingAsGuest(email);
        }

        [When(@"I enter shipping information")]
        public void WhenIEnterShippingInformation(Table table)
        {
            var firstName = table.Rows[0]["value"];
            var surName = table.Rows[1]["value"];
            var phone = table.Rows[2]["value"];
            var city = table.Rows[3]["value"];
            var country = table.Rows[4]["value"];
            var postal = table.Rows[5]["value"];
            var address = table.Rows[6]["value"];
            var additional = table.Rows[7]["value"];

            checkoutPage.EnterShippingInformation(firstName, surName, phone, city, country, postal, address, additional);
        }

        [When(@"I confirm the order")]
        public void WhenIConfirmTheOrder()
        {
            checkoutPage.ConfirmOrder();
        }

        [Then(@"the order should be successfully placed")]
        public void ThenTheOrderShouldBeSuccessfullyPlaced()
        {
            Assert.IsTrue(checkoutPage.IsOrderSuccessful(), "The message 'Your order has been placed successfully.' is not visible on the screen.");
        }

        [Then(@"Verify 50 percent label is visible on product")]
        public void VerifyTextInElementWithClass()
        {
            homePage.AcceptCookies();
            IWebElement element = driver.FindElement(By.CssSelector(".-OLB3"));
            string elementText = element.Text;
            Assert.AreEqual("-50 %", elementText);
        }
        
    }
}
