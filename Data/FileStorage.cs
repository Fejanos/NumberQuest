using System.Text.Json;
using NumberQuest.Model;

namespace NumberQuest.Data;

public class FileStorage
{
    private readonly string filePath;

    public FileStorage(string filePath = "leaderboard.json")
    {
        this.filePath = filePath;
    }

    public List<GameModel> Load()
    {
        if (!File.Exists(filePath))
        {
            return new List<GameModel>();
        }
        string json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<List<GameModel>>(json) ?? new List<GameModel>();
    }

    public void Save(List<GameModel> results)
    {
        string json = JsonSerializer.Serialize(results, new JsonSerializerOptions
        {
            WriteIndented = true
        });
        File.WriteAllText(filePath, json);
    }
}