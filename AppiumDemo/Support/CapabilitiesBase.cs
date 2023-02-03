namespace AppiumDemo;

public class CapabilitiesBase
{
    #region Properties
    public string? deviceNamePixel4API30 { get;}
    public string? deviceNamePixel6ProAPI30 { get; }
    public string? platformName { get; }
    public string? platformVersion { get; }
    public string? automationName { get; }
    #endregion

    #region Constructor
    public CapabilitiesBase()
    {
        deviceNamePixel4API30 = "Pixel 4 API 30";
        deviceNamePixel6ProAPI30 = "Pixel 6 Pro API 30";
        platformName = "Android";
        platformVersion = "11.0";
        automationName = "UIAutomator2";
    }
    #endregion
}
