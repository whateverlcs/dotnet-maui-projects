using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace AppTask.Libraries.Converters;

public class BoolToTextDecorationStrikeThroughConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        bool isCompleted = (bool)value;

        return isCompleted ? TextDecorations.Strikethrough : TextDecorations.None;
    }

    public object? ConvertBack(
        object? value,
        Type targetType,
        object? parameter,
        CultureInfo culture
    )
    {
        throw new NotImplementedException();
    }
}
