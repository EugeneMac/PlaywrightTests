using Microsoft.Playwright;

namespace PlaywrightTests
{
    [TestFixture]
    public class BuyTShirtTests: BasePage
    {
        private Shop _shop;
        private Product _product;
        private Cart _cart;
        private Checkout _checkout;
        private String _productName;
        private String _productDescription;
        private String _productPrice;

        [SetUp]
        public void Setup()
        {
        }

        [TearDown]
        public void Teardown()
        {
        }

        // Data-driven approach with test data to buy different products with the same test
        private static IEnumerable<TestCaseData> GetTestData()
        {
            yield return new TestCaseData("Sauce Labs Bolt T-Shirt", "Get your testing superhero on with the Sauce Labs bolt T-shirt. From American Apparel, 100% ringspun combed cotton, heather gray with red bolt.", "$15.99");
            yield return new TestCaseData("Test.allTheThings() T-Shirt (Red)", "This classic Sauce Labs t-shirt is perfect to wear when cozying up to your keyboard to automate a few tests. Super-soft and comfy ringspun combed cotton.", "$15.99");
        }

        public BuyTShirtTests()
        {
            _shop = new Shop();
            _product = new Product();
            _cart = new Cart();
            _checkout = new Checkout();
        }

        [Test, TestCaseSource("GetTestData")]
        public async Task BuyTShirt(String _productName, String _productDescription, String _productPrice)
        {
            await _shop.LogIn();

            Assert.That((await _page.TitleAsync()), Is.EqualTo(Settings.inventoryTitle));
            Assert.That((_page.Url), Is.EqualTo(Settings.inventoryLink));
            Assert.That((await _page.Locator(Selectors.shopLogo).InnerTextAsync()), Is.EqualTo(Settings.inventoryTitle));

            await _shop.SelectProduct(_productName);

            Assert.That((await _page.Locator(Selectors.productName).InnerTextAsync()), Is.EqualTo(_productName));
            Assert.That((await _page.Locator(Selectors.productDescription).InnerTextAsync()), Is.EqualTo(_productDescription));
            Assert.That((await _page.Locator(Selectors.productPrice).InnerTextAsync()), Is.EqualTo(_productPrice));

            await _product.AddToCart(_productName);

            Assert.That((await _page.Locator(Selectors.removeProductButton).IsVisibleAsync()), Is.True);
            Assert.That((await _page.Locator(Selectors.cartProductsNumber).InnerTextAsync()), Is.EqualTo("1"));

            await _product.ClickCart();

            Assert.That((_page.Url), Is.EqualTo(Settings.cartLink));
            Assert.That((await _page.Locator(Selectors.cartTitle).InnerTextAsync()), Is.EqualTo("Your Cart"));
            // checks that quantity for particular product in a cart is 1 and that the name of the product is correct (via contains() in selector)
            Assert.That((await _page.Locator(Selectors.cartProductQuantity.Replace("%productName%", _productName)).InnerTextAsync()), Is.EqualTo("1"));
            Assert.That((await _page.Locator(Selectors.cartProductDescription.Replace("%productName%", _productName)).InnerTextAsync()), Is.EqualTo(_productDescription));
            Assert.That((await _page.Locator(Selectors.cartProductPrice.Replace("%productName%", _productName)).InnerTextAsync()), Is.EqualTo(_productPrice));

            await _cart.Checkout();

            Assert.That((_page.Url), Is.EqualTo(Settings.checkoutStepOneLink));
            Assert.That((await _page.Locator(Selectors.cartTitle).InnerTextAsync()), Is.EqualTo("Checkout: Your Information"));
            
            //using default client test data
            await _checkout.FillClientInfo();
            await _checkout.Continue();

            Assert.That((_page.Url), Is.EqualTo(Settings.checkoutStepTwoLink));
            Assert.That((await _page.Locator(Selectors.cartTitle).InnerTextAsync()), Is.EqualTo("Checkout: Overview"));
            Assert.That((await _page.Locator(Selectors.paymentInformation).InnerTextAsync()), Is.EqualTo("SauceCard #31337"));
            Assert.That((await _page.Locator(Selectors.shippingInformation).InnerTextAsync()), Is.EqualTo("Free Pony Express Delivery!"));
            Assert.That((await _page.Locator(Selectors.subTotal).InnerTextAsync()), Does.Contain("Item total:").And.Contain(_productPrice));

            var itemPrice = Double.Parse(_productPrice.Substring(1).Replace(".", ","));
            var tax = Math.Round(itemPrice * 0.08, 2);
            var total = itemPrice + tax;

            Assert.That((await _page.Locator(Selectors.tax).InnerTextAsync()), Does.Contain("Tax: $").And.Contain(tax.ToString().Replace(",", ".")));
            Assert.That((await _page.Locator(Selectors.total).InnerTextAsync()), Does.Contain("Total: $").And.Contain(total.ToString().Replace(",", ".")));

            await _checkout.Finish();

            Assert.That((_page.Url), Is.EqualTo(Settings.checkoutCompleteLink));
            Assert.That((await _page.Locator(Selectors.cartTitle).InnerTextAsync()), Is.EqualTo("Checkout: Complete!"));
            Assert.That((await _page.Locator(Selectors.ponyExpressLogo).IsVisibleAsync()), Is.True);
            Assert.That((await _page.Locator(Selectors.completeHeader).InnerTextAsync()), Is.EqualTo("Thank you for your order!"));
            Assert.That((await _page.Locator(Selectors.completeText).InnerTextAsync()), Is.EqualTo("Your order has been dispatched, and will arrive just as fast as the pony can get there!"));

            await _shop.Logout();

            Assert.That((_page.Url), Is.EqualTo(Settings.baseLink));
        }
    }
}