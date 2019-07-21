using System.Collections.Generic;

namespace SupermarketReceipt
{
    public class ShoppingCart
    {

        private readonly List<ProductQuantity> _items = new List<ProductQuantity>();
        private readonly Dictionary<Product, double> _productQuantities = new Dictionary<Product, double>();


        public List<ProductQuantity> GetItems()
        {
            return new List<ProductQuantity>(_items);
        }

        public void AddItem(Product product)
        {
            this.AddItemQuantity(product, 1.0);
        }


        public void AddItemQuantity(Product product, double quantity)
        {
            _items.Add(new ProductQuantity(product, quantity));
            if (_productQuantities.ContainsKey(product))
            {
                var newAmount = _productQuantities[product] + quantity;
                _productQuantities[product] = newAmount;
            }
            else
            {
                _productQuantities.Add(product, quantity);
            }
        }

        public void HandleOffers(Receipt receipt, Dictionary<Product, Offer> offers, SupermarketCatalog catalog)
        {
            foreach (var product in _productQuantities.Keys)
            {
                var quantity = _productQuantities[product];
                if (offers.ContainsKey(product))
                {
                    var offer = offers[product];
                    var unitPrice = catalog.GetUnitPrice(product);
                    Discount discount = null;
                    var x = 1;
                    if (offer.GetType() == typeof(ThreeForTwo))
                    {
                        x = 3;

                    }
                    else if (offer.GetType() == typeof(TwoForAmountOffer))
                    {
                        discount = offer.GetDiscount(product, quantity, unitPrice);
                    }
                    if (offer.GetType() == typeof(FiveForAmountOffer))
                    {
                        x = 5;
                    }
                    if (offer.GetType() == typeof(ThreeForTwo))
                    {
                        discount = offer.GetDiscount(product, quantity, unitPrice, x);
                    }
                    if (offer.GetType() == typeof(TenPercentDiscountOffer))
                    {
                        discount = offer.GetDiscount(product, quantity, unitPrice);
                    }
                    if (offer.GetType() == typeof(FiveForAmountOffer))
                    {
                        discount = offer.GetDiscount(product, quantity, unitPrice, x);
                    }
                    if (discount != null)
                        receipt.AddDiscount(discount);
                }

            }
        }


    }

}
