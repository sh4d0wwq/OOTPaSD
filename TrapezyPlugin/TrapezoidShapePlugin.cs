using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Core.Plugins;

namespace TrapezoidPlugin
{
    public class TrapezoidShapePlugin : IShapePlugin
    {
        public string Name => "Trapezoid";
        public Type ShapeType => typeof(TrapezoidShape);
    }
}
