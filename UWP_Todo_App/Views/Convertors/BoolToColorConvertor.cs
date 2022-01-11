using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace UWP_Todo_App.Views.Convertors
{ 
	public class BoolToColorConvertor : IValueConverter
	{
        public object Convert(object value, Type targetType, object parameter, string language)
        {
			if (value == null) return new SolidColorBrush(Colors.Gray);
			if (parameter is "title")
			{
				return value is true ? new SolidColorBrush(Colors.DimGray) : new SolidColorBrush(Colors.White);
			}
			return value is true ? new SolidColorBrush(Colors.Gray) : new SolidColorBrush(Colors.White);
			
		}

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
			if (value == null) return new SolidColorBrush(Colors.Gray);
			if (parameter is "title")
			{
				return value is true ? new SolidColorBrush(Colors.White) : new SolidColorBrush(Colors.DimGray);
			}
			return value is true ? new SolidColorBrush(Colors.White) : new SolidColorBrush(Colors.Gray);
		}
    }
}
