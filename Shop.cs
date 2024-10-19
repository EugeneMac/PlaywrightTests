using Microsoft.Playwright;

namespace PlaywrightTests
{
    internal class Shop: BasePage
    {
        public async Task<Shop> LogIn()
        {
            await NavigateTo(Settings.baseLink);
            await _page.Locator(Selectors.userNameInput).FillAsync(Settings.userName);
            await _page.Locator(Selectors.userPassInput).FillAsync(Settings.userPass);
            await _page.Locator(Selectors.loginButton).ClickAsync();
            await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            return this;
        }

        public async Task<Shop> AddToCart(string productName)
        {
            await _page.Locator(Selectors.addToCartShopButton.Replace("%productName%", productName)).ClickAsync();
            return this;
        }

        public async Task<Shop> SelectProduct(string productName)
        {
            await _page.Locator(Selectors.product.Replace("%productName%", productName)).ClickAsync();
            return this;
        }

        public async Task<Shop> Logout()
        {
            await _page.Locator(Selectors.shopMenuButton).ClickAsync();
            await _page.Locator(Selectors.shopMenuLogoutOption).ClickAsync();
            return this;
        }
    }
}
