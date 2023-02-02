using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppiumDemo;

public class ElementInteractions : CommonDriver
{
    private WebDriverWait wait;

    public ElementInteractions()
    {
        wait=new WebDriverWait(driver, TimeSpan.FromSeconds(20));   
    }

    public void ClickOnElement(By elementLocator)
    {
        wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(elementLocator));
        driver.FindElement(elementLocator).Click();
    }

    public void SendKeysToElement(By elementLocator,string elementValue)
    {
        wait.Until(ExpectedConditions.ElementIsVisible(elementLocator));
        driver.FindElement(elementLocator).Clear();
        driver.FindElement(elementLocator).SendKeys(elementValue);
    }



    public ReadOnlyCollection<AndroidElement> GetAllElementsByLocator(By elementLocator)
    {
        return driver.FindElements(elementLocator);
    }
}
