using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using Automatski_Testovi.Static_elements;

namespace Automatski_Testovi.Pages
{
    public class CommonElements
    {
        public IWebDriver driver;
        public WebDriverWait wait;
        public StaticData staticData = new StaticData();

        protected CommonElements(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


    }
}
