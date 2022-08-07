using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyManager : MonoBehaviour
{

    [SerializeField]
    private int _moneyCount = 0;

    private void OnEnable()
    {
        TriggerManager.OnMoneyCollected += IncreaseMoney;
    }

    private void OnDisable()
    {
        TriggerManager.OnMoneyCollected -= IncreaseMoney;
    }


    private void IncreaseMoney()
    {
        _moneyCount += 50;
    }



}//Class
