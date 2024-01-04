using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace DataAccess.Classes
{
    public class SlotGame : Game
    {
        public GameObject[] reels;

        public SlotGame(string whatWeWin, float numberOfTurns, bool canWeTurn, float speed) : base(whatWeWin, numberOfTurns, canWeTurn, speed)
        {
        }


    }
}
