using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;

namespace WebDriverPageObjects
{
    public class HomePage : EBayMainPage
    {

        [FindsBy(How = How.CssSelector, Using = "div#featuredCollectionsFragment div div.big-heros div.big-hero")]
        private IList<IWebElement> featuredProducts;

        [FindsBy(How = How.CssSelector, Using = "div#dailyDeals div.deals div.ddcrd")]
        private IList<IWebElement> dailyDeals;
        

        public HomePage(IWebDriver drv) : base(drv)
        {
            PageFactory.InitElements(drv, this);
        }


        public List<FeaturedProductCollection> GetFeaturedProducts()
        {
            var pObjList = new List<FeaturedProductCollection>();

            foreach (var product in featuredProducts)
            {
                var pobj = new FeaturedProductCollection(drv);
                PageFactory.InitElements(product,pobj);
                pObjList.Add(pobj);
            }

            return pObjList;
        }

        public List<DailyDeal> GetDailyDeals()
        {
            var deals = new List<DailyDeal>();

            foreach (var product in dailyDeals)
            {
                var pObj = new DailyDeal();
                PageFactory.InitElements(product, pObj);
                deals.Add(pObj);
            }
            return deals;
        }

    }
}