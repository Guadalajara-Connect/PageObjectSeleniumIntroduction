using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace WebDriverPageObjects
{
    public abstract class BasePageObject
    {

        protected readonly IWebDriver drv = null;

        protected BasePageObject(IWebDriver driver)
        {
            drv = driver;
        }

        public IWebDriver GetDriver(IWebDriver driver) {
            return drv;
        }

    }
}
