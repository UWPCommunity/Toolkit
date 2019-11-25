﻿using System;
using System.Globalization;
using Windows.UI.Xaml.Data;

namespace Yugen.Toolkit.Uwp.Converters
{
    public class StringFormatterConverter : IValueConverter
    {
        /// <summary>
        /// This converts the value object to the string to display.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            // Retrieve the format string and use it to format the value.
            string formatString = parameter as string;

            // If the format string is null or empty, simply call ToString() on the value.
            return string.IsNullOrEmpty(formatString) ? 
                value.ToString() : 
                string.Format(formatString, value, CultureInfo.CurrentCulture);
        }

        // No need to implement converting back on a one-way binding
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
    }
}