using Project.Views.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace Project.Views.Director
{
    [ValueConversion(typeof(AddressDTO), typeof(string))]
    public class AdressToStringConverter:MarkupExtension,IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            AddressDTO address = (AddressDTO)value;

            return address.Street + "," + address.Number.ToString() + "," + address.City;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            /* string strValue = value as string;
             AddressDTO address= new AddressDTO();
             if (AddressDTO.TryParse(strValue, out address))
             {
                 return resultDateTime;
             }
             return DependencyProperty.UnsetValue;*/
            return new AddressDTO();
        }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

    }

}

/*[ValueConversion(typeof(DateTime), typeof(String))]
public class DateConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        DateTime date = (DateTime)value;
        return date.ToShortDateString();
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        string strValue = value as string;
        DateTime resultDateTime;
        if (DateTime.TryParse(strValue, out resultDateTime))
        {
            return resultDateTime;
        }
        return DependencyProperty.UnsetValue;
    }
}*/