namespace ImageProcessingFramework.Framework;

public interface IImageEffect
{
    string Name { get; }
    Dictionary<string, IEffectParameter> Parameters { get; }
    ImageData Apply(ImageData image, Dictionary<string, object> parameters);
}