using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace WebDriverPageObjects
{
    public class FeaturedDeal
    {

        private IWebElement productName;

        private IWebElement productImage;

        private IWebElement oldPrice;

        private IWebElement discount;

        //Set the locators properly for the ones below

        private IWebElement actualPriceOrDetailsLink;

        private IWebElement hasfreeShipping;

        private IWebElement hasMoreOptions;

        private IWebElement isHot;

        private IWebElement isAlmostGone;

    }
}
