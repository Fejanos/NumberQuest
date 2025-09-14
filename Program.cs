using NumberQuest.Model;
using NumberQuest.View;
using NumberQuest.Data;
using NumberQuest.Controller;

GameView view = new GameView();
FileStorage storage = new FileStorage();
GameController controller = new GameController(view, storage);

controller.Run();