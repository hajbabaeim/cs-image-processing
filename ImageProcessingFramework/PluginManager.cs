using System.Text.Json;

namespace ImageProcessingFramework;

public class PluginManager
{
    private readonly Dictionary<string, string> _pluginTypeMap = new(StringComparer.OrdinalIgnoreCase);

    public void LoadConfig(string path)
    {
        var json = File.ReadAllText(path);
        using var doc = JsonDocument.Parse(json);
        var root = doc.RootElement;
        if (root.TryGetProperty("plugins", out var pluginsProp))
        {
            foreach (var prop in pluginsProp.EnumerateObject())
            {
                var key = prop.Name;
                var typeName = prop.Value.GetString();
                if (!string.IsNullOrWhiteSpace(typeName))
                    _pluginTypeMap[key] = typeName.Trim();
            }
        }
    }

    public bool HasPlugin(string key) => _pluginTypeMap.ContainsKey(key);

    public IEffectPlugin CreatePlugin(string key)
    {
        if (!_pluginTypeMap.TryGetValue(key, out var typeName))
            throw new InvalidOperationException($"Plugin '{key}' not configured.");

        var type = AppDomain.CurrentDomain.GetAssemblies()
            .Select(a => a.GetType(typeName, false))
            .FirstOrDefault(t => t != null);

        if (type == null)
            throw new InvalidOperationException($"Type '{typeName}' not found.");

        return (IEffectPlugin)Activator.CreateInstance(type);
    }

    public IEnumerable<string> GetAvailablePluginKeys() => _pluginTypeMap.Keys;
}