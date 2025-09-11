public interface IFileReader
{
    /// <summary>
    /// Read the content of a file passed to this method.
    /// </summary>
    /// <param name="filePath">path to the file we want to read</param>
    void ReadAllContent(string filePath);

    /// <summary>
    /// Read the content of a file passed to this method and return it as a string
    /// </summary>
    /// <param name="filePath">path to the file we want to read</param>
    /// <returns>string</returns>
    string ReadContentAsString(string filePath);
}