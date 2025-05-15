
using WpfApp1.Core.Plugins;

namespace Plugin
{
    public class StarShapePlugin : IShapePlugin
    {
        public string Name => "Star";
        public Type ShapeType => typeof(StarShape);
    }

}
