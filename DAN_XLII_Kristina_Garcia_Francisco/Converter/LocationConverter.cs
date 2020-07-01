using System;
using System.Globalization;
using System.Windows.Data;

namespace DAN_XLII_Kristina_Garcia_Francisco.Converter
{
    /// <summary>
    /// Convertes the id of the location to the location address, city and country
    /// </summary>
    class LocationConverter : IValueConverter
    {
        /// <summary>
        /// Converts the parameter value into the location address, city and country
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Converts back
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
