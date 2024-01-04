using Assets.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Classes
{
    public abstract class Game
    {
        public Game(string whatWeWin, float numberOfTurns, bool canWeTurn, float speed)
        {
            WhatWeWin = whatWeWin;
            NumberOfTurns = numberOfTurns;
            CanWeTurn = canWeTurn;
            Speed = speed;
        }

        protected string WhatWeWin { get; set; }
        protected float NumberOfTurns { get; set; }
        protected bool CanWeTurn { get; set; }
        protected float Speed { get; set; }
        protected bool CanWeBet { get; set; }

        public void setCanWeTurn(bool x)
        {
            this.CanWeTurn = x;
        }
        public bool getCanWeTurn()
        {
            return this.CanWeTurn;
        }
        public string getWhatWeWin()
        {
            return this.WhatWeWin;
        }
        public  void setWhatWeWin(string whatWewin)
        {
            this.WhatWeWin = whatWewin;
        }
        public float getNumberOfTurns()
        {
            return this.NumberOfTurns;
        }
        public void setNumberOfTurns(float number)
        {
            this.NumberOfTurns = number;
        }
        public float getSpeed()
        {
            return this.Speed;
        }
        public void setSpeed(float s)
        {
            this.Speed = s;
        }
    }
}
