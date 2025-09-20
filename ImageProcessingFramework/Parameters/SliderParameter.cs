namespace ImageProcessingFramework.Parameters;

public class SliderParameter : Framework.IEffectParameter
{
    public string Name { get; }
    public string Type => "slider";
    public object DefaultValue { get; }
    public object MinValue { get; }
    public object MaxValue { get; }
    public List<string> Options => null;

    public SliderParameter(string name, double defaultVal, double min, double max)
    {
        Name = name;
        DefaultValue = defaultVal;
        MinValue = min;
        MaxValue = max;
    }

    public bool Validate(object value)
    {
        if (value is double d)
            return d >= (double)MinValue && d <= (double)MaxValue;
        return false;
    }
}