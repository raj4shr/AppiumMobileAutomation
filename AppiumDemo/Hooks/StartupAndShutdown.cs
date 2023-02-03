
using AventStack.ExtentReports.Reporter;
using Microsoft.AspNetCore.Razor.Language.Intermediate;

namespace AppiumDemo;
[Binding]
public class StartupAndShutdown : CommonDriver
{
    #region Private variables
    private AppiumOptions? options;
    private CapabilitiesBase? capabilities;
    private ExtentHtmlReporter? htmlReporter;
    private string? path;
    #endregion

    #region Constructor
    public StartupAndShutdown()
    {
        path= @"C:\ExtentReports\" + "Appium" + DateTime.Now.ToString("_MMddyyyy_hhmmss") + @"\index.html";
        extentReports=new ExtentReports();
        capabilities = new CapabilitiesBase();
        options = new AppiumOptions();
        htmlReporter =new ExtentHtmlReporter(path);
        extentReports.AttachReporter(htmlReporter);
    }
    #endregion

    #region SpecFlow hooks
    [BeforeScenario]
    public void InitCapabilities()
    {
        
        options.AddAdditionalCapability(MobileCapabilityType.DeviceName, capabilities.deviceNamePixel4API30);
        options.AddAdditionalCapability(MobileCapabilityType.PlatformName, capabilities.platformName);
        options.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, capabilities.platformVersion);
        options.AddAdditionalCapability(MobileCapabilityType.AutomationName, capabilities.automationName);
        driver = new AndroidDriver<AndroidElement>(new Uri("http://localhost:4723/wd/hub"), options);
        driver.PressKeyCode(AndroidKeyCode.Home);
    }

    [AfterScenario]
    public void shutDown()
    {
        if (driver != null)
        {
            extentReports.Flush();
            driver.Navigate().Back();
            driver.PressKeyCode(AndroidKeyCode.Home);
            driver.Quit();
            driver = null;
        }
    }
    #endregion
}
