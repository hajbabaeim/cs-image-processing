using ImageProcessingFramework.Models;

namespace ImageProcessingFramework.Plugins;

public class GrayscaleEffect : IEffectPlugin
{
    public string Name => "Grayscale";

    public string Apply(SimulatedImageData image, EffectParameter parameter)
    {
        return "grayscale";
    }
}