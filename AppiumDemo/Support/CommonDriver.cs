global using OpenQA.Selenium;
global using OpenQA.Selenium.Appium.Android;
global using OpenQA.Selenium.Support.UI;
global using System.Collections.ObjectModel;
global using OpenQA.Selenium.Appium;
global using OpenQA.Selenium.Appium.Enums;
global using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
global using AventStack.ExtentReports;

namespace AppiumDemo;


public class CommonDriver
{
    //public AndroidDriver<AndroidElement>? driver;
    public static AndroidDriver<AndroidElement>? driver { get; set; }

    public static ExtentReports? extentReports { get; set; }



}
