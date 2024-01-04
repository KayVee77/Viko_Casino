using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.DataAccess.Interfaces.SlotMacine
{
    public interface IGetSymbols
    {
        Sprite GetSymbolAtPosition(GameObject reel, int position);
        List<Sprite> GetWinningSymbols(Lines.LineType lineType, int lineIndex, int length = 0);
    }
}
