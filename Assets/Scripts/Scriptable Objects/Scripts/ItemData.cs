using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType
{
    Evidence,  //�ܼ�������
    Equipable, // ��� ������
    Consumable // �Һ� ������
}
public enum ConsumableType
{
    Hunger, // Food�� ġ�� (�ƺ�)
    Health  // FIrst aid kit �� ġ�� (��)
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
    public string displayName;   // ������ �̸�
    public string description;   // ������ ����
    public ItemType type;        // ������ Ÿ��(�ܼ�,���,�Һ�)
    public Sprite icon;             
     

    [Header("Stacking")]
    public bool canStack;        // �������� ���ϼ��ִ���? Food�� aidKit�� ����
    public int maxStackAmount;  // ���� �ѵ�

    [Header("Consumable")]
    public ItemDataConsumable[] consumables;

}
