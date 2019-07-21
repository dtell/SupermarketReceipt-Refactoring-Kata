using System;

namespace SupermarketReceipt
{
    public abstract class Offer
    {
        public Product Product { get; }

        protected int NumberOfItems = 1;

        protected Offer(Product product)
        {
            this.Product = product;
        }

        public abstract Discount GetDiscount(double quantity, double unitPrice);

    }

    public class ThreeForTwo : Offer
    {
        protected new const int x = 3;
        public ThreeForTwo(Product product, double argument) : base(product)
        {
        }

        public override Discount GetDiscount(double quantity, double unitPrice)
        {
            Discount discount = null;
            var quantityAsInt = (int)quantity;

            var numberOfXs = quantityAsInt / x;

            if (quantityAsInt > 2)
            {
                var discountAmount = quantity * unitPrice - ((numberOfXs * 2 * unitPrice) + quantityAsInt % 3 * unitPrice);
                discount = new Discount(Product, "3 for 2", discountAmount);
            }

            return discount;
        }
    }

    public class TenPercentDiscountOffer : Offer
    {
        public double Percentage {get;}

        public TenPercentDiscountOffer(Product product, double percentage) : base(product)
        {
            Percentage = percentage;
        }

        public override Discount GetDiscount(double quantity, double unitPrice)
        {
            return new Discount(Product, Percentage + "% off", quantity * unitPrice * Percentage / 100.0);
        }
    }

    public class NumberOfItemsForAmountOffer : Offer
    {
        public double Amount { get; }

        public NumberOfItemsForAmountOffer(Product product, int numberOfItems, double amount) : base(product)
        {
            NumberOfItems = numberOfItems;
            Amount = amount;
        }
        public override Discount GetDiscount(double quantity, double unitPrice)
        {
            Discount discount = null;
            var quantityAsInt = (int)quantity;
            var numberOfXs = quantityAsInt / NumberOfItems;

            if (quantityAsInt >= NumberOfItems)
            {
                var total = (Amount * numberOfXs + quantityAsInt % NumberOfItems * unitPrice);
                var discountTotal = unitPrice * quantity - total;
                discount = new Discount(Product, NumberOfItems + " for " + Amount, discountTotal);
            }
            
            return discount;
        }
    }


}

