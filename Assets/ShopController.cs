using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    [SerializeField] private GameObject purchasablePrefab;
    [SerializeField] private Transform itemsOnSale;
    [SerializeField] private GameObject soldOutText;
    private InteractiveShop activeInteractiveShop;
    private PlayerMoney playerMoney;

    // Start is called before the first frame update
    void Start()
    {
        playerMoney = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMoney>();
    }

    private void OnEnable()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            CloseShop();
        }
    }

    public void OpenShop(InteractiveShop interactiveShop, List<SO_Equipment> itemList)
    {
        UIManager.instance.interactingWithUI = true;
        UIManager.instance.uiState = UIManager.UIStates.Shopping;
        gameObject.SetActive(true);
        UIManager.instance.inventoryWindow.transform.SetParent(transform); //inventory now is a child of the shop
        UIManager.instance.playerMoneyWindow.transform.SetParent(transform); //money window now is a child of the shop
        activeInteractiveShop = interactiveShop;
        
        foreach (var item in itemList)
        {
            var newPurchasable = Instantiate(purchasablePrefab, itemsOnSale).GetComponent<Purchasable>();
            newPurchasable.item = item;
            newPurchasable.UpdatePurchasableUI();
        }
    }

    public void CloseShop()
    {
        UIManager.instance.interactingWithUI = false;
        UIManager.instance.uiState = UIManager.UIStates.Idle;
        UIManager.instance.inventoryWindow.transform.SetParent(UIManager.instance.playerMenu.transform); //inventory is a child of the player menu again
        UIManager.instance.playerMoneyWindow.transform.SetParent(UIManager.instance.playerMenu.transform); //money window is a child of the player menu again
        
        if (UIManager.instance.itemInfoWindow.activeSelf)
            UIManager.instance.itemInfoWindow.SetActive(false);

        foreach (var purchasable in itemsOnSale.GetComponentsInChildren<Purchasable>())
        {
            Destroy(purchasable.gameObject);
        }
        
        gameObject.SetActive(false);
    }

    public void AddItemToShop(SO_Equipment item)
    {
        activeInteractiveShop.items.Add(item);
        
        var newPurchasable = Instantiate(purchasablePrefab, itemsOnSale).GetComponent<Purchasable>();
        newPurchasable.item = item;
        newPurchasable.UpdatePurchasableUI();
    }
    
    public void RemoveItemFromShop(SO_Equipment item)
    {
        activeInteractiveShop.items.Remove(item);
    }

    public void SellItem(SO_Equipment item)
    {
        AddItemToShop(item);
        playerMoney.UpdateCoins(item.sellingPrice);
    }
}
