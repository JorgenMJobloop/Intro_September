using System;
using System.IO;

public class ImageGlitchEffect
{
    /// <summary>
    /// The path of the image we take as input
    /// </summary>
    private readonly string? _inputPath;
    /// <summary>
    /// The path to the new image we get as an output
    /// </summary>
    private readonly string? _outputPath;
    /// <summary>
    /// Number of bytes to write to the file
    /// </summary>
    private readonly int ByteCount;

    public ImageGlitchEffect(string inputPath, string outputPath, int byteCount)
    {
        _inputPath = inputPath;
        _outputPath = outputPath;
        ByteCount = byteCount;
    }

    public void ApplyEffect()
    {
        if (!File.Exists(_inputPath))
        {
            throw new IOException($"Could not locate the imagefile: {_inputPath}, are you sure it exists?");
        }

        byte[] bytes = File.ReadAllBytes(_inputPath);
        Random random = new Random();

        // We apply the effect after header (so we skip the first 100 bytes to avoid conflicts)
        int start = 100;
        for (int i = 0; i < ByteCount; i++)
        {
            int index = random.Next(start, bytes.Length);
            bytes[index] = (byte)random.Next(0, 256);
        }

        File.WriteAllBytes(_outputPath!, bytes);
        Console.WriteLine($"Image with applied glitch effect saved to: {_outputPath}");
    }
}