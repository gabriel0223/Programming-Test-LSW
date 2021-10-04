using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject itemInfoWindow;
    [Space(10)]
    
    public SO_Item item;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        itemInfoWindow.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        itemInfoWindow.SetActive(false);
    }
}
