namespace ImageProcessingFramework.Framework;

    public class ImageProcessor
    {
        private readonly PluginManager _pluginManager;

        public ImageProcessor(PluginManager pluginManager)
        {
            _pluginManager = pluginManager;
        }

        public Dictionary<string, ImageData> ProcessBatch(Dictionary<string, ImageRequest> requests)
        {
            var results = new Dictionary<string, ImageData>();

            foreach (var request in requests)
            {
                Console.WriteLine($"\n[Processing {request.Key}]");
                var processedImage = ProcessSingleImage(request.Value);
                results[request.Key] = processedImage;
            }

            return results;
        }

        private ImageData ProcessSingleImage(ImageRequest request)
        {
            var currentImage = request.Image.Clone();

            foreach (var effectConfig in request.Effects)
            {
                var effect = _pluginManager.GetEffect(effectConfig.EffectName);
                if (effect == null)
                {
                    Console.WriteLine($"  ⚠ Effect '{effectConfig.EffectName}' not found");
                    continue;
                }

                Console.WriteLine($"  → Applying {effectConfig.EffectName}");
                
                foreach (var param in effectConfig.Parameters)
                {
                    Console.WriteLine($"    • {param.Key}: {param.Value}");
                }

                currentImage = effect.Apply(currentImage, effectConfig.Parameters);
            }

            return currentImage;
        }
    }

    public class ImageRequest
    {
        public ImageData Image { get; set; }
        public List<EffectConfig> Effects { get; set; } = new();
    }

    public class EffectConfig
    {
        public string EffectName { get; set; }
        public Dictionary<string, object> Parameters { get; set; } = new();
    }