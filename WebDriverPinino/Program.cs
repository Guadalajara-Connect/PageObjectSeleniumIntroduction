using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Linq;

namespace WebDriverPageObjects
{
    public class TestScript
    {

        public static void Main(string[] args)
        {
            //Preconditions
            var driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://www.ebay.com");

            //The test starts.
            var _home = new HomePage(driver);
            var collections = _home.GetFeaturedProducts();
            var deals = _home.GetDailyDeals();

            var prod = collections.ToList()[0];
            var deal = deals.ToList()[0]; //Defect XYZ : The Daily Deals are not always loaded.

            Assert.AreEqual(prod.GetCollectionTitle(), "Un Yogi enamorado");
            Assert.AreEqual(prod.GetNumberOfItems(), 37);
            Assert.AreEqual(deal.GetProductPrice(), 815.01);

            _home.ShopByCategory("Tecnología");

            _home.SelectSearchCategory("Libros");
            _home.SetSearchCriteria("Systems Performance");
            _home.ExecuteSearch();

            var advSrch = _home.GoToAdvancedSearch();
            advSrch.SetKeyWordOrItemNumber("3D Printers");
            advSrch.Search();
            //The test has finished


            //Postconditions
            driver.Close();
            driver.Quit();

        }
    }
}