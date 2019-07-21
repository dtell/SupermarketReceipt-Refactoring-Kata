namespace SupermarketReceipt
{
    public class Offer
    {
        public Product Product { get; }
        public double Argument { get; }

        public Offer(Product product, double argument)
        {
            this.Argument = argument;
            this.Product = product;
        }

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
    }

    public class FiveForAmountOffer : Offer
    {
        public FiveForAmountOffer(Product product, double argument) : base(product, argument)
        {
        }
    }


}

