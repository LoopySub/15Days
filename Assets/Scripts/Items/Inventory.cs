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
using UnityEngine.UI;
using static UnityEditor.Progress;


public class ItemSlot
{
    public ItemData item;
    public int quantity;
}
public class Inventory : MonoBehaviour
{
    public ItemSlotUI[] uiSlot;
    public ItemSlot[] slots;

    public GameObject InventoryWindow;  // 인벤토리창
    

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


    public AudioClip openInventory;
    public AudioClip eat;
    public AudioSource audioSource;

    [Header("Events")]
    public UnityEvent onOpenInventory;
    public UnityEvent onCloseInventory;

    public static Inventory instance;
    void Awake()
    {
        instance = this;
        
       
    }

    private void Start()
    {
        InventoryWindow.SetActive(false);    // 처음에 꺼진상태
        slots =new ItemSlot[uiSlot.Length];  // Uislot을 14개만듬


        for (int i = 0; i < uiSlot.Length; i++)
        {
            slots[i] = new ItemSlot();
            uiSlot[i].index = i;
            uiSlot[i].Clear();
        }

        ClearSelectedItemWindow();
    }

 


    public void Toggle()   //인벤토리창
    {
        if (InventoryWindow.activeInHierarchy)
        {
            audioSource.PlayOneShot(openInventory);
            InventoryWindow.SetActive(false);
            onCloseInventory.Invoke();
            // 공격이 안나가게 해야함
        }
        else
        {
            audioSource.PlayOneShot(openInventory);
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
        if (item.canStack)   //Scriptable Object에서 아이템이 스택이 가능한 아이템이면 (현재 구급상자,Food만 스택가능)
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
            if (item.displayName == "항생제")
            {
                OverallManager.Instance.PublicVariable.IsGetAntibiotic = true;
            }
            if (item.displayName == "연구소 출입 카드키")
            {
                OverallManager.Instance.PublicVariable.IsLabMainKeyGet = true;
            }
            if (item.displayName == "미완성 백신 A")
            {
                OverallManager.Instance.PublicVariable.IsDetoA = true;
            }
            if (item.displayName == "미완성 백신 B")
            {
                OverallManager.Instance.PublicVariable.IsDetoB = true;
            }
            if (item.displayName == "미완성 백신 C")
            {
                OverallManager.Instance.PublicVariable.IsDetoC = true;
            }
            if (item.displayName == "연구소 내부 카드키")
            {
                OverallManager.Instance.PublicVariable.IsLabkey_B = true;
            }
            if (item.displayName == "배터리")
            {
                OverallManager.Instance.PublicVariable.IsBattery = true;
            }
            UPdateUI();
            return;
        }

        Destroy(item); //꽉차면 없앰 꽉찼을때 팝업있으면 가능
    }

    void UPdateUI() // 아이템 슬롯 최신화 코드
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item != null)
                uiSlot[i].Set(slots[i]);
            else
                uiSlot[i].Clear();
        }
    }

    ItemSlot GetItemStack(ItemData item) //쌓일수있는 아이템
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

    public void SelectItem(int index) //골라진 아이템이
    {
        if (slots[index].item == null)
            return;

        selectedItem = slots[index];
        selectedItemIndex = index;

        selectedItemName.text = selectedItem.item.displayName;  // 골라진 아이템의 이름
        selectedItemDescription.text = selectedItem.item.description; //골라진 아이템의 설명

        selectedItemStatName.text = string.Empty;
        selectedItemStatValue.text = string.Empty;


         for(int i = 0; i < selectedItem.item.consumables.Length; i++) // 섭취 할떄
        {
            selectedItemStatName.text += selectedItem.item.consumables[i].type.ToString() + "\n";
            selectedItemStatValue.text += selectedItem.item.consumables[i].value.ToString() +"\n";
        }

        useButton.SetActive(selectedItem.item.type == ItemType.Consumable);  // 골라진 아이템의 속성이 "Consumable"이면 사용하기 버튼노출
        //equipButton.SetActive(selectedItem.item.type == ItemType.Equipable && !uiSlot[index].equipped); // 골라진 아이템의 속성이 "장비면"이면 사용하기 버튼노출
        //unEquipButton.SetActive(selectedItem.item.type == ItemType.Equipable && uiSlot[index].equipped); // 골라진 아이템의 속성이 "장비면"이면 사용하기 버튼노출

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
    public void useHangSengJe()
    {
        foreach(ItemSlot item in slots)
        {
            if (item.item.displayName == "항생제" && item.item != null)
            {
                item.quantity--;
                if (item.quantity <= 0)
                {
                    OverallManager.Instance.PublicVariable.IsGetAntibiotic = false;
                    item.item = null;
                    ClearSelectedItemWindow();
                }
                break;
            }
        }
        UPdateUI();
    }


    public void OnUseButton()  //사용하기 버튼
    {

        
        if(selectedItem.item.type == ItemType.Consumable) // 만약 아이템 속성이 "Consumable"이면  >> 사용하기 버튼이 노출은 위에.
        {
            
            for (int i = 0; i < selectedItem.item.consumables.Length; i++) // 섭취 할떄
            {
                switch(selectedItem.item.consumables[i].type) 
                {
                    
                    case ConsumableType.Hunger: // 현재 Hunger=아빠 Health = 레베카가있음

                        //_hpBar.value += 
                        OverallManager.Instance.PublicVariable.Fullness += selectedItem.item.consumables[i].value;
                        OverallManager.Instance.UiManager.textRenewal();

                        break;
                    //case ConsumableType.Health;
                    //    레베카의 hpslider.value;
                    //    break;
                }
            }
        }
        audioSource.PlayOneShot(eat);
        RemoveSelectedItem();
    }

    public void OnEquipButton() // 장비없어서 미작성
    {

    }

    void UnEquip(int index) // 장비없어서 미작성
    {

    }

    public void OnUnEquipButton() // 장비없어서 미작성
    {

    }

    public void RemoveSelectedItem() //아이템 소모시 사라지는 코드
    {
        selectedItem.quantity--;

        if (selectedItem.quantity <= 0)
        {
            if (uiSlot[selectedItemIndex].equipped)
            {
                UnEquip(selectedItemIndex);
            }
            if(selectedItem.item.displayName == "항생제")
            {
                OverallManager.Instance.PublicVariable.IsGetAntibiotic = false;
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
