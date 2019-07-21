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
            foreach (var p in _productQuantities.Keys)
            {
                var quantity = _productQuantities[p];
                var quantityAsInt = (int)quantity;
                if (offers.ContainsKey(p))
                {
                    var offer = offers[p];
                    var unitPrice = catalog.GetUnitPrice(p);
                    Discount discount = null;
                    var x = 1;
                    if (offer.GetType() == typeof(ThreeForTwo))
                    {
                        x = 3;

                    }
                    else if (offer.GetType() == typeof(TwoForAmountOffer))
                    {
                        discount = offer.GetDiscount(p, quantity, unitPrice, quantityAsInt);
                    }
                    if (offer.GetType() == typeof(FiveForAmountOffer))
                    {
                        x = 5;
                    }
                    var numberOfXs = quantityAsInt / x;
                    if (offer.GetType() == typeof(ThreeForTwo))
                    {
                        discount = offer.GetDiscount(p, quantity, unitPrice, quantityAsInt, numberOfXs);
                    }
                    if (offer.GetType() == typeof(TenPercentDiscountOffer))
                    {
                        discount = offer.GetDiscount(p, quantity, unitPrice);
                    }
                    if (offer.GetType() == typeof(FiveForAmountOffer))
                    {
                        discount = offer.GetDiscount(p, quantity, unitPrice, quantityAsInt, numberOfXs, x);
                    }
                    if (discount != null)
                        receipt.AddDiscount(discount);
                }

            }
        }


    }

}
