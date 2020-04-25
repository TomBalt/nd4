﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleGame.Gui;

namespace ConsoleGame.Game
{
    class PlayerSelectionMenu : Window
    {
        private Button P2;
        private Button P3;
        private Button P4;
        private Button P5;
        private Button P6;
        private Button P7;
        private TextBlock titleTextBlock;
        private int possition = 0;
        List<Button> allButtons = new List<Button>();
        private bool notSelectedNumberOfPlayers = true;
        private int numberOfPlayers;

        public PlayerSelectionMenu() : base(0, 0, 120, 30, '%')
        {

            titleTextBlock = new TextBlock(10, 5, 100, new List<String> { "Please choose number of players!" });

            P2 = new Button(20, 13, 18, 5, "P2");
            P2.SetActive(true);

            P3 = new Button(38, 13, 18, 5, "P3");
            P4 = new Button(56, 13, 18, 5, "P4");
            P5 = new Button(20, 17, 18, 5, "P5");
            
            P6 = new Button(38, 17, 18, 5, "P6");
            P7 = new Button(56, 17, 18, 5, "P7");

            allButtons.Add(P2);
            allButtons.Add(P3);
            allButtons.Add(P4);
            allButtons.Add(P5);
            allButtons.Add(P6);
            allButtons.Add(P7);

        }


        public override void Render()
        {

            Console.Clear();

            base.Render();

            titleTextBlock.Render();

            renderActive(possition);

        }

        public int GetNumberOfPlayers()
        {
            //read input and act accordingly
           do
            {
                Render();
                ConsoleKeyInfo pressedButton = readInput();
                ControlButtonPress(pressedButton);
            } while (notSelectedNumberOfPlayers);
            return numberOfPlayers;
        }

        private void ControlButtonPress(ConsoleKeyInfo pressedChar)
        {
            switch (pressedChar.Key)
            {
                case ConsoleKey.Enter:
                    numberOfPlayers = possition + 2;
                     notSelectedNumberOfPlayers = false;
                    break;
               
                case ConsoleKey.RightArrow:
                    setActiveButtonOrder();
                    break;
                case ConsoleKey.LeftArrow:
                    setActiveButtonOrder(false);
                    break;
            }

        }


        private ConsoleKeyInfo readInput()
        {
            bool invalidButtonPressed = false;
            ConsoleKeyInfo pressedChar;
            do
            {
                pressedChar = Console.ReadKey();
                switch (pressedChar.Key)
                {
                    case ConsoleKey.Enter:
                        invalidButtonPressed = false;
                        break;
                    case ConsoleKey.UpArrow:
                        invalidButtonPressed = false;
                        break;
                    case ConsoleKey.DownArrow:
                        invalidButtonPressed = false;
                        break;
                    case ConsoleKey.RightArrow:
                        invalidButtonPressed = false;
                        break;
                    case ConsoleKey.LeftArrow:
                        invalidButtonPressed = false;
                        break;
                }
            } while (invalidButtonPressed);
            return pressedChar;
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

