using System;
using System.Globalization;
using System.Windows.Controls;

namespace ValidateItemSample;

class PriceIsAPositiveNumber : ValidationRule {
    public override ValidationResult Validate(object value, CultureInfo cultureInfo) {
        try {
            var price = Convert.ToDouble(value);
            if (price < 0) {
                return new ValidationResult(false, "价格必须是正数");
            }

            return ValidationResult.ValidResult;
        } catch (Exception) {
            return new ValidationResult(false, "价格必须为数字");
        }
    }
}
