using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.DataAccess.Classes.Dice
{
    public class Dices
    {
        public int Number {  get; } 

        public int getNumber()
        {
            return this.Number;
        }

        public Dices(int x)
        {
            this.Number = x;
        }
    }
}
