using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame.Gui
{
    sealed class GameWindow : Window
    {
        private TextBlock titleTextBlock;
        private int possition = 0;
        List<Button> allButtons = new List<Button>();

        public GameWindow(List<String> titleText) : base(0, 0, 120, 30, '%')
        {

            titleTextBlock = new TextBlock(10, 5, 100, titleText);

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
