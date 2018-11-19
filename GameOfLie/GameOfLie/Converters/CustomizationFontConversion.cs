using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace GameOfLie.Converters
{
    public class CustomizationFontConversion : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (Device.RuntimePlatform == Device.Android)
            {
                if (parameter != null && parameter is string)
                    return "radialmenu_RadialMenu.ttf#" + parameter.ToString();
                else
                    return "radialmenu_RadialMenu.ttf";
            }
            else if (Device.RuntimePlatform == Device.iOS)
            {
                return "RadialMenu";
            }
            else
            {
                return "SampleBrowser.SfRadialMenu.UWP\\radialmenu_RadialMenu.ttf#RadialMenu";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
