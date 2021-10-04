using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentSlot : InventorySlot
{
    public SO_Equipment.EquipmentType slotType;
    private void Awake()
    {
        slotIcon = transform.GetChild(0).GetComponent<Image>();
        itemInfoWindow = UIManager.instance.itemInfoWindow;
    }

    private void OnEnable()
    {
        // UpdateItemIcon();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
