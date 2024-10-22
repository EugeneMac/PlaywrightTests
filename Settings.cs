namespace PlaywrightTests
{
    public static class Settings
    {
        public static string baseLink => "https://www.saucedemo.com/";
        public static string inventoryLink => baseLink + "inventory.html";
        public static string cartLink => baseLink + "cart.html";
        public static string checkoutStepOneLink => baseLink + "checkout-step-one.html";
        public static string checkoutStepTwoLink => baseLink + "checkout-step-two.html";
        public static string checkoutCompleteLink => baseLink + "checkout-complete.html";
        public static string inventoryTitle => "Swag Labs";
    }
}
