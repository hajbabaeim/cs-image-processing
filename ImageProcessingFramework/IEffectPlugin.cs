using ImageProcessingFramework.Models;

namespace ImageProcessingFramework;

public interface IEffectPlugin
{
    string Name { get; }
    string Apply(SimulatedImageData image, EffectParameter parameter);
}