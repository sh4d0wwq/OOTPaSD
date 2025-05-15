using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using WpfApp1.Core.Shapes;

namespace WpfApp1.Core.Plugins
{
    public static class PluginLoader
    {
        public static void LoadShapePlugin(string filePath)
        {
            try
            {
                var assembly = Assembly.LoadFrom(filePath);

                var shapes = assembly.GetTypes().Where(t => typeof(Shape).IsAssignableFrom(t));

                MessageBox.Show("Plugin loaded successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading plugin: {ex.Message}");
            }
        }

    }
}
