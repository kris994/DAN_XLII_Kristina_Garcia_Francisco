using System;
using System.Globalization;
using System.Windows.Data;

namespace DAN_XLII_Kristina_Garcia_Francisco.Converter
{
    /// <summary>
    /// Convertes the id of the manager to the managers first and last name
    /// </summary>
    class FullNameConverter : IValueConverter
    {
        /// <summary>
        /// Converts the parameter value into first and last name
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Service service = new Service();
            if (value != null)
            {
                for (int i = 0; i < service.GetAllUsers().Count; i++)
                {
                    if (service.GetAllUsers()[i].UserID == (int)value)
                    {
                        return service.GetAllUsers()[i].FirstName + " " + service.GetAllUsers()[i].LastName;
                    }
                }
            }

            return "";   
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
