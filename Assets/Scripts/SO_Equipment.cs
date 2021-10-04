using System.Collections;
using System.Collections.Generic;
using MyBox;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Item/Equipment")]
public class SO_Equipment : SO_Item
{
    public enum EquipmentType
    {
        Head, Face, Top, Arms, Bottom, Shoes, Weapon
    }
    
    public EquipmentType equipmentType;
    public Sprite firstSprite;
    
    [ConditionalField(nameof(equipmentType), false, EquipmentType.Top, EquipmentType.Arms)]
    public Sprite secondSprite;
    
    [ConditionalField(nameof(equipmentType), false, EquipmentType.Arms)]
    public Sprite thirdSprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
