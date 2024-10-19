using Microsoft.Playwright;

namespace PlaywrightTests
{
    internal class Cart: BasePage
    {
        public async Task<Cart> Checkout()
        {
            await _page.Locator(Selectors.checkoutButton).ClickAsync();
            return this;
        }

        public async Task<Cart> Remove(string productName)
        {
            throw new NotImplementedException();
            return this;
        }

    }
}
