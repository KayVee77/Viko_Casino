using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.DataAccess.Interfaces.SlotMacine
{
    public interface ILineCheck
    {
        void CheckWin(int lineIndex, int betAmount);
        void CheckVLineWin(int betAmount);
        void CheckInverseVLineWin(int betAmount);
        bool IsWinningLine(Sprite symbol, int line);
        bool IsVWinningLine(Sprite symbol, int length);
        bool IsInverseVWinningLine(Sprite symbol, int length);

    }
}
