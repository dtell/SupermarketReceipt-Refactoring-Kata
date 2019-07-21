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




}

