using System;

namespace DataBindingToStringFomat;

class PurchaseItem {
    public PurchaseItem() {
    }

    public PurchaseItem(string desc, double price, DateTime endDate) {
        Description = desc;
        Price = price;
        OfferExpires = endDate;
    }

    public string Description { get; set; } = "";
    public double Price { get; set; } = 0;
    public DateTime OfferExpires { get; set; }

    public override string ToString() => $"{Description}, {Price:c}, {OfferExpires:D}";
}
