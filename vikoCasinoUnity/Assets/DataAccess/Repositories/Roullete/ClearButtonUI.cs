using Assets.DataAccess.Classes.Base_Classes;
using Assets.DataAccess.Interfaces.Roullete;
using Michsky.MUIP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.DataAccess.Repositories.Roullete
{
    public class ClearButtonUI : IClearButtonUI
    {
        private List<ButtonManager> Buttons;
        public ClearButtonUI(List<ButtonManager> x)
        {
            Buttons = x; 
        }


        public void ClearAllButtonTexts()
        {
            foreach (var button in Buttons)
            {
                button.buttonText = "";
                button.UpdateUI();
            }
            Settings.GameSession.Bets.Clear();
        }
    }
}
