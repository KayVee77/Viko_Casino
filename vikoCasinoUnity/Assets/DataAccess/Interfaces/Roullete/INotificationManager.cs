using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.DataAccess.Interfaces.Roullete
{
    public interface INotificationManager
    {
        public void ShowNotification(string title, string desc, Sprite sprite);
        public void ShowNotification(string title, string desc);
    }
}
