using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using WpfApp1.Core.Shapes;

public static class ShapeRegistry
{
    private static readonly Dictionary<string, Type> _typeByName = new();

    static ShapeRegistry()
    {
        var shapeBaseType = typeof(Shape);
        var assembly = Assembly.GetExecutingAssembly();

        foreach (var type in assembly.GetTypes())
        {
            if (!type.IsAbstract && shapeBaseType.IsAssignableFrom(type))
            {
                _typeByName[type.Name] = type;
            }
        }
    }

    public static Type? GetShapeType(string name) =>
        _typeByName.TryGetValue(name, out var type) ? type : null;

    public static IEnumerable<string> GetRegisteredShapeNames() => _typeByName.Keys;
}
