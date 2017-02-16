using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Text;

namespace WebDriverPageObjects
{
    public class AdvancedSearch : BasePageObject
    {

        [FindsBy(How = How.Id, Using = "_nkw")]
        private IWebElement inputKeyWordOrItemNumber;

        [FindsBy(How = How.Id, Using = "_ex_kw")]
        private IWebElement inputExludeWords;

        [FindsBy(How = How.Id, Using = "e1-1")]
        private IWebElement listCategories;

        [FindsBy(How = How.CssSelector, Using = "div.adv-s.mb.space-top button.btn.btn-prim")]
        private IWebElement btnSearch;

        [FindsBy(How = How.Id, Using = "LH_ItemConditionNew")]
        public IWebElement chkbxCondition_new;

        [FindsBy(How = How.Id, Using = "LH_ItemConditionUsed")]
        public IWebElement chkbxCondition_used;

        [FindsBy(How = How.Id, Using = "LH_ItemConditionNS")]
        public IWebElement chkbxCondition_unspecified;

        public AdvancedSearch(IWebDriver driver) : base(driver)
        { }

        public object EnumDisplayStatus { get; private set; }

        public void SetKeyWordOrItemNumber(string keyWord)
        {
            inputKeyWordOrItemNumber.Clear();
            inputKeyWordOrItemNumber.SendKeys(keyWord);
        }

        public void SetExludedKeyWords(string keyWord)
        {
            inputExludeWords.SendKeys(keyWord);
        }

        public void SetExludedKeyWords(List<string> keyWords)
        {
            var sb = new StringBuilder();
            foreach (var str in keyWords)
            {
                sb.Append(str + " ");
            }

            inputExludeWords.SendKeys(sb.ToString());
        }

        public void SelectCategory(string category)
        {
            var select = new SelectElement(listCategories);
            select.SelectByText(category);

        }

        public void Search()
        {
            btnSearch.Click();
        }


        //The following methods are not quite necessary. Can be handled directly in the test by the public attributes.
        public void Condition_New(bool isNew)
        {
           if(!chkbxCondition_new.Enabled)
                throw new System.Exception("The checkbox for the New Condition is not enabled");
            if(chkbxCondition_new.Selected != isNew) chkbxCondition_new.Click();

        }

        public void Condition_Used(bool isUsed)
        {
            if (!chkbxCondition_used.Enabled)
                throw new System.Exception("The checkbox for the Used Condition is not enabled");
            if (chkbxCondition_used.Selected != isUsed) chkbxCondition_used.Click();


        }

        public void Condition_NotSpecified(bool isUnspecified)
        {
            if (!chkbxCondition_unspecified.Enabled)
                throw new System.Exception("The checkbox for the Not Specified Condition is not enabled");
            if (chkbxCondition_unspecified.Selected != isUnspecified) chkbxCondition_unspecified.Click();
        }
    }
}