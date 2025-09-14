namespace NumberQuest.Model;

public class GameModel
{
    public string PlayerName { get; set; } = string.Empty;
    public int SecretNumber { get; set; }
    public int Attempts { get; set; }
    public DateTime PlayedAt { get; set; } = DateTime.Now;
}