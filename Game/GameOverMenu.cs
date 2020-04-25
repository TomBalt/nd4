using ConsoleGame.Gui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame.Game
{
    class GameOverMenu : Window
    {


        private TextLine titleTextLine;
        private bool haveNotMadeAChoice = true;
        private string answere;




        public GameOverMenu() : base(0, 0, 120, 30, '$')
        {

            titleTextLine = new TextLine(10, 5, 100, "R - Replay, M - Go to menu. Q - Quit");

        }


        public override void Render()
        {

            Console.Clear();

            base.Render();

            titleTextLine.Render();

        }

        public string GetGameOverMenuAnswere()
        {
            //read input and act accordingly
            do
            {
                Render();
                ControlButtonPress();
            } while (haveNotMadeAChoice);
            return answere;
        }

        private void ControlButtonPress()
        {
            ConsoleKeyInfo pressedChar = Console.ReadKey();
            switch (pressedChar.Key)
            {
                case ConsoleKey.R:
                    haveNotMadeAChoice = false;
                    answere = "R";
                    break;
                case ConsoleKey.M:
                    haveNotMadeAChoice = false;
                    answere = "M";
                    break;
                case ConsoleKey.Q:
                    haveNotMadeAChoice = false;
                    answere = "Q";
                    break;
            }

        }
    }
}

