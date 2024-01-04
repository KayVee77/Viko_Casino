using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.DataAccess.Interfaces.SlotMacine
{
    public  interface ICalculateReward
    {
        int CalculateReward(List<Sprite> winningSymbols, int betAmount);
    }
}
