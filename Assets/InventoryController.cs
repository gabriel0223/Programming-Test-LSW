using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public Transform itemSelector;
    [HideInInspector] public SO_Equipment currentSelectedItem;
    private GameObject itemInfoWindow;
    [HideInInspector] public bool isCarryingItem;
    private Vector3 itemPositionOffset = new Vector2(30, -30);

    private void Awake()
    {
        itemInfoWindow = UIManager.instance.itemInfoWindow;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        itemSelector.position = Input.mousePosition;
    }

    public void SelectSlot(InventorySlot slot)
    {
        if (!isCarryingItem)
        {
            currentSelectedItem = slot.item;
            
            slot.item = null;
            itemInfoWindow.SetActive(false);
            var iconCopy = Instantiate(slot.slotIcon, itemSelector); //copy icon to be carried on item selector
            slot.slotIcon.enabled = false; //disable icon on the slot

            iconCopy.GetComponent<RectTransform>().localPosition += itemPositionOffset;
            
            isCarryingItem = true;
        }
        else
        {
            AddItemToSlot(slot, currentSelectedItem);
        }
    }

    private void AddItemToSlot(InventorySlot slot, SO_Equipment item)
    {
        if (slot.item == null) //if there's no item in the slot
        {
            slot.item = item;
            slot.UpdateItemIcon();
            slot.HoverSlot();
            
            Destroy(itemSelector.GetChild(0).gameObject); //destroy icon copy in the item selector
            isCarryingItem = false;
        }
        else
        {
            ReplaceItem();
        }

        void ReplaceItem()
        {
            var secondSlotItem = slot.item;
            
            //PUT NEW ICON IN THE ITEM SELECTOR
            Destroy(itemSelector.GetChild(0).gameObject); //destroy icon copy in the item selector
            var iconCopy = Instantiate(slot.slotIcon, itemSelector); //copy icon to be carried on item selector
            iconCopy.GetComponent<RectTransform>().localPosition += itemPositionOffset;
            
            //PUT OLD ITEM IN THE SECOND SLOT
            slot.item = currentSelectedItem;
            slot.UpdateItemIcon();
            slot.HoverSlot();

            currentSelectedItem = secondSlotItem;
        }
    }
}
