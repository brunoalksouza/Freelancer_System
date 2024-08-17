using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Application.Attributes;


public class PasswordValidationAttribute : ValidationAttribute
{
    public PasswordValidationAttribute()
    {
        ErrorMessage = "The password must contain at least one digit, one lowercase letter, one uppercase letter, one non-alphanumeric character, and be at least six characters long";
    }

    public override bool IsValid(object value)
    {
        var password = value as string;
        if (string.IsNullOrEmpty(password))
        {
            return false;
        }

        var hasDigit = Regex.IsMatch(password, @"\d");
        var hasLowercase = Regex.IsMatch(password, @"[a-z]");
        var hasUppercase = Regex.IsMatch(password, @"[A-Z]");
        var hasNonAlphanumeric = Regex.IsMatch(password, @"[\W_]");

        return password.Length >= 6 && hasDigit && hasLowercase && hasUppercase && hasNonAlphanumeric;
    }
}