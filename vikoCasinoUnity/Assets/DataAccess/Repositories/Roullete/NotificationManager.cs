using Assets.DataAccess.Interfaces.Roullete;
using Michsky.MUIP;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NotificationManager : INotificationManager
{
    private Michsky.MUIP.NotificationManager myNotification;
    private MonoBehaviour coroutineStarter;

    public NotificationManager(Michsky.MUIP.NotificationManager x, MonoBehaviour coroutineStarter)
    {
        myNotification = x;
        this.coroutineStarter = coroutineStarter;
    }

    public void ShowNotification(string title, string desc, Sprite sprite)
    {
        myNotification.icon = sprite;
        myNotification.title = title;
        myNotification.description = desc;
        myNotification.UpdateUI();
        myNotification.Open();

        coroutineStarter.StartCoroutine(CloseAfterDelay(5.0f));
    }
    
    public void ShowNotification(string title, string desc)
    {
        myNotification.title = title;
        myNotification.description = desc;
        myNotification.UpdateUI();
        myNotification.Open();

        coroutineStarter.StartCoroutine(CloseAfterDelay(5.0f));
    }

    private IEnumerator CloseAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        myNotification.Close();
    }

}
