using Microsoft.Playwright;

namespace PlaywrightTests
{
    internal class Checkout: BasePage
    {
        public async Task<Checkout> FillClientInfo(string firstName = "TestClient", string lastName = "TestClient", string zipCode = "12345")
        {
            await _page.Locator(Selectors.clientFirstNameInput).FillAsync(firstName);
            await _page.Locator(Selectors.clientLastNameInput).FillAsync(lastName);
            await _page.Locator(Selectors.clientZipCodeInput).FillAsync(zipCode);
            return this;
        }

        public async Task<Checkout> Continue()
        {
            await _page.Locator(Selectors.checkoutContinueButton).ClickAsync();
            return this;
        }

        public async Task<Checkout> Finish()
        {
            await _page.Locator(Selectors.checkoutFinishButton).ClickAsync();
            return this;
        }

    }
}
