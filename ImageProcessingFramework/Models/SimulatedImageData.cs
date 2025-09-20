namespace ImageProcessingFramework.Models;

public class SimulatedImageData
{
    public string Name { get; }
    public int Width { get; set; }
    public int Height { get; set; }
    public byte[] Payload { get; set; }

    public SimulatedImageData(string name, int width, int height, byte[] payload)
    {
        Name = name;
        Width = width;
        Height = height;
        Payload = payload;
    }

    public static SimulatedImageData CreateDummy(string name, int width, int height)
    {
        var payload = new byte[width * height];
        return new SimulatedImageData(name, width, height, payload);
    }
}