using Spectre.Console;

public class LsCommand
{
    public string? _path { get; set; }

    public LsCommand(string path)
    {
        _path = path;
    }

    public void Ls()
    {
        if (!Directory.Exists(_path))
        {
            AnsiConsole.MarkupLine($"[red]Could not find: {_path}[/]");
            return;
        }

        AnsiConsole.MarkupLine($"[underline green]Contents in: {_path}[/]");

        var table = new Table();
        table.Border = TableBorder.Rounded;

        table.AddColumn("Name");
        table.AddColumn("Type");
        table.AddColumn(new TableColumn("Size (bytes)").RightAligned());
        table.AddColumn("Last modified");

        // List all directories
        var directories = Directory.GetDirectories(_path!);
        foreach (var dir in directories)
        {
            var dirInfo = new DirectoryInfo(dir);
            table.AddRow(
                $"[blue]{dirInfo.Name}/[/]",
                "Directory",
                "-",
                dirInfo.LastWriteTime.ToString("yyyy-MM-dd HH:mm")
            );
        }

        // List all files
        var files = Directory.GetFiles(_path!);
        foreach (var file in files)
        {
            var fileInfo = new FileInfo(file);
            table.AddRow(
                fileInfo.Name,
                "File",
                fileInfo.Length.ToString(),
                fileInfo.LastWriteTime.ToString("yyyy-MM-dd HH:mm")
            );
        }

        AnsiConsole.Write(table);
    }
}