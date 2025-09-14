using NumberQuest.Model;

namespace NumberQuest.View;

public class GameView
{
    public void ShowMenu()
    {
        Console.Clear();
        Console.WriteLine("#===================== Number Quest =====================#");
        Console.WriteLine("\t1. New Game (Guess the Program’s Number)");
        Console.WriteLine("\t2. New Game (Program Guesses Your Number)");
        Console.WriteLine("\t3. Leaderboards");
        Console.WriteLine("\t0. Exit");
    }

    public void ShowMessage(string msg)
    {
        Console.WriteLine(msg);
    }

    public void ShowResult(GameModel result)
    {
        Console.WriteLine($"\nPlayer: {result.PlayerName}");
        Console.WriteLine($"Number: {result.SecretNumber}");
        Console.WriteLine($"Attempts: {result.Attempts}");
        Console.WriteLine($"Played: {result.PlayedAt}\n");
    }

    public void ShowLeaderboard(List<GameModel> results)
    {
        Console.WriteLine("\n=== Leaderboards ===");
        Console.WriteLine($"{"Player",-15} {"Number",-10} {"Attempts",-10} {"Date",-20}");
        Console.WriteLine(new string('-', 60));

        foreach (var r in results.OrderBy(r => r.Attempts))
        {
            Console.WriteLine($"{r.PlayerName,-15} {r.SecretNumber,-10} {r.Attempts,-10} {r.PlayedAt,-20}");
        }
    }
}