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
            var bValue = value is bool && (bool)value;
            var result = bValue ? new SolidColorBrush(Colors.LightBlue) : new SolidColorBrush(Colors.Transparent);
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException("SelectionColorConverter.ConvertBack");
        }
    }
}
