using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Lab9A
{
    class BitBoolConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var day = (int)values[0];
            var month = (int)values[1];
            var year = (int)values[2];
            var dateTime = new DateTime(year, month, 1);




            if (month < 1 || month > 12)
            {
                throw new FormatException();
            }
            if (day < 1 || day > DateTime.DaysInMonth(year, month))
            {
                throw new FormatException();
            }

            if (year < 0 || year > 9999)
            {
                throw new FormatException();
            }

            return $"{day}.{month}.{year}" as object;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return value.ToString()
                .Split('.')
                .Select(item => System.Convert.ToInt32(item))
                .Cast<object>()
                .ToArray();
        }
    }
}
