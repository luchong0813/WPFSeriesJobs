using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace _4_WPFDataTemplete
{
    /// <summary>
    /// 将学生状态信息转为颜色代码
    /// </summary>
    public class GraduateConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                switch (value)
                {
                    case "在读":
                        return "Green";
                    case "毕业":
                        return "Red";
                    default:
                        return "Gray";
                }
            }
            return "Gray";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
