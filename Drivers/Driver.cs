using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;
using TechTalk.SpecFlow;

namespace SpecflowPlaywrightProject.Drivers
{
    [Binding]
    //This driver extentiates the playwright objects
    //The Driver Pattern is simply an additional layer between your step definitions and your automation code.
    public class Driver : IDisposable
    {

        //Define properties that will allow you to access the page objects
        private readonly Task<IPage> _page;
        private IBrowser? _browser;


        public Driver() => _page = Task.Run(InitializePlaywright);

        //property
        public IPage Page => _page.Result;

        //Dispose browser after test is ran
        public void Dispose() => _browser?.CloseAsync();

        //Initialise playwright
        private async Task<IPage> InitializePlaywright()
        {
            //Playwright
            var playwright = await Playwright.CreateAsync();
            //Define Browser
            _browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {

            Headless = false

            });

            //Page
            return await _browser.NewPageAsync();
        }
    }
}
