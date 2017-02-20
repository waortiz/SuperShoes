using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Globalization;

namespace SuperShoes.Utilities
{
    public static class Format
    {
        public static decimal GetValue(string value)
        {
            if (string.IsNullOrEmpty(value))
                return 0;

            try
            {
                return Decimal.Parse(value,
                    NumberStyles.AllowCurrencySymbol |
                    NumberStyles.AllowDecimalPoint |
                    NumberStyles.AllowThousands |
                    NumberStyles.AllowParentheses,
                    new CultureInfo("en-US"));
            }
            catch (Exception ex)
            {
                throw new Exception(
                    string.Format(
                        "Error recovering value: {0}"), ex);
            }
        }

        public static int GetIntValue(string value)
        {
            if (string.IsNullOrEmpty(value))
                return 0;

            try
            {
                return int.Parse(value, new CultureInfo("en-US"));
            }
            catch (Exception ex)
            {
                throw new Exception(
                    string.Format(
                        "Error recovering value: {0}"), ex);
            }
        }

        public static string FormatCurrency(decimal value)
        {
            return value.ToString("C2", new CultureInfo("en-US"));
        }
    }
}
