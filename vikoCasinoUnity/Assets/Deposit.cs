using Assets.DataAccess.Classes.Base_Classes;
using Assets.DataAccess.Interfaces.Roullete;
using Assets.DataAccess.Repositories.Roullete;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Deposit : MonoBehaviour
{

    public TextMeshProUGUI deposit;
    private IRemoverInvisibleCharacters remover;

    private void Start()
    {
        remover = new RemoverInvisibleCharacters();
    }

    public void DepositMoney()
    {
        string amount = deposit.GetParsedText();
        amount = remover.RemoveInvisibleCharacters(amount);
        Settings.Balance.setAmount(int.Parse(amount) + Settings.Balance.getAmount() +1 );
    }
}
