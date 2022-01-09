using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Windows.UI.Xaml.Data;

namespace UWP_Todo_App.Views.Convertors
{ 
	public class BoolToColorConvertor : IValueConverter
	{
        public object Convert(object value, Type targetType, object parameter, string language)
        {
			if (parameter is "title")
			{
				return value is true ? "DimGray" : "White";
			}
			return value is true ? "Gray" : "White";
			
		}

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
			if (parameter is "title")
			{
				return value is true ? "White" : "DimGray";
			}
			return value is true ? "White" : "Gray";
		}
    }
}
