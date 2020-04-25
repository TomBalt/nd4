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

        private MainMenu mainMenu = new MainMenu();
        
        
        public void ShowMainMenu()
        { 
            mainMenu.Render();
        }


    }
}