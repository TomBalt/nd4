using ConsoleGame.Gui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame.Game
{
    class GameNotificationWindow : Window
    {
        private TextBlock messageTextBox;


        public GameNotificationWindow(List<String> winnerData) : base(45, 10, 40, 10, 'X')
        {
            
            messageTextBox = new TextBlock(base.X + 10, base.Y + 3, base.Height, winnerData);
            base.X = 45;
            base.Y = 10;
            base.Width = 40;
            base.Height = 10;

        }

        public override void Render()
        {
            base.Render();
            messageTextBox.Render();
            Console.SetCursorPosition(0, 0);
        }


    }
}
