using Microsoft.Playwright;

namespace PlaywrightTests
{
    internal class Product: BasePage
    {
        public async Task<Product> AddToCart(string productName)
        {
            await _page.Locator(Selectors.addToCartProductButton).ClickAsync();
            return this;
        }

        public async Task<Product> ClickCart()
        {
            await _page.Locator(Selectors.cartButton).ClickAsync();
            return this;
        }
    }
}
