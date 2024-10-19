using Microsoft.Playwright;

namespace PlaywrightTests
{
    public class BasePage: IDisposable
    {
        public static IBrowserContext _context;
        public static IPlaywright _playwright;
        public static IBrowser _browser;
        public static IPage _page;

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
                ViewportSize = new ViewportSize() { Width = 1920, Height = 1080}
            });
            _page = await _context.NewPageAsync();
            await _page.GotoAsync(link, new PageGotoOptions() { Timeout = 90000});
            return _page;
        }
        public async void Dispose()
        {
            await _context.CloseAsync();
            await _browser.CloseAsync();
        }
    }
}


