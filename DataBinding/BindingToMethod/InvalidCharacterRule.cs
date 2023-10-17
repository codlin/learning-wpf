using System;
using System.Globalization;
using System.Windows.Controls;

namespace BindingToMethod;
internal class InvalidCharacterRule : ValidationRule {
    public override ValidationResult Validate(object value, CultureInfo cultureInfo) {
        try {
            double myvalue;
            if (((string)value).Length > 0)
                myvalue = double.Parse((string)value);
        } catch (Exception e) {
            return new ValidationResult(false, "Illegal characters or " + e.Message);
        }

        return new ValidationResult(true, null);
    }
}
