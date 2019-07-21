using System;

namespace SupermarketReceipt
{
    public abstract class Offer
    {
        public Product Product { get; }
        public double Argument { get; }

        protected int NumberOfItems = 1;

        public Offer(Product product, double argument)
        {
            this.Argument = argument;
            this.Product = product;
        }

        public abstract Discount GetDiscount(double quantity, double unitPrice);

    }

    public class ThreeForTwo : Offer
    {
        protected new const int x = 3;
        public ThreeForTwo(Product product, double argument) : base(product, argument)
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
        public TenPercentDiscountOffer(Product product, double argument) : base(product, argument)
        {
        }

        public override Discount GetDiscount(double quantity, double unitPrice)
        {
            return new Discount(Product, Argument + "% off", quantity * unitPrice * Argument / 100.0);
        }
    }

    public class NumberOfItemsForAmountOffer : Offer
    {

        public NumberOfItemsForAmountOffer(Product product, int numberOfItems, double argument) : base(product, argument)
        {
            this.NumberOfItems = numberOfItems;
        }
        public override Discount GetDiscount(double quantity, double unitPrice)
        {
            Discount discount = null;
            var quantityAsInt = (int)quantity;
            var numberOfXs = quantityAsInt / NumberOfItems;

            if (quantityAsInt >= NumberOfItems)
            {
                var total = (Argument * numberOfXs + quantityAsInt % NumberOfItems * unitPrice);
                var discountTotal = unitPrice * quantity - total;
                discount = new Discount(Product, NumberOfItems + " for " + Argument, discountTotal);
            }
            
            return discount;
        }
    }


}

