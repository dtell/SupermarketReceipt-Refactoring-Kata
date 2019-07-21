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

        public virtual  Discount GetDiscount(Product p, double quantity, double unitPrice, int? quantityAsInt = null, int? numberOfXs = null, int? x = null) {throw new NotImplementedException();}

    }

    public class ThreeForTwo : Offer
    {
        public ThreeForTwo(Product product, double argument) : base(product, argument)
        {
        }

        public override Discount GetDiscount(Product p, double quantity, double unitPrice, int? quantityAsInt, int? numberOfXs, int? x = null)
        {
            Discount discount = null;
            if (quantityAsInt.HasValue && numberOfXs.HasValue && quantityAsInt.Value > 2)
            {
                var discountAmount = quantity * unitPrice - ((numberOfXs.Value * 2 * unitPrice) + quantityAsInt.Value % 3 * unitPrice);
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

        public override Discount GetDiscount(Product p, double quantity, double unitPrice, int? quantityAsInt, int? numberOfXs = null, int? x = null)
        {
            x = 2;
            if (quantityAsInt.HasValue && quantityAsInt.Value >= 2)
            {
                double total = Argument * quantityAsInt.Value / x.Value + quantityAsInt.Value % 2 * unitPrice;
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

        public override Discount GetDiscount(Product p, double quantity, double unitPrice, int? quantityAsInt = null, int? numberOfXs = null, int? x = null)
        {
            return new Discount(p, Argument + "% off", quantity * unitPrice * Argument / 100.0);
        }
    }

    public class FiveForAmountOffer : Offer
    {
        public FiveForAmountOffer(Product product, double argument) : base(product, argument)
        {
        }
        public override Discount GetDiscount(Product p, double quantity, double unitPrice,  int? quantityAsInt = null, int? numberOfXs = null, int? x = null)
        {
            Discount discount = null;

            if (quantityAsInt.HasValue && numberOfXs.HasValue && quantityAsInt >= 5)
            {
                var discountTotal = unitPrice * quantity - (Argument * numberOfXs.Value + quantityAsInt.Value % 5 * unitPrice);
                discount = new Discount(p, x + " for " + Argument, discountTotal);
            }
            
            return discount;
        }
    }


}

