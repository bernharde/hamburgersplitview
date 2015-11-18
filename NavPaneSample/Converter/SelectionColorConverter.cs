using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace NavPaneSample.Converter
{
    public sealed class SelectionColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            Brush notSelectedBrush;
            Brush selectedBrush;
            var sParamter = (string)parameter;
            if (sParamter == "background")
            {
                selectedBrush = (Brush)App.Current.Resources["HamburgerItemSelectedBackgroundBrush"];
                notSelectedBrush = (Brush)App.Current.Resources["HamburgerBackgroundBrush"];
                //notSelectedBrush = new SolidColorBrush(Colors.Transparent);
            }
            else
            {
                selectedBrush = (Brush)App.Current.Resources["HamburgerItemSelectedForegroundBrush"];
                notSelectedBrush = (Brush)App.Current.Resources["HamburgerForegroundBrush"];
            }
            var bValue = value is bool && (bool)value;
            //var result = bValue ? new SolidColorBrush(Colors.LightBlue) : new SolidColorBrush(Colors.Transparent);
            var result = bValue ? selectedBrush : notSelectedBrush;
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException("SelectionColorConverter.ConvertBack");
        }
    }
}
