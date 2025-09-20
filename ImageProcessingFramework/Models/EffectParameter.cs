namespace ImageProcessingFramework.Models;

public class EffectParameter
{
    public string Name { get; }
    public object Value { get; }

    public EffectParameter(string name, object value)
    {
        Name = name;
        Value = value;
    }

    public EffectParameter(object value) : this("value", value) { }
}