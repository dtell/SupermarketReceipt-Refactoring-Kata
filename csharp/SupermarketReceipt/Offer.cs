using System;

namespace SupermarketReceipt
{
    public abstract class Offer
    {
        public Product Product { get; }
        public double Argument { get; }

        protected const int x = 1;

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

    public class TwoForAmountOffer : Offer
    {
        protected new const int x = 2;
        public TwoForAmountOffer(Product product, double argument) : base(product, argument)
        {

        }

        public override Discount GetDiscount(double quantity, double unitPrice)
        {
            var quantityAsInt = (int)quantity;
            var numberOfXs = quantityAsInt / x;

            if (quantityAsInt >= x)
            {
                double total = Argument * quantityAsInt / x + quantityAsInt % x * unitPrice;
                double discountN = unitPrice * quantity - total;
                return new Discount(Product, "2 for " + Argument, discountN);
            }

            return null;
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

    public class FiveForAmountOffer : Offer
    {
        protected new const int x = 5;

        public FiveForAmountOffer(Product product, double argument) : base(product, argument)
        {
        }
        public override Discount GetDiscount(double quantity, double unitPrice)
        {
            Discount discount = null;
            var quantityAsInt = (int)quantity;
            var numberOfXs = quantityAsInt / x;

            if (quantityAsInt >= x)
            {
                var discountTotal = unitPrice * quantity - (Argument * numberOfXs + quantityAsInt % x * unitPrice);
                discount = new Discount(Product, x + " for " + Argument, discountTotal);
            }
            
            return discount;
        }
    }


}

