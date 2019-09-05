﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace NHM.Wpf.ViewModels.Converters
{
    /// <summary>
    /// Helper class for type-safe value conversion.
    /// </summary>
    /// <typeparam name="TIn">Input type for <see cref="IValueConverter.Convert"/></typeparam>
    /// <typeparam name="TOut">Output type for <see cref="IValueConverter.Convert"/></typeparam>
    public abstract class ConverterBase<TIn, TOut> : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is TIn t)) return null;
            return Convert(t, parameter as string);
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is TOut t)) return null;
            return ConvertBack(t, parameter as string);
        }

        public abstract TOut Convert(TIn value, string parameter);
        public virtual TIn ConvertBack(TOut value, string parameter) => default;
    }
}
