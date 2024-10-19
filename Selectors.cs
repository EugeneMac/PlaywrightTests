namespace PlaywrightTests
{
    internal static class Selectors
    {
        #region Login page
        public static string userNameInput => "//input[@data-test = 'username']";
        public static string userPassInput => "//input[@data-test = 'password']";
        public static string loginButton => "//input[@data-test = 'login-button']";
        #endregion

        #region Shop page
        public static string shopLogo => "//div[@class='app_logo']";
        public static string product => "//div[@data-test='inventory-item-name' and contains(.,'%productName%')]";
        public static string addToCartShopButton => "//a[contains(.,'%productName%')]/parent::div/following-sibling::div[@class='pricebar']/button";
        public static string shopMenuButton => "//button[@id='react-burger-menu-btn']";
        public static string shopMenuLogoutOption => "//a[@data-test='logout-sidebar-link']";
        #endregion

        #region Product page
        public static string productName => "//div[@data-test = 'inventory-item-name']";
        public static string productDescription => "//div[@data-test = 'inventory-item-desc']";
        public static string productPrice => "//div[@data-test = 'inventory-item-price']";
        public static string addToCartProductButton => "//button[@data-test = 'add-to-cart']";
        public static string removeProductButton => "//button[@data-test = 'remove']";
        public static string cartProductsNumber => "//span[@data-test = 'shopping-cart-badge']";
        public static string cartButton => "//a[@data-test = 'shopping-cart-link']";
        #endregion

        #region Cart page
        public static string cartTitle => "//span[@data-test = 'title']";
        public static string cartProductQuantity => "//div[@data-test = 'inventory-item-name' and contains(.,'%productName%')]/parent::a/parent::div/preceding-sibling::div";
        public static string cartProductDescription => "//div[@data-test = 'inventory-item-name' and contains(.,'%productName%')]/parent::a/following-sibling::div[@data-test='inventory-item-desc']";
        public static string cartProductPrice => "//div[@data-test = 'inventory-item-name' and contains(.,'%productName%')]/parent::a/following-sibling::div/div[@data-test='inventory-item-price']";
        public static string checkoutButton => "//button[@data-test = 'checkout']";
        #endregion

        #region Checkout pages
        public static string checkoutTitle => "//span[@data-test = 'title']";
        public static string clientFirstNameInput => "//input[@data-test = 'firstName']";
        public static string clientLastNameInput => "//input[@data-test = 'lastName']";
        public static string clientZipCodeInput => "//input[@data-test = 'postalCode']";
        public static string paymentInformation => "//div[@data-test = 'payment-info-value']";
        public static string shippingInformation => "//div[@data-test = 'shipping-info-value']";
        public static string subTotal => "//div[@data-test = 'subtotal-label']";
        public static string tax => "//div[@data-test = 'tax-label']";
        public static string total => "//div[@data-test = 'total-label']";
        public static string checkoutContinueButton => "//input[@data-test = 'continue']";
        public static string checkoutFinishButton => "//button[@data-test = 'finish']";
        public static string ponyExpressLogo => "//img[@data-test = 'pony-express']";
        public static string completeHeader => "//h2[@data-test = 'complete-header']";
        public static string completeText => "//div[@data-test = 'complete-text']";
        #endregion

    }
}
