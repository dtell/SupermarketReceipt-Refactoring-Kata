namespace SupermarketReceipt
{
    public enum SpecialOfferType
    {
        ThreeForTwo, TenPercentDiscount, TwoForAmount, FiveForAmount
    }

    public class Offer
    {
        public SpecialOfferType? OfferType { get; }
        public Product Product { get; }
        public double Argument { get; }

        public Offer(SpecialOfferType? offerType, Product product, double argument)
        {
            this.OfferType = offerType;
            this.Argument = argument;
            this.Product = product;
        }

    }

    public class ThreeForTwo : Offer
    {
        public ThreeForTwo(Product product, double argument) : base(null, product, argument)
        {
        }
    }

    public class TwoForAmountOffer : Offer
    {
        public TwoForAmountOffer(Product product, double argument) : base(null, product, argument)
        {

        }
    }

    public class TenPercentDiscountOffer : Offer
    {
        public TenPercentDiscountOffer(Product product, double argument) : base(null, product, argument)
        {
        }
    }

    public class FiveForAmountOffer : Offer
    {
        public FiveForAmountOffer(Product product, double argument) : base(null, product, argument)
        {
        }
    }


}

