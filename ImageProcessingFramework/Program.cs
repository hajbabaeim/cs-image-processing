using System;
using System.Collections.Generic;
using ImageProcessingFramework;
using ImageProcessingFramework.Models;

namespace ImageProcessingFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            var pluginManager = new PluginManager();
            pluginManager.LoadConfig("plugins.json");

            var engine = new EffectsEngine(pluginManager);

            var img1 = new ImageItem("Image#1", SimulatedImageData.CreateDummy("img1", 800, 600));
            var img2 = new ImageItem("Image#2", SimulatedImageData.CreateDummy("img2", 640, 480));
            var img3 = new ImageItem("Image#3", SimulatedImageData.CreateDummy("img3", 1024, 768));

            img1.Effects.Add(new EffectInstance("resize", new EffectParameter("targetSize", 100)));
            img1.Effects.Add(new EffectInstance("blur", new EffectParameter("radius", 2)));

            img2.Effects.Add(new EffectInstance("resize", new EffectParameter("targetSize", 100)));

            img3.Effects.Add(new EffectInstance("resize", new EffectParameter("targetSize", 150)));
            img3.Effects.Add(new EffectInstance("blur", new EffectParameter("radius", 5)));
            img3.Effects.Add(new EffectInstance("grayscale"));

            var images = new List<ImageItem> { img1, img2, img3 };
            engine.Process(images);

            Console.WriteLine();
            Console.WriteLine("=== Final Results ===");
            foreach (var img in images)
                Console.WriteLine(img.GetSummary());

            Console.ReadKey();
        }
    }
}