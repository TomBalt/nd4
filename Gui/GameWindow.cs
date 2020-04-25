using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame.Gui
{
    sealed class GameWindow : Window
    {
        private Button startButton;
        private Button creditsButton;
        private Button quitButton;
        private TextBlock titleTextBlock;
        private int possition = 0;
        List<Button> allButtons = new List<Button>();

        public GameWindow() : base(0, 0, 120, 30, '%')
        {

            titleTextBlock = new TextBlock(10, 5, 100, new List<String> { "Super duper zaidimas", "Tomas Baltusis kuryba!", "Made in basement as a startup game!!!" });

            startButton = new Button(20, 13, 18, 5, "Start");
            startButton.SetActive(true);

            creditsButton = new Button(50, 13, 18, 5, "Credits");

            quitButton = new Button(80, 13, 18, 5, "Quit");

            allButtons.Add(startButton);
            allButtons.Add(creditsButton);
            allButtons.Add(quitButton);

        }

        public int GetActiveButtonNumber()
        {
            return possition;
        }

        public string GetExecutedButtonName()
        {

            return allButtons[possition].GetButtonName();
        }

        public override void Render()
        {

                Console.Clear();

                base.Render();

                titleTextBlock.Render();

                renderActive(possition);
        }

        
        public void setActiveButtonOrder(bool add = true)
        {
            if (possition >= 0 && possition < allButtons.Count)
            {


                if (add == true)
                {
                    if (possition <= allButtons.Count - 2)
                    {
                        possition++;
                    }

                }
                else
                {
                    if (possition > 0)
                    {
                        possition--;
                    }

                }
            }
        }
        private void renderActive(int possition)
        {
            for (int i = 0; i < allButtons.Count; i++)
            {
                if (i == possition)
                {
                    allButtons[i].SetActive(true);
                    allButtons[i].Render();
                }
                else
                {
                    allButtons[i].SetActive(false);
                    allButtons[i].Render();
                }

            }
        }
    }
}
