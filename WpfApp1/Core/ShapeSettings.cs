using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace WpfApp1.Core
{
    public struct ShapeSettings
    {
        public Brush borderColor;
        public Brush fillColor;
        public double lineWidth;
        public bool isLast;
        public MouseButtonEventHandler mouseUp;
    }
}
