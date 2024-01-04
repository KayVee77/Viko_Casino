using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.DataAccess.Interfaces.SlotMacine
{
    public interface IReelController
    {
        void ReelStopped();
        void RandomizeReel(GameObject reel);
        void ResetReels();
        void StartSpin();
    }
}
