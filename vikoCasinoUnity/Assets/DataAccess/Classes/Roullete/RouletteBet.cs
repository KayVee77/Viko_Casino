using Assets.DataAccess.Classes.Base_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.DataAccess.Classes
{
    public class RouletteBet : Bet
    {
        public RouletteColors Color { get; set; }
        public int Number { get; set; }
        public decimal PayoutMultiplier { get; set; }

        public RouletteBet()
        {
            
        }

        public RouletteBet(RouletteColors color, int number)
        {
            this.Color = color;
            this.Number = number;
        }

        public override string ToString()
        {
            return $"{this.Number} {this.Color}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            RouletteBet b = (RouletteBet)obj;

            return (Color == b.Color) && (Number == b.Number);
        }

        public override int GetHashCode()
        {
            return (int)Color * 31 + Number;
        }
    }
}
