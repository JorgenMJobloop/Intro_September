public class ReadTextFile
{
    public void ReadFileContent(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new FileLoadException();
        }
        Console.WriteLine(File.ReadAllText(filePath));
    }

    public void TestNewLineInMiddleOfText()
    {
        Console.WriteLine($"This is a long text\n Here are some \n spaces\n empty \n newlines \n\n\n\n");
    }
}