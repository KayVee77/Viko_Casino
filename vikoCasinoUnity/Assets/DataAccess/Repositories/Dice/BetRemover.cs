using Assets.DataAccess.Interfaces.DiceGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.DataAccess.Repositories.Dice
{
    public class BetRemover : IBetRemover
    {
        List<TextMeshProUGUI> bets;

        public BetRemover(List<TextMeshProUGUI> x)
        {
            bets = x;
        }

        public void removeBetText()
        {
            foreach (var bet in bets)
            {
                bet.text = "";
            }
        }
    }
}
