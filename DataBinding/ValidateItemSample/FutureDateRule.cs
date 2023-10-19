using System;
using System.Globalization;
using System.Windows.Controls;

namespace ValidateItemSample;

class FutureDateRule : ValidationRule {
    public override ValidationResult Validate(object value, CultureInfo cultureInfo) {
        DateTime date;
        try {
            date = DateTime.Parse(value.ToString()!);
        } catch (FormatException) {
            return new ValidationResult(false, "不是一个有效的日期。");
        }

        return DateTime.Now.Date > date ? new ValidationResult(false, "请填写一个未来的日期。") : ValidationResult.ValidResult;
    }
}
