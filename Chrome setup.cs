using System;
using System.IO;

public class ChromeSetup
{
	public ChromeSetup()
	{

        private readonly IWebDriver driver = new ChromeDriver();

        [SetUp]
        public IWebDriver Setup()
        {
            var chromedirectory = Directory.GetCurrentDirectory();
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            IWebDriver driver = new ChromeDriver(chromedirectory, options);
            return driver;
        }
    }
}
