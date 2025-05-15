using System.Reflection;

namespace WpfApp1.Core
{
    public static class ClassLoader
    {
        public static List<Type> LoadShapeTypes(Type baseType)
        {
            return Assembly.GetAssembly(baseType)
                .GetTypes()
                .Where(type => type.IsSubclassOf(baseType) && !type.IsAbstract)
                .OrderBy(type =>
                {
                    FieldInfo idField = type.GetField("id", BindingFlags.Public | BindingFlags.Static);
                    if (idField == null)
                        throw new InvalidOperationException($"Class {type.Name} does not have a static 'id' field.");
                    return (int)idField.GetValue(null);
                })
                .ToList();
        }
    }
}