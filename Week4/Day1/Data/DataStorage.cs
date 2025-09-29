using System.Text.Json;

public static class DataStorage
{
    private const string filePath = "database.json"; // Not really a database, for educational purposes.

    public static AppData Load()
    {
        if (!File.Exists(filePath))
        {
            return new AppData();
        }

        var json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<AppData>(json) ?? new AppData();
    }

    public static void Save(AppData data)
    {
        var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, json);
    }
}

