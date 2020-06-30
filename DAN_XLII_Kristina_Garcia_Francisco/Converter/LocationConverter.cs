using System;
using System.Globalization;
using System.Windows.Data;

namespace DAN_XLII_Kristina_Garcia_Francisco.Converter
{
    class LocationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Service service = new Service();
            for (int i = 0; i < service.GetAllLocations().Count; i++)
            {
                if (service.GetAllLocations()[i].LocationID == (int)value)
                {
                    string name = service.GetAllLocations()[i].LocationAddress + ", " + 
                        service.GetAllLocations()[i].City + ", " + service.GetAllLocations()[i].Country;
                    return name;
                }
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
