using NumberQuest.View;
using NumberQuest.Data;
using NumberQuest.Model;
namespace NumberQuest.Controller;

public class GameController
{

    private readonly GameView view;
    private readonly FileStorage storage;
    private List<GameModel> leaderboard;

    public GameController(GameView view, FileStorage storage)
    {
        this.view = view;
        this.storage = storage;
        leaderboard = storage.Load();
    }

    public void Run()
    {
        while (true)
        {
            view.ShowMenu();
            ConsoleKeyInfo c = Console.ReadKey(true);

            switch (c.KeyChar)
            {
                case '1':
                    PlayProgramRnd();
                    break;
                case '2':
                    PlayPlayerRnd();
                    break;
                case '3':
                    view.ShowLeaderboard(leaderboard);
                    Console.ReadKey();
                    break;
                case '0':
                    storage.Save(leaderboard);
                    return;
            }
        }
    }

    private void PlayProgramRnd()
    {
        Console.Write("\nEnter your name: ");
        string playerName = Console.ReadLine() ?? "Unknown";

        int rnd = new Random().Next(1, 101);
        int attempts = 0;

        view.ShowMessage("I’m thinking of a number between 1 and 100!");

        while (true)
        {
            Console.Write("Guess: ");
            if (!int.TryParse(Console.ReadLine(), out int guess))
            {
                continue;
            }

            attempts++;

            if (guess < rnd)
            {
                view.ShowMessage("The number is bigger.");
            }
            else if (guess > rnd)
            {
                view.ShowMessage("The number is smaller.");
            }
            else
            {
                view.ShowMessage($"Correct! You guessed it in {attempts} tries!");
                var result = new GameModel
                {
                    PlayerName = playerName,
                    SecretNumber = rnd,
                    Attempts = attempts
                };
                leaderboard.Add(result);
                break;
            }
        }
        Console.ReadKey();
    }
    
    private void PlayPlayerRnd()
    {
        Console.Write("\nEnter your name: ");
        string playerName = Console.ReadLine() ?? "Unknown";

        view.ShowMessage("Pick a number between 1 and 100. Press 'y' when ready!");
        if (Console.ReadKey(true).KeyChar.ToString().ToLower() != "y")
        {
            return;
        }

        int low = 1, high = 100, attempts = 0;
        bool game = true;

        while (game)
        {
            int guess = (low + high) / 2;
            attempts++;
            Console.WriteLine($"\nGreater or lesser than {guess}?\n'g' | 'l' | '=' if equal");

            string choice = Console.ReadKey(true).KeyChar.ToString().ToLower();
            switch (choice)
            {
                case "g":
                    low = guess + 1;
                    break;
                case "l":
                    high = guess - 1;
                    break;
                case "=":
                    view.ShowMessage($"I guessed it in {attempts} tries! Your number was {guess}!");
                    var result = new GameModel
                    {
                        PlayerName = playerName,
                        SecretNumber = guess,
                        Attempts = attempts
                    };
                    leaderboard.Add(result);
                    game = false;
                    break;
            }
        }
        Console.ReadKey();
    }
}