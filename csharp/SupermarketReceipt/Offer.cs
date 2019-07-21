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

        public virtual  Discount GetDiscount(Product p, double quantity, double unitPrice) {throw new NotImplementedException();}

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
    }


}

