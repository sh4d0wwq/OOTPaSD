using System.Windows.Media;

namespace WpfApp1.Core.Serialization
{
    public static class BrushConverterHelper
    {
        private static readonly BrushConverter converter = new BrushConverter();

        public static string BrushToString(Brush brush) =>
            brush is SolidColorBrush solid ? solid.Color.ToString() : "#000000";

        public static Brush StringToBrush(string str) =>
            (Brush)converter.ConvertFromString(str);
    }
}
