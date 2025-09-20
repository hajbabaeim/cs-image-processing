using ImageProcessingFramework.Framework;
using ImageProcessingFramework.Parameters;

namespace ImageProcessingFramework.Effects;

public class BlurEffect : IImageEffect
{
    public string Name => "Blur";
    public Dictionary<string, IEffectParameter> Parameters { get; }

    public BlurEffect()
    {
        Parameters = new Dictionary<string, IEffectParameter>
        {
            ["Radius"] = new SliderParameter("Radius", 2.0, 0.0, 10.0)
        };
    }

    public ImageData Apply(ImageData image, Dictionary<string, object> parameters)
    {
        var radius = parameters.ContainsKey("Radius") ? 
            Convert.ToDouble(parameters["Radius"]) : 
            (double)Parameters["Radius"].DefaultValue;

        var result = image.Clone();
            
        Console.WriteLine($"      Applied blur with radius {radius} pixels");
            
        return result;
    }
}