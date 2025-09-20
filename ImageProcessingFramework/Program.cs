using System;
using System.Collections.Generic;
using ImageProcessingFramework.Configuration;
using ImageProcessingFramework.Framework;

namespace ImagePluginFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Image Processing Plugin Framework ===\n");

            var pluginManager = new PluginManager();
            var config = PluginConfig.GetDefault();
            
            Console.WriteLine("Loading plugins...");
            pluginManager.LoadPluginsFromConfig(config);
            Console.WriteLine($"\nAvailable effects: {string.Join(", ", pluginManager.GetAvailableEffects())}");
            var processor = new ImageProcessor(pluginManager);
            Console.WriteLine("\n=== Processing Multiple Images ===");
            
            var batchRequest = new Dictionary<string, ImageRequest>
            {
                ["Image#1"] = new ImageRequest
                {
                    Image = new ImageData("IMG001", 500, 500),
                    Effects = new List<EffectConfig>
                    {
                        new EffectConfig 
                        { 
                            EffectName = "Resize", 
                            Parameters = new Dictionary<string, object> { ["Size"] = 100 }
                        },
                        new EffectConfig 
                        { 
                            EffectName = "Blur", 
                            Parameters = new Dictionary<string, object> { ["Radius"] = 2.0 }
                        }
                    }
                },
                
                ["Image#2"] = new ImageRequest
                {
                    Image = new ImageData("IMG002", 400, 400),
                    Effects = new List<EffectConfig>
                    {
                        new EffectConfig 
                        { 
                            EffectName = "Resize", 
                            Parameters = new Dictionary<string, object> { ["Size"] = 100 }
                        }
                    }
                },
                
                ["Image#3"] = new ImageRequest
                {
                    Image = new ImageData("IMG003", 600, 600),
                    Effects = new List<EffectConfig>
                    {
                        new EffectConfig 
                        { 
                            EffectName = "Resize", 
                            Parameters = new Dictionary<string, object> { ["Size"] = 150 }
                        },
                        new EffectConfig 
                        { 
                            EffectName = "Blur", 
                            Parameters = new Dictionary<string, object> { ["Radius"] = 5.0 }
                        },
                        new EffectConfig 
                        { 
                            EffectName = "Grayscale",
                            Parameters = new Dictionary<string, object> { ["Method"] = "Luminosity" }
                        }
                    }
                }
            };
            
            var results = processor.ProcessBatch(batchRequest);
            
            Console.WriteLine("\n=== Processing Complete ===\n");
            foreach (var result in results)
            {
                var img = result.Value;
                Console.WriteLine($"{result.Key}: {img.Width}x{img.Height}, Format: {img.Format}");
            }
            
            Console.WriteLine("\n=== Effect Parameters (for UI) ===\n");
            foreach (var effectName in pluginManager.GetAvailableEffects())
            {
                var effect = pluginManager.GetEffect(effectName);
                Console.WriteLine($"{effect.Name}:");
                
                foreach (var param in effect.Parameters)
                {
                    var p = param.Value;
                    Console.WriteLine($"  • {p.Name} ({p.Type})");
                    
                    if (p.Type == "slider" || p.Type == "numeric")
                    {
                        Console.WriteLine($"    Range: {p.MinValue} - {p.MaxValue}, Default: {p.DefaultValue}");
                    }
                    else if (p.Type == "selector")
                    {
                        Console.WriteLine($"    Options: {string.Join(", ", p.Options)}");
                        Console.WriteLine($"    Default: {p.DefaultValue}");
                    }
                }
                Console.WriteLine();
            }
            
            Console.WriteLine("=== Runtime Plugin Management ===\n");
            Console.WriteLine("Unregistering 'Blur' effect...");
            pluginManager.UnregisterEffect("Blur");
            Console.WriteLine($"Available effects: {string.Join(", ", pluginManager.GetAvailableEffects())}");
        }
    }
}