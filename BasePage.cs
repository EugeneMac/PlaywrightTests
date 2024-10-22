using Microsoft.Playwright;
using System.Configuration;

namespace PlaywrightTests
{
    public class BasePage
    {
        public static IBrowserContext _context;
        public static IPlaywright _playwright;
        public static IBrowser _browser;
        public static IPage _page;

        public static String user
        {
            get
            {
                var username = Environment.GetEnvironmentVariable("SAUCE_USERNAME");
                var secret_user = Environment.GetEnvironmentVariable("SECRET_USER");
                if (username != null && username != "") return username;
                if (secret_user != null && secret_user != "") return secret_user;
                else return ConfigurationManager.AppSettings["user"]; ;
            }
        }
        public static String password
        {
            get
            {
                var pass = Environment.GetEnvironmentVariable("SAUCE_PASSWORD");
                var secret_pass = Environment.GetEnvironmentVariable("SECRET_PASSWORD");
                if (pass != null && pass != "") return pass;
                if (secret_pass != null && secret_pass != "") return secret_pass;
                else return ConfigurationManager.AppSettings["password"]; ;
            }
        }

        public async Task<IPage> NavigateTo(string link)
        {
            _playwright = await Playwright.CreateAsync();
            string maximized = "--start-maximized";
            _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
                SlowMo = 80,
                Timeout = 90000,
                Args = [maximized]
            });
            _context = await _browser.NewContextAsync(new BrowserNewContextOptions
            {
                ViewportSize = new ViewportSize() { Width = 1920, Height = 1080 }
            });
            _page = await _context.NewPageAsync();
            await _page.GotoAsync(link, new PageGotoOptions() { Timeout = 90000 });
            return _page;
        }
    }
}


