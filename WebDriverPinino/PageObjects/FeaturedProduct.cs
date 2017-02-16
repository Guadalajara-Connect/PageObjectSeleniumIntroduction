using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace WebDriverPageObjects
{
    public class FeaturedProductCollection : BasePageObject
    {

        [FindsBy(How = How.CssSelector, Using = "div.framing-description-under div h3 a")]
        private IWebElement title;

        [FindsBy(How = How.CssSelector, Using = "div.framing-description-under div div.big-hero-info-horizontal ul li.first")]
        private IWebElement numOfItems;

        [FindsBy(How = How.CssSelector, Using = "div.framing-description-under div div.big-hero-info-horizontal ul li:nth-child(2)")]
        private IWebElement vendor;

        [FindsBy(How = How.CssSelector, Using = "div.framing-description-under div div.big-hero-info-horizontal ul li.last a")]
        private IWebElement linkShopNow;

        public FeaturedProductCollection(IWebDriver driver) : base(driver)
        { }

        public string GetCollectionTitle()
        {
            return title.Text;
        }

        public int GetNumberOfItems()
        {
            var txt = numOfItems.Text;
            return int.Parse(txt.Split()[0]);
        }

        public string GetVendorName()
        {
            return vendor.Text.Split()[1];
        }

        public string GetLink()
        {
            return linkShopNow.GetAttribute("href");
        }

        public CollectionPage GetProductCollection()
        {
            title.Click();
            return new CollectionPage(drv);
        }

    }
}