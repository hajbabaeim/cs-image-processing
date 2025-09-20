namespace ImageProcessingFramework.Framework;

public interface IEffectParameter
{
    string Name { get; }
    string Type { get; }
    object DefaultValue { get; }
    object MinValue { get; }
    object MaxValue { get; }
    List<string> Options { get; }
    bool Validate(object value);
}
