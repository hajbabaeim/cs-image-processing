namespace ImageProcessingFramework.Models;

public class EffectInstance
{
    public string PluginKey { get; }
    public EffectParameter Parameter { get; }

    public EffectInstance(string pluginKey, EffectParameter param = null)
    {
        PluginKey = pluginKey;
        Parameter = param;
    }

    public override string ToString()
    {
        if (Parameter == null) return PluginKey;
        return $"{PluginKey}({Parameter.Name}={Parameter.Value})";
    }
}