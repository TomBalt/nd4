using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame.Units
{
    class Dice
    {
        public int Score { get; set; }
      

        public Dice() { 
            
        }
       

        public void ThrowADice() {
            var rand = new Random();
            Score = rand.Next(1, 6);
        }
    }

    
}
