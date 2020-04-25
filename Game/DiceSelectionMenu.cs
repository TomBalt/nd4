using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleGame.Gui;

namespace ConsoleGame.Game
{
    class DiceSelectionMenu : Window
    {
        private TextLine titleTextLine;
        private bool notSelectedNumberOfDices = true;
        private int numberOfDices = 1;


        public DiceSelectionMenu() : base(0, 0, 120, 30, '%')
        {

            titleTextLine = new TextLine(10, 5, 100, "Players will have 1 dice");

        }


        public override void Render()
        {

            Console.Clear();

            base.Render();

            titleTextLine.Render();
           
        }

        public int GetNumberOfDices()
        {
            //read input and act accordingly
            do
            {
                Render();
                ControlButtonPress();
                titleTextLine.UpdateTextlineText($"Players will have {numberOfDices} dice");
            } while (notSelectedNumberOfDices);
            return numberOfDices;
        }

        private void ControlButtonPress()
        {

            ConsoleKeyInfo pressedChar = Console.ReadKey();
            switch (pressedChar.Key)
            {
                case ConsoleKey.Enter:
                    notSelectedNumberOfDices = false;
                    break;
                case ConsoleKey.OemPlus:
                    numberOfDices += 1;
                    break;
                case ConsoleKey.OemMinus:
                    if (numberOfDices > 1)
                    {
                        numberOfDices -= 1;
                    }
                    break;
            }

        }
    }
}
