using ImageProcessingFramework.Models;

namespace ImageProcessingFramework.Plugins;

public class ResizeEffect : IEffectPlugin
{
    public string Name => "Resize";

    public string Apply(SimulatedImageData image, EffectParameter parameter)
    {
        int target = 100;
        if (parameter?.Value is int i) target = i;
        else if (parameter?.Value is long l) target = (int)l;
        else if (parameter != null && int.TryParse(parameter.Value?.ToString(), out var parsed)) target = parsed;

        double aspect = (double)image.Width / image.Height;
        if (aspect >= 1.0)
        {
            image.Width = target;
            image.Height = (int)Math.Round(target / aspect);
        }
        else
        {
            image.Height = target;
            image.Width = (int)Math.Round(target * aspect);
        }

        return $"resize to {target}px ({image.Width}x{image.Height})";
    }
}