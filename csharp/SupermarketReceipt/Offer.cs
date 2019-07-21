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

        public virtual  Discount GetDiscount(Product p, double quantity, double unitPrice, int? quantityAsInt = null) {throw new NotImplementedException();}

    }

    public class ThreeForTwo : Offer
    {
        public ThreeForTwo(Product product, double argument) : base(product, argument)
        {
        }
    }

    public class TwoForAmountOffer : Offer
    {
        public TwoForAmountOffer(Product product, double argument) : base(product, argument)
        {

        }

        public override Discount GetDiscount(Product p, double quantity, double unitPrice, int? quantityAsInt)
        {
            var x = 2;
            if (quantityAsInt.HasValue && quantityAsInt.Value >= 2)
            {
                double total = Argument * quantityAsInt.Value / x + quantityAsInt.Value % 2 * unitPrice;
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

        public override Discount GetDiscount(Product p, double quantity, double unitPrice, int? quantityAsInt = null)
        {
            return new Discount(p, Argument + "% off", quantity * unitPrice * Argument / 100.0);
        }
    }

    public class FiveForAmountOffer : Offer
    {
        public FiveForAmountOffer(Product product, double argument) : base(product, argument)
        {
        }
    }


}

