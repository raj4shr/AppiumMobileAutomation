using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppiumDemo;

public class ElementInteractions : CommonDriver
{
    #region Private variables
    private WebDriverWait wait;
    #endregion

    #region Constructor
    public ElementInteractions()
    {
        wait=new WebDriverWait(driver, TimeSpan.FromSeconds(20));   
    }
    #endregion

    #region Element actions
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

    public bool IsElementDisplayed(By elementLocator)
    {
        wait.Until(ExpectedConditions.ElementIsVisible(elementLocator));
        return driver.FindElement(elementLocator).Displayed;
        
    }

    public ReadOnlyCollection<AndroidElement> GetAllElementsByLocator(By elementLocator)
    {
        return driver.FindElements(elementLocator);
    }
    #endregion
}
