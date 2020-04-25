using ConsoleGame.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame.Gui
{
    class MainMenu : Window
    {

        private TextBlock titleTextBlock;
        // private PlayerSelectionMenu playerSelectionMenu;
        private GameController gameController;
        private bool continueToRunProgram = true;
        private GameOverMenu gameOverMenu;
        bool playAgain = true;

        public MainMenu() : base(0, 0, 120, 30, '%')
        {

            titleTextBlock = new TextBlock(10, 5, 100, new List<String> { "Press P to Play.", "Press Q to Quit." });
            //  playerSelectionMenu = new PlayerSelectionMenu();
            gameController = new GameController();
            gameOverMenu = new GameOverMenu();
        }

        public override void Render()
        {
            
            do
            {
                Console.Clear();

                base.Render();

                titleTextBlock.Render();

                ChooseMainMenuOption();
                Console.Clear();
                playAgain = true;
                while (playAgain)
                {
                    ChooseGameOverOption();
                }
            } while (continueToRunProgram);
        }


        private void ChooseGameOverOption()
        {
            bool notValidKeyPress = true;
            do
            {
                gameOverMenu.Render();
                
                    ConsoleKeyInfo pressedChar = Console.ReadKey(true);
                    int hashCode = pressedChar.Key.GetHashCode();
                    switch (pressedChar.Key)
                    {
                        case ConsoleKey.R:
                            gameController.ReplayGame();
                            notValidKeyPress = false;
                            
                            break;
                        case ConsoleKey.M:
                            notValidKeyPress = false;
                        playAgain = false;
                            break;
                        case ConsoleKey.Q:
                        playAgain = false;
                        continueToRunProgram = false;
                            notValidKeyPress = false;
                            break;
                    }
                
            } while (notValidKeyPress);
        }
        private void ChooseMainMenuOption()
        {
            bool notValidKeyPress = true;

            do
            {
                while (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pressedChar = Console.ReadKey(true);
                    int hashCode = pressedChar.Key.GetHashCode();

                    switch (pressedChar.Key)
                    {
                        case ConsoleKey.P:
                            notValidKeyPress = false;
                            gameController.StartGame();
                            break;
                        case ConsoleKey.Q:
                            notValidKeyPress = false;
                            continueToRunProgram = false;
                            break;
                    }
                }
            } while (notValidKeyPress);
        }

    }
}
