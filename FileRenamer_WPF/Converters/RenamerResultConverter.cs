using MultiFileRenamer.ClassLibrary;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace FileRenamer_WPF.Converters
{
    internal class RenamerResultConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var color = Colors.Transparent;
            FileRenamerResult result = (FileRenamerResult)value;
            if (result == FileRenamerResult.FolderExists)
            {
                color = Colors.Green;
            }
            else
            {
                color = Colors.Red;
            }
            return color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
