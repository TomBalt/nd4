using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame.Gui
{
    abstract class GuiObject
    {
        protected int X;
        protected int Y;
        protected int Width;
        protected int Height;

        public GuiObject(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        abstract public void Render();
    }
}
