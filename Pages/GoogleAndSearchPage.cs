using OpenQA.Selenium;
using SpecflowProjectDeneme.Hooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowProjectDeneme.Pages
{
   
    class GoogleAndSearchPage
    {

        public IWebDriver driver = Hook.driver;

        public void GoToLink(string url)
        {
            driver.Navigate().GoToUrl(url);

           
        }

        public void SearchNasa( string nasaa)
        {
            IWebElement searchNasa = driver.FindElement(By.XPath("//textarea[@id='APjFqb']"));
            searchNasa.SendKeys(nasaa);
            IWebElement enterNasaText = driver.FindElement(By.XPath("//*[@id=\"jZ2SBf\"]/div[1]/span"));

            enterNasaText.Click();
            Thread.Sleep(1000);

        }
        public void ClickTheNasa()
        {
            IWebElement clickTheNasa = driver.FindElement(By.XPath("//h3[.='NASA']"));
            clickTheNasa.Click();
            Thread.Sleep(2000);
           
        }
        public void ClickToMoonToMarsMenu()
        {
            IWebElement clickTheMoonToMars = driver.FindElement(By.XPath(" //a[.='Moon to Mars']"));
            clickTheMoonToMars.Click();
            Thread.Sleep(3000);
            driver.Quit();
        }

       
    }
}
