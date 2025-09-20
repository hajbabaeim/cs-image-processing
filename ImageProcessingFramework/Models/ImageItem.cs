using System.Text;

namespace ImageProcessingFramework.Models;

public class ImageItem
{
    public string Id { get; }
    public SimulatedImageData Data { get; set; }
    public List<EffectInstance> Effects { get; } = new List<EffectInstance>();
    public List<string> AppliedEffects { get; } = new List<string>();

    public ImageItem(string id, SimulatedImageData data)
    {
        Id = id;
        Data = data;
    }

    public string GetSummary()
    {
        var sb = new StringBuilder();
        sb.Append($"[{Id}] size={Data.Width}x{Data.Height} appliedEffects=[");
        sb.Append(string.Join(", ", AppliedEffects));
        sb.Append("]");
        return sb.ToString();
    }
}
