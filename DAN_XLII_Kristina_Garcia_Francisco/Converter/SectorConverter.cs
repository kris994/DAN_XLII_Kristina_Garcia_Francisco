﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace DAN_XLII_Kristina_Garcia_Francisco.Converter
{
    class SectorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Service service = new Service();
            for (int i = 0; i < service.GetAllSectors().Count; i++)
            {
                if (service.GetAllSectors()[i].SectorID == (int)value)
                {
                    return service.GetAllSectors()[i].SectorName;
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
