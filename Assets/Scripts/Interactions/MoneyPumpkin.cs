using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyPumpkin : MonoBehaviour
{
    [SerializeField] private float moneyAmountHidden;
    [HideInInspector] public bool wasTheMoneyTaken;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GiveMoneyToPlayer()
    {
        if (wasTheMoneyTaken) return;
        
        Debug.Log("I GAVE PLAYER " + moneyAmountHidden + "MONEYS");
        wasTheMoneyTaken = true;
    }
}
