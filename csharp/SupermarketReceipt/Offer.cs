namespace SupermarketReceipt
{
    public enum SpecialOfferType
    {
        ThreeForTwo, TenPercentDiscount, TwoForAmount, FiveForAmount
    }

    public class Offer
    {
        public SpecialOfferType OfferType { get; }
        public Product Product { get; }
        public double Argument { get; }

        public Offer(SpecialOfferType offerType, Product product, double argument)
        {
            this.OfferType = offerType;
            this.Argument = argument;
            this.Product = product;
        }

    }

    public class ThreeForTwo : Offer
    {
        public ThreeForTwo(SpecialOfferType offerType, Product product, double argument) : base(offerType, product, argument)
        {
        }
    }

    public class TwoForAmountOffer : Offer
    {
        public TwoForAmountOffer(SpecialOfferType offerType, Product product, double argument) : base(offerType, product, argument)
        {

        }
    }


}

