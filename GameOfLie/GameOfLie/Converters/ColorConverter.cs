using System;
using System.DrawingCore;
using System.Globalization;
using Xamarin.Forms;
using Color = System.Drawing.Color;
using CoreColor = System.DrawingCore.Color;


namespace GameOfLie.Converters
{
    public class ColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var c = (Color)value;
            return ConvertToHex(c);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ConvertToColor((string)value);
        }

        public static string ConvertToHex(Color c)
        {
            return ColorTranslator.ToHtml(CoreColor.FromArgb(c.ToArgb()));
        }

        public static Color ConvertToColor(string hex)
        {
            return Color.FromArgb(ColorTranslator.FromHtml(hex).ToArgb());
        }
    }
}
