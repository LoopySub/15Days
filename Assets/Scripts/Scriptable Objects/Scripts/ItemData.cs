using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType
{
    Evidence,  //단서아이템
    Equipable, // 장비 아이템
    Consumable // 소비 아이템
}
public enum ConsumableType
{
    Hunger, // Food로 치료 (아빠)
    Health  // FIrst aid kit 로 치료 (딸)
}

[System.Serializable]
public class ItemDataConsumable
{
    public ConsumableType type;
    public float value;
}

[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string displayName;   // 아이템 이름
    public string description;   // 아이템 설명
    public ItemType type;        // 아이템 타입(단서,장비,소비)
    public Sprite icon;             
     

    [Header("Stacking")]
    public bool canStack;        // 아이템이 쌓일수있는지? Food와 aidKit는 가능
    public int maxStackAmount;  // 축적 한도

    [Header("Consumable")]
    public ItemDataConsumable[] consumables;

}
