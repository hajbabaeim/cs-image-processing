namespace ImageProcessingFramework.Parameters;

public class NumericParameter : Framework.IEffectParameter
{
    public string Name { get; }
    public string Type => "numeric";
    public object DefaultValue { get; }
    public object MinValue { get; }
    public object MaxValue { get; }
    public List<string> Options => null;

    public NumericParameter(string name, int defaultVal, int min, int max)
    {
        Name = name;
        DefaultValue = defaultVal;
        MinValue = min;
        MaxValue = max;
    }

    public bool Validate(object value)
    {
        if (value is int i)
            return i >= (int)MinValue && i <= (int)MaxValue;
        return false;
    }
}