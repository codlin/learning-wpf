using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace ValidateItemSample;

class ValidateDateAndPrice : ValidationRule {
    public override ValidationResult Validate(object value, CultureInfo cultureInfo) {
        var bg = value as BindingGroup;
        if (bg == null) {
            return new ValidationResult(false, "未发现绑定组");
        }

        var item = bg.Items[0] as PurchaseItem;

        var priceResult = bg!.TryGetValue(item, "Price", out object doubleValue);
        var dateResult = bg!.TryGetValue(item, "OfferExpires", out object dateTimeValue);
        if (!priceResult || !dateResult) {
            return new ValidationResult(false, "属性不存在");
        }

        var price = (double)doubleValue;
        var offerExpires = (DateTime)dateTimeValue;
        // Check that an item over $100 is available for at least 7 days.
        if (price > 100) {
            if (offerExpires < DateTime.Today + new TimeSpan(7, 0, 0, 0)) {
                return new ValidationResult(false, "Items over $100 must be available for at least 7 days.");
            }
        }

        return ValidationResult.ValidResult;
    }
}
