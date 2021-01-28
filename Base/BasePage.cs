using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumExtras.PageObjects;

namespace CarOfferFramework.Base
{
    public abstract class BasePage : Base
    {
        public BasePage()
        {
            PageFactory.InitElements(DriverContext.Driver, this);
        }

    }
}
