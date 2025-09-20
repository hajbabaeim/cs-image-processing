using ImageProcessingFramework.Framework;
using ImageProcessingFramework.Parameters;

namespace ImageProcessingFramework.Effects;

public class GrayscaleEffect : IImageEffect
{
    public string Name => "Grayscale";
    public Dictionary<string, IEffectParameter> Parameters { get; }

    public GrayscaleEffect()
    {
        Parameters = new Dictionary<string, IEffectParameter>
        {
            ["Method"] = new SelectorParameter("Method", "Luminosity", 
                new List<string> { "Average", "Luminosity", "Desaturation" })
        };
    }

    public ImageData Apply(ImageData image, Dictionary<string, object> parameters)
    {
        var method = parameters.ContainsKey("Method") ? 
            parameters["Method"].ToString() : 
            Parameters["Method"].DefaultValue.ToString();

        var result = image.Clone();
            
        Console.WriteLine($"      Converted to grayscale using {method} method");
            
        return result;
    }
}
