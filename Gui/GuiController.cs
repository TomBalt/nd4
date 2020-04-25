using ConsoleGame.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame.Gui
{
    class GuiController
    {
        private GameWindow gameWindow;
        private GameController gameController;
        private bool continueProgram = true;
        private MainMenu mainMenu;

        public GuiController()
        {

            MainMenu mainMenu = new MainMenu();
            //this.gameWindow = gameWindow;

            //this.gameController = gameController;
            this.mainMenu = mainMenu;
        }




        public void ShowMainMenu()
        { 
            mainMenu.Render();
        }

        public void ShowMenu()
        {

            do
            {
                gameWindow.Render();
                ConsoleKeyInfo pressedButton = readInput();
                ControlButtonPress(pressedButton);

            } while (continueProgram);
        }



        private ConsoleKeyInfo readInput()
        {
            bool invalidButtonPressed = false;
            ConsoleKeyInfo pressedChar;
            do
            {
                pressedChar = Console.ReadKey();
                switch (pressedChar.Key)
                {
                    case ConsoleKey.Escape:
                        invalidButtonPressed = false;
                        break;
                    case ConsoleKey.Enter:
                        invalidButtonPressed = false;
                        break;
                    case ConsoleKey.RightArrow:
                        invalidButtonPressed = false;
                        break;
                    case ConsoleKey.LeftArrow:
                        invalidButtonPressed = false;
                        break;
                    default:
                        Console.WriteLine("Use left or right OR ENTER or ESC buttons.");
                        break;
                }
            } while (invalidButtonPressed);
            return pressedChar;
        }

        private void ControlButtonPress(ConsoleKeyInfo pressedChar)
        {
            switch (pressedChar.Key)
            {
                case ConsoleKey.Escape:
                    continueProgram = false;
                    break;
                case ConsoleKey.Enter:
                    ExecuteButton();
                    break;
                case ConsoleKey.RightArrow:
                    gameWindow.setActiveButtonOrder();
                    break;
                case ConsoleKey.LeftArrow:
                    gameWindow.setActiveButtonOrder(false);
                    break;
            }

        }

        private void ExecuteButton()
        {
            string excutedButtonName = gameWindow.GetExecutedButtonName();
            switch (excutedButtonName)
            {
                case "Start":
                    gameController.StartGame();
                    break;
                case "Credits":
                    //creditWindow.Render();
                    break;
                case "Quit":
                    Console.WriteLine("Quiting the MENU!");
                    continueProgram = false;
                    break;
            }
        }
    }
}