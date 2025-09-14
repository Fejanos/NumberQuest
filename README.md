# Number Quest 🎲

A simple console-based number guessing game built with **C# .NET** using the **MVC pattern**.  
Players can either guess the program’s secret number or let the program guess their number.  
Game results (player name, secret number, attempts) are stored in a JSON file and displayed in a leaderboard.

---

## What’s here so far
- .NET 8/9 console application
- **MVC structure** (`Models`, `Views`, `Controllers`, `Data`)
- Two game modes:
  - **ProgramRnd** → Player guesses the program’s number
  - **PlayerRnd** → Program guesses the player’s number
- **Leaderboard** with results saved in `leaderboard.json`
- Display of **player name, secret number, attempts, timestamp**
- JSON-based persistence

---

## How to run (VS Code terminal)

Open the built-in terminal in VS Code (shortcut: `` Ctrl+` ``).

### Start the app
```bash
dotnet run
```
---

### Start the app
```bash
#===================== Number Quest =====================#
    1. New Game (Guess the Program’s Number)
    2. New Game (Program Guesses Your Number)
    3. Leaderboards
    0. Exit
```

---

### Example gameplay
Player guesses the program’s number
```bash
I’m thinking of a number between 1 and 100!
Guess: 50
The number is bigger.
Guess: 75
The number is smaller.
Guess: 63
Correct! You guessed it in 3 tries!
```

Program guesses the player’s number
```bash
Pick a number between 1 and 100. Press 'y' when you’re ready!

Greater or lesser than 50?
'g' | 'l' | '=' if equal
```

---

### Leaderboard (JSON format)
Game results are stored automatically in leaderboard.json.
```bash
[
  {
    "PlayerName": "Alice",
    "SecretNumber": 63,
    "Attempts": 3,
    "PlayedAt": "2025-09-13T18:23:45"
  },
  {
    "PlayerName": "Bob",
    "SecretNumber": 42,
    "Attempts": 5,
    "PlayedAt": "2025-09-13T18:45:12"
  }
]
```
