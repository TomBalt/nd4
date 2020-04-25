using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame.Gui
{

    class CreditWindow : Window
    {
        private Button backButton;

        private TextBlock creditTextBlock;

        private bool render = true;

        public CreditWindow() : base(28, 10, 60, 18, '@')
        {
            List<String> creditData = new List<string>();

            creditData.Add("");
            creditData.Add("Game design:");
            creditData.Add("Tomas Baltusis");
            creditData.Add("");
            creditData.Add("Programuotojas:");
            creditData.Add("Tomas Baltusis");
            creditData.Add("");
            creditData.Add("\'Art\':");
            creditData.Add("Tomas Baltusis");
            creditData.Add("");
            creditData.Add("Marketingas:");
            creditData.Add("Tomas Baltusis");
            creditData.Add("");

            creditTextBlock = new TextBlock(28 + 1, 10 + 1, 60 - 1, creditData);


            backButton = new Button(28 + 20, 10 + 14, 18, 3, "Back");
            backButton.SetActive(true);
        }

        public override void Render()
        {
            render = true;
            while (render == true) { 
                base.Render();
                creditTextBlock.Render();
                backButton.Render();
                HandleButtonAction();
                Console.SetCursorPosition(0, 0);
            }
        }

        private void HandleButtonAction()
        {

            ConsoleKeyInfo pressedChar;
            pressedChar = Console.ReadKey();
            switch (pressedChar.Key)
            {
                case ConsoleKey.Escape:
                    render = false;
                    break;
                case ConsoleKey.Enter:
                    render = false;
                    break;
            }
        }
}
}
