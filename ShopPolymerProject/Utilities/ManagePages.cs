using DropitUI.ShopPolymerProject.PageObjects;


namespace DropitUI.ShopPolymerProject.Utilities
{
    internal class ManagePages : CommonOps
    {
        public static void InitElements()
        {
            items = new Items();
            topMenu = new TopMenu();
            shoppingCart = new ShoppingCart();
            checkout = new Checkout();
        }

    }
}
