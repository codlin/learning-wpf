using System;
using System.Globalization;
using System.Windows.Controls;

namespace BindValidation;

class AgeRangeRule : ValidationRule {
    public int Min { get; set; }
    public int Max { get; set; }

    public override ValidationResult Validate(object value, CultureInfo cultureInfo) {
        int age = 0;
        try {
            if (((string)value).Length > 0) {
                age = int.Parse(((string)value));
            }
        } catch (Exception ex) {
            return new ValidationResult(false, "Illegal characters or " + ex.Message);
        }

        if (age < Min || age > Max) {
            return new ValidationResult(false, "Please enter an age in the range: " + Min + " - " + Max + ".");
        }

        return new ValidationResult(true, null);
    }
}
