namespace ImageProcessingFramework.Parameters;

public class SelectorParameter : Framework.IEffectParameter
{
    public string Name { get; }
    public string Type => "selector";
    public object DefaultValue { get; }
    public object MinValue => null;
    public object MaxValue => null;
    public List<string> Options { get; }

    public SelectorParameter(string name, string defaultVal, List<string> options)
    {
        Name = name;
        DefaultValue = defaultVal;
        Options = options;
    }

    public bool Validate(object value)
    {
        return value is string s && Options.Contains(s);
    }
}