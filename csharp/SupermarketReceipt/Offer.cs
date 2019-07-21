using System;

namespace SupermarketReceipt
{
    public abstract class Offer
    {
        public Product Product { get; }
        public double Argument { get; }

        public Offer(Product product, double argument)
        {
            this.Argument = argument;
            this.Product = product;
        }

        public abstract Discount GetDiscount(Product p, double quantity, double unitPrice);

    }

    public class ThreeForTwo : Offer
    {
        public ThreeForTwo(Product product, double argument) : base(product, argument)
        {
        }

        public override Discount GetDiscount(Product p, double quantity, double unitPrice)
        {
            Discount discount = null;
            var quantityAsInt = (int)quantity;
            var x = 3;
            var numberOfXs = quantityAsInt / x;

            if (quantityAsInt > 2)
            {
                var discountAmount = quantity * unitPrice - ((numberOfXs * 2 * unitPrice) + quantityAsInt % 3 * unitPrice);
                discount = new Discount(p, "3 for 2", discountAmount);
            }

            return discount;
        }
    }

    public class TwoForAmountOffer : Offer
    {
        public TwoForAmountOffer(Product product, double argument) : base(product, argument)
        {

        }

        public override Discount GetDiscount(Product p, double quantity, double unitPrice)
        {
            var x = 2;
            var quantityAsInt = (int)quantity;
            var numberOfXs = quantityAsInt / x;

            if (quantityAsInt >= 2)
            {
                double total = Argument * quantityAsInt / x + quantityAsInt % 2 * unitPrice;
                double discountN = unitPrice * quantity - total;
                return new Discount(p, "2 for " + Argument, discountN);
            }

            return null;
        }
    }

    public class TenPercentDiscountOffer : Offer
    {
        public TenPercentDiscountOffer(Product product, double argument) : base(product, argument)
        {
        }

        public override Discount GetDiscount(Product p, double quantity, double unitPrice)
        {
            return new Discount(p, Argument + "% off", quantity * unitPrice * Argument / 100.0);
        }
    }

    public class FiveForAmountOffer : Offer
    {
        public FiveForAmountOffer(Product product, double argument) : base(product, argument)
        {
        }
        public override Discount GetDiscount(Product p, double quantity, double unitPrice)
        {
            Discount discount = null;
            var quantityAsInt = (int)quantity;
            var x = 5;
            var numberOfXs = quantityAsInt / x;

            if (quantityAsInt >= 5)
            {
                var discountTotal = unitPrice * quantity - (Argument * numberOfXs + quantityAsInt % 5 * unitPrice);
                discount = new Discount(p, x + " for " + Argument, discountTotal);
            }
            
            return discount;
        }
    }


}

