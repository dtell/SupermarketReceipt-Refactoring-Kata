using System;

namespace SupermarketReceipt
{
    public abstract class Offer
    {
        public Product Product { get; }

        protected int NumberOfItemsToMeetCondition = 1;

        protected Offer(Product product)
        {
            this.Product = product;
        }

        public abstract Discount GetDiscount(double quantity, double unitPrice);

    }

    public class ThreeForTwo : Offer
    {
        protected new const int x = 3;
        public ThreeForTwo(Product product, double argument) : base(product)
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

    public class PercentageDiscountOffer : Offer
    {
        public double Percentage {get;}

        public PercentageDiscountOffer(Product product, double percentage) : base(product)
        {
            Percentage = percentage;
        }

        public override Discount GetDiscount(double quantity, double unitPrice)
        {
            return new Discount(Product, Percentage + "% off", quantity * unitPrice * Percentage / 100.0);
        }
    }

    public class NumberOfItemsForAmountOffer : Offer
    {
        public double Amount { get; }

        public NumberOfItemsForAmountOffer(Product product, int numberOfItemsToMeetCondition, double amount) : base(product)
        {
            NumberOfItemsToMeetCondition = numberOfItemsToMeetCondition;
            Amount = amount;
        }
        public override Discount GetDiscount(double quantity, double unitPrice)
        {
            Discount discount = null;
            var quantityAsInt = (int)quantity;
            var numberOfTimesOfferConditionHasBeenMet = quantityAsInt / NumberOfItemsToMeetCondition;

            if (quantityAsInt >= NumberOfItemsToMeetCondition)
            {
                var priceForItemsCoveredByOffer = Amount * numberOfTimesOfferConditionHasBeenMet;
                var priceForAdditionalItems = quantityAsInt % NumberOfItemsToMeetCondition * unitPrice;
                var priceAfterDiscount = priceForItemsCoveredByOffer + priceForAdditionalItems;
                var fullPrice = unitPrice * quantity;
                var discountTotal = fullPrice - priceAfterDiscount;
                discount = new Discount(Product, NumberOfItemsToMeetCondition + " for " + Amount, discountTotal);
            }
            
            return discount;
        }
    }


}

