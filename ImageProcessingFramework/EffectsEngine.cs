using ImageProcessingFramework.Models;

namespace ImageProcessingFramework;

public class EffectsEngine
{
    private readonly PluginManager _pluginManager;

    public EffectsEngine(PluginManager pluginManager)
    {
        _pluginManager = pluginManager;
    }

    public void Process(IEnumerable<ImageItem> images)
    {
        foreach (var img in images)
        {
            Console.WriteLine($"Processing {img.Id}");
            foreach (var eff in img.Effects)
            {
                if (!_pluginManager.HasPlugin(eff.PluginKey))
                {
                    img.AppliedEffects.Add($"(skipped:{eff.PluginKey})");
                    continue;
                }
                var plugin = _pluginManager.CreatePlugin(eff.PluginKey);
                var result = plugin.Apply(img.Data, eff.Parameter);
                img.AppliedEffects.Add(result);
                Console.WriteLine($"  - {plugin.Name}: {result}");
            }
        }
    }
}