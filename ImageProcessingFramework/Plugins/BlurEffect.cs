using ImageProcessingFramework.Models;

namespace ImageProcessingFramework.Plugins;

public class BlurEffect : IEffectPlugin
{
    public string Name => "Blur";

    public string Apply(SimulatedImageData image, EffectParameter parameter)
    {
        int radius = 1;
        if (parameter?.Value is int i) radius = i;
        else if (parameter != null && int.TryParse(parameter.Value.ToString(), out var parsed)) radius = parsed;
        return $"blur radius={radius}";
    }
}