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

        public static SolidColorBrush BoolToColorTitle(bool isDone)
        {
            return isDone ? new SolidColorBrush(Colors.LightGray) : new SolidColorBrush(Colors.White);
        }  
        public static SolidColorBrush BoolToColorDesc(bool isDone)
        {
            return isDone ? new SolidColorBrush(Colors.Gray) : new SolidColorBrush(Colors.LightGray);
        }
    }
}
