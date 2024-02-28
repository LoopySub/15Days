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

//플레이어에게 인벤토리 시트 추가해야함!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! UISlot옮겨두기
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
        InventoryWindow.SetActive(false); // 처음에 꺼진상태
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
            //커서가 락될경우에 필요한 코드작성
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

    public void AddItem(ItemData item)  //E키로 획득
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

        Destroy(item); //꽉차면 없앰 꽉찼을때 팝업있으면 가능
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


         for(int i = 0; i < selectedItem.item.consumables.Length; i++) // 섭취 할떄
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

    //====================================== 버튼

    public void OnUseButton()
    {
        if(selectedItem.item.type == ItemType.Consumable)
        {
            for (int i = 0; i < selectedItem.item.consumables.Length; i++) // 섭취 할떄
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
