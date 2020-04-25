using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleGame.Game;
using ConsoleGame.Gui;
using ConsoleGame.Units;

namespace ConsoleGame
{
    class Program
    {
        static void Main()
        {

            Console.CursorVisible = false;
  
            
            GuiController guiController = new GuiController();

            guiController.ShowMainMenu();
        }
    }
}
