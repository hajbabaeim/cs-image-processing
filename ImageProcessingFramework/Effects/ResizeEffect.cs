using ImageProcessingFramework.Framework;
using ImageProcessingFramework.Parameters;

namespace ImageProcessingFramework.Effects;

public class ResizeEffect : IImageEffect
{
    public string Name => "Resize";
    public Dictionary<string, IEffectParameter> Parameters { get; }

    public ResizeEffect()
    {
        Parameters = new Dictionary<string, IEffectParameter>
        {
            ["Size"] = new NumericParameter("Size", 100, 10, 1000)
        };
    }

    public ImageData Apply(ImageData image, Dictionary<string, object> parameters)
    {
        var size = parameters.ContainsKey("Size") ? 
            Convert.ToInt32(parameters["Size"]) : 
            (int)Parameters["Size"].DefaultValue;

        var result = image.Clone();
        result.UpdateSize(size, size);
            
        Console.WriteLine($"      Resized from {image.Width}x{image.Height} to {size}x{size}");
            
        return result;
    }
}