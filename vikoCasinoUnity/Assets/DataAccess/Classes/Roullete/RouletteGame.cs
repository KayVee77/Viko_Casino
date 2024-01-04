using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Classes
{
    public class RouletteGame : Game
    {
        public RouletteGame():base("", new Random().Next(150, 300), true, 0.01f) 
        {
        }

    }
}
