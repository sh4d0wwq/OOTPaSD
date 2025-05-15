using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Core.Serialization
{
    public class ShapeDto
    {
        public string Type { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public List<PointDto> Points { get; set; }
        public ShapeSettingsDto Settings { get; set; }
    }
}
