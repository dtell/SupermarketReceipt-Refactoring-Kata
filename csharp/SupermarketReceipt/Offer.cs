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

        public virtual  Discount GetDiscount(Product p, double quantity, double unitPrice, int? x = null) {throw new NotImplementedException();}

    }

    public class ThreeForTwo : Offer
    {
        public ThreeForTwo(Product product, double argument) : base(product, argument)
        {
        }

        public override Discount GetDiscount(Product p, double quantity, double unitPrice, int? x = null)
        {
            Discount discount = null;
            var quantityAsInt = (int)quantity;
            if (x != null)
            {
                var numberOfXs = quantityAsInt / x.Value;

                if (quantityAsInt > 2)
                {
                    var discountAmount = quantity * unitPrice - ((numberOfXs * 2 * unitPrice) + quantityAsInt % 3 * unitPrice);
                    discount = new Discount(p, "3 for 2", discountAmount);
                }
            }

            return discount;
        }
    }

    public class TwoForAmountOffer : Offer
    {
        public TwoForAmountOffer(Product product, double argument) : base(product, argument)
        {

        }

        public override Discount GetDiscount(Product p, double quantity, double unitPrice, int? x = null)
        {
            x = 2;
            var quantityAsInt = (int)quantity;
            var numberOfXs = quantityAsInt / x;

            if (quantityAsInt >= 2)
            {
                double total = Argument * quantityAsInt / x.Value + quantityAsInt % 2 * unitPrice;
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

        public override Discount GetDiscount(Product p, double quantity, double unitPrice, int? x = null)
        {
            return new Discount(p, Argument + "% off", quantity * unitPrice * Argument / 100.0);
        }
    }

    public class FiveForAmountOffer : Offer
    {
        public FiveForAmountOffer(Product product, double argument) : base(product, argument)
        {
        }
        public override Discount GetDiscount(Product p, double quantity, double unitPrice,  int? x = null)
        {
            Discount discount = null;
            var quantityAsInt = (int)quantity;
            var numberOfXs = quantityAsInt / x;

            if (numberOfXs.HasValue && quantityAsInt >= 5)
            {
                var discountTotal = unitPrice * quantity - (Argument * numberOfXs.Value + quantityAsInt % 5 * unitPrice);
                discount = new Discount(p, x + " for " + Argument, discountTotal);
            }
            
            return discount;
        }
    }


}

