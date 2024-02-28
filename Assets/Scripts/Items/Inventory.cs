using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using static UnityEditor.Progress;

//�÷��̾�� �κ��丮 ��Ʈ �߰��ؾ���!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! UISlot�Űܵα�
public class ItemSlot
{
    public ItemData item;
    public int quantity;
}
public class Inventory : MonoBehaviour
{
    public ItemSlotUI[] uiSlot;
    public ItemSlot[] slots;

    public GameObject InventoryWindow;
    

    [Header("Selected Item")]
    private ItemSlot selectedItem;
    private int selectedItemIndex;
    public TextMeshProUGUI selectedItemName;
    public TextMeshProUGUI selectedItemDescription;
    public TextMeshProUGUI selectedItemStatName;
    public TextMeshProUGUI selectedItemStatValue;
    public GameObject useButton;
    public GameObject equipButton;
    public GameObject unEquipButton;


    private int curEquipIndex;

    private PlayerInputController controller;  
    

    [Header("Events")]
    public UnityEvent onOpenInventory;
    public UnityEvent onCloseInventory;

    public static Inventory instance;
    void Awake()
    {
        instance = this;
        controller = GetComponent<PlayerInputController>();
       
    }

    private void Start()
    {
        InventoryWindow.SetActive(false); // ó���� ��������
        slots =new ItemSlot[uiSlot.Length];


        for (int i = 0; i < uiSlot.Length; i++)
        {
            slots[i] = new ItemSlot();
            uiSlot[i].index = i;
            uiSlot[i].Clear();
        }

        ClearSelectedItemWindow();
    }

    


    public void Toggle()
    {
        if (InventoryWindow.activeInHierarchy)
        {
            InventoryWindow.SetActive(false);
            onCloseInventory.Invoke();
            //Ŀ���� ���ɰ�쿡 �ʿ��� �ڵ��ۼ�
        }
        else
        {
            InventoryWindow.SetActive(true);
            onOpenInventory.Invoke();
        }
    }

    public bool IsOpen()
    {
        return InventoryWindow.activeInHierarchy;
    }

    public void AddItem(ItemData item)  //EŰ�� ȹ��
    {
        if (item.canStack)
        {
            ItemSlot slotToStackTo = GetItemStack(item);
            if(slotToStackTo != null)
            {
                slotToStackTo.quantity++;
                UPdateUI();
                return;
            }
        }

        ItemSlot emptySlot = GetEmptySlot();
        if(emptySlot != null)
        {
            emptySlot.item = item;
            emptySlot.quantity = 1;
            UPdateUI();
            return;
        }

        Destroy(item); //������ ���� ��á���� �˾������� ����
    }

    void UPdateUI()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item != null)
                uiSlot[i].Set(slots[i]);
            else
                uiSlot[i].Clear();
        }
    }

    ItemSlot GetItemStack(ItemData item)
    {
        for(int i = 0; i < slots.Length;i++)
        {
            if (slots[i].item == item && slots[i].quantity < item.maxStackAmount)
                return slots[i];
        }
        return null;
    }

    ItemSlot GetEmptySlot()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item == null)
                return slots[i];
        }
        return null;
    }

    public void SelectItem(int index)
    {
        if (slots[index].item == null)
            return;

        selectedItem = slots[index];
        selectedItemIndex = index;

        selectedItemName.text = selectedItem.item.displayName;
        selectedItemDescription.text = selectedItem.item.description;

        selectedItemStatName.text = string.Empty;
        selectedItemStatValue.text = string.Empty;


         for(int i = 0; i < selectedItem.item.consumables.Length; i++) // ���� �ҋ�
        {
            selectedItemStatName.text += selectedItem.item.consumables[i].type.ToString() + "\n";
            selectedItemStatValue.text += selectedItem.item.consumables[i].value.ToString() +"\n";
        }

        useButton.SetActive(selectedItem.item.type == ItemType.Consumable);
        equipButton.SetActive(selectedItem.item.type == ItemType.Equipable && !uiSlot[index].equipped);
        unEquipButton.SetActive(selectedItem.item.type == ItemType.Equipable && uiSlot[index].equipped);

    }

    private void ClearSelectedItemWindow()
    {
        selectedItem = null;

        selectedItemName.text = string.Empty;
        selectedItemDescription.text = string.Empty; ;

        selectedItemStatName.text = string.Empty;
        selectedItemStatValue.text = string.Empty;

        useButton.SetActive(false);
        equipButton.SetActive(false);
        unEquipButton.SetActive(false);
    }

    //====================================== ��ư

    public void OnUseButton()
    {
        if(selectedItem.item.type == ItemType.Consumable)
        {
            for (int i = 0; i < selectedItem.item.consumables.Length; i++) // ���� �ҋ�
            {
                switch(selectedItem.item.consumables[i].type)
                {
                   // case ConsumableType.Health:
                     //   OverallManager.Instance.PublicVariable.stamina(selectedItem.item.consumables[i].value); break;
                }
            }
        }
        RemoveSelectedItem();
    }

    public void OnEquipButton()
    {

    }

    void UnEquip(int index)
    {

    }

    public void OnUnEquipButton()
    {

    }

    private void RemoveSelectedItem()
    {
        selectedItem.quantity--;

        if (selectedItem.quantity <= 0)
        {
            if (uiSlot[selectedItemIndex].equipped)
            {
                UnEquip(selectedItemIndex);
            }

            selectedItem.item = null;
            ClearSelectedItemWindow();
        }

        UPdateUI();
    }

    public void RemoveItem(ItemData item)
    {

    }

    public bool HasItems(ItemData item,int quantity)
    {
        return false;
    }

}
