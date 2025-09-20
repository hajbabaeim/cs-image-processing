namespace ImageProcessingFramework.Framework;

public class ImageData
{
    public string Id { get; }
    public byte[] Data { get; private set; }
    public int Width { get; private set; }
    public int Height { get; private set; }
    public string Format { get; private set; }

    public ImageData(string id, int width, int height)
    {
        Id = id;
        Width = width;
        Height = height;
        Format = "RGB";
        Data = new byte[width * height * 3];
        new Random().NextBytes(Data);
    }

    public ImageData Clone()
    {
        var clone = new ImageData(Id, Width, Height);
        Array.Copy(Data, clone.Data, Data.Length);
        clone.Format = Format;
        return clone;
    }

    public void UpdateSize(int newWidth, int newHeight)
    {
        Width = newWidth;
        Height = newHeight;
        Data = new byte[newWidth * newHeight * 3];
        new Random().NextBytes(Data);
    }
}