using System.Reflection;
using ImageProcessingFramework.Configuration;
using ImageProcessingFramework.Effects;

namespace ImageProcessingFramework.Framework;

    public class PluginManager
    {
        private readonly Dictionary<string, IImageEffect> _effects = new();
        
        public void RegisterEffect(IImageEffect effect)
        {
            _effects[effect.Name] = effect;
            Console.WriteLine($"✓ Registered effect: {effect.Name}");
        }

        public void UnregisterEffect(string effectName)
        {
            if (_effects.Remove(effectName))
                Console.WriteLine($"✓ Unregistered effect: {effectName}");
        }

        public IImageEffect GetEffect(string name)
        {
            return _effects.TryGetValue(name, out var effect) ? effect : null;
        }

        public List<string> GetAvailableEffects()
        {
            return _effects.Keys.ToList();
        }

        public void LoadPluginsFromConfig(PluginConfig config)
        {
            foreach (var pluginName in config.EnabledPlugins)
            {
                IImageEffect effect = pluginName switch
                {
                    "Resize" => new ResizeEffect(),
                    "Blur" => new BlurEffect(),
                    "Grayscale" => new GrayscaleEffect(),
                    _ => null
                };

                if (effect != null)
                    RegisterEffect(effect);
            }
        }

        public void LoadPluginsFromDirectory(string pluginPath)
        {
            if (!Directory.Exists(pluginPath))
                return;

            foreach (var dll in Directory.GetFiles(pluginPath, "*.dll"))
            {
                try
                {
                    var assembly = Assembly.LoadFrom(dll);
                    var types = assembly.GetTypes()
                        .Where(t => typeof(IImageEffect).IsAssignableFrom(t) && !t.IsInterface);

                    foreach (var type in types)
                    {
                        var effect = Activator.CreateInstance(type) as IImageEffect;
                        if (effect != null)
                            RegisterEffect(effect);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to load plugin from {dll}: {ex.Message}");
                }
            }
        }
    }