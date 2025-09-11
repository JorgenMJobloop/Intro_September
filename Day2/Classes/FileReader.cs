public class FileReader : IFileReader
{
    public void ReadAllContent(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new Exception("An error occured when loading the file!");
        }
        Console.WriteLine(File.ReadAllText(filePath));
    }

    public string ReadContentAsString(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new Exception("An error occured when loading the file!");
        }
        return File.ReadAllText(filePath);
    }
}