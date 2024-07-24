using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestStore.PageObjects
{
    public class ProductPage
    {
        private readonly IWebDriver _driver;
        private readonly By _inStockFilter = By.XPath("//main//a[2]");
        private readonly By _productCardContainer = By.CssSelector("[data-testid='productCardContainer']");

        public ProductPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void FilterInStockProducts()
        {
            _driver.FindElement(_inStockFilter).Click();
        }

        public void BuyFirstInStockNonPromoProduct()
        {
            var productContainers = _driver.FindElements(_productCardContainer);

            foreach (var productContainer in productContainers)
            {
                var oldPriceElements = productContainer.FindElements(By.CssSelector("[data-testid='productOldPrice']"));

                if (oldPriceElements.Count == 0)
                {
                    var buyButton = productContainer.FindElement(By.CssSelector("[data-testid='addToCartButton']"));
                    buyButton.Click();
                    break;
                }
            }
        }
    }
}
