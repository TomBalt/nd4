using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame.Gui
{
    class TextLine : GuiObject
    {
        private string data;

        public TextLine(int x, int y, int width, string data) : base(x, y, width, 0)
        {
            this.data = data;
        }

        public override void Render()
        {
            Console.SetCursorPosition(X, Y);
            if (Width > data.Length)
            {
                int offset = (Width - data.Length) / 2;
                for (int i = 0; i < offset; i++)
                {
                    Console.Write(' ');
                }
            }

            Console.Write(data);
        }

        public string GetButtonName()
        {
            return data;
        }

        public void UpdateTextlineText(string newText)
        {
            data = newText;
        }
    }
}
