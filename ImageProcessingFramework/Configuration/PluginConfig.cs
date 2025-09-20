namespace ImageProcessingFramework.Configuration;

public class PluginConfig
{
    public List<string> EnabledPlugins { get; set; } = new();
    
    public static PluginConfig GetDefault()
    {
        return new PluginConfig
        {
            EnabledPlugins = new List<string> 
            { 
                "Resize", 
                "Blur", 
                "Grayscale" 
            }
        };
    }
}

