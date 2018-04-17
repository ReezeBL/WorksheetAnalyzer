using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Matreshka.Core;

namespace Matreshka
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }

    public sealed class DescriptionConverter : IValueConverter
    {
        public static readonly DescriptionConverter FirstDescriptionConverter = new DescriptionConverter(0);
        public static readonly DescriptionConverter SecondDescriptionConverter = new DescriptionConverter(1);

        private readonly int selector;

        private DescriptionConverter(int selector)
        {
            this.selector = selector;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return "null";

            var field = value.GetType().GetField(value.ToString());
            foreach (var attrib in field.GetCustomAttributes(false))
            {
                if (attrib is DescriptionAttribute desc) return SelectFromDescription(desc.Description);
            }
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private string SelectFromDescription(string description)
        {
            var split = description.Split(';');
            return split.Length == 1 ? split[0] : split[selector];
        }
    }

    public class EnumConverter : IValueConverter
    {
        public static readonly EnumConverter Instance = new EnumConverter();

        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            if (!(value is Enum enumValue))
                return 0;
            return System.Convert.ChangeType(enumValue, enumValue.GetTypeCode());
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                var intVale = int.Parse(value.ToString());
                return (Growth)intVale;
            }

            return null;
        }
    }
}
