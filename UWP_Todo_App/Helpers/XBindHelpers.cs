using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace UWP_Todo_App.Helpers
{
    public static class XBindHelpers
    {
        #region Boolean To Color Brush Helper
        public static SolidColorBrush BoolToColor(bool isDone, string param = "")
        {
            if (param == "title")
            {
            return isDone ? new SolidColorBrush(Colors.DimGray) : new SolidColorBrush(Colors.White);
            }
            if (param == "desc")
            {
                return isDone ? new SolidColorBrush(Colors.Gray) : new SolidColorBrush(Colors.LightGray);
            }
            return new SolidColorBrush(Colors.White);
        }
        #endregion

       
    }
}
