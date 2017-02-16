using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace WebDriverPageObjects
{
    public class DailyDeal
    {

        [FindsBy(How = How.CssSelector, Using = "a.clr span.tl")]
        private IWebElement productName;

        [FindsBy(How = How.CssSelector, Using = "div.info span.prc")]
        private IWebElement price;

        [FindsBy(How = How.CssSelector, Using = "div.prom.prom140 span.gspr")]
        private IWebElement discount;

        [FindsBy(How = How.CssSelector, Using = "a.clr div.icon img")]
        private IWebElement image;


        public string GetProductName()
        {
            return productName.Text;
        }

        public double GetProductPrice()
        {
            var prc = price.Text.Split('$')[1].Replace(" ", string.Empty);
            return double.Parse(prc);
        }

        public short GetProductDiscount()
        {
            var dsc = discount.Text.Split('%')[0];
            return short.Parse(dsc);
        }

        public string GetImageUrl()
        {
            return image.GetAttribute("src");
        }

    }
}