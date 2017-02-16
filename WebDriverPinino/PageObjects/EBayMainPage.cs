using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;

namespace WebDriverPageObjects
{
    public abstract class EBayMainPage : BasePageObject
    {
        [FindsBy(How = How.Id, Using = "gh")]
        private IWebElement webElementNavigationMenuBar;

        public EBayMainPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public void ShopByCategory(string category)
        {
            var categories = new List<IWebElement>();

            webElementNavigationMenuBar.FindElement(By.Id("gh-shop-a")).Click();
            var categoriesElementsColumns = webElementNavigationMenuBar.FindElements(By.CssSelector("table#gh-sbc tr td"));
            foreach (var itm in categoriesElementsColumns)
            {
                var parents = itm.FindElements(By.CssSelector("h3.gh-sbc-parent"));
                foreach (var parent in parents)
                {
                    categories.Add(parent.FindElement(By.TagName("a")));
                }

                var elements = itm.FindElements(By.CssSelector("ul")).SelectMany(li => li.FindElements(By.TagName("li"))).Select(tag => tag.FindElement(By.TagName("a")));
                categories.AddRange(elements);
                var selection = categories.FirstOrDefault(sel => sel.Text.Equals(category));

                selection?.Click();
            }
        }


        public void SetSearchCriteria(string searchString)
        {
            var textInput = webElementNavigationMenuBar.FindElement(By.Id("gh-ac"));
            textInput.SendKeys(searchString);
        }

        public void SelectSearchCategory(string categoryName)
        {
            var dropDownCategoryList = webElementNavigationMenuBar.FindElement(By.Id("gh-cat"));
            var selectCategory = new SelectElement(dropDownCategoryList);
            selectCategory.SelectByText(categoryName);
        }

        public void ExecuteSearch()
        {
            var searchBtn = webElementNavigationMenuBar.FindElement(By.Id("gh-btn"));
            searchBtn.Click();
        }

        public AdvancedSearch GoToAdvancedSearch()
        {
            webElementNavigationMenuBar.FindElement(By.CssSelector("a#gh-as-a")).Click();
            return PageFactory.InitElements<AdvancedSearch>(drv);
        }
    }
}
