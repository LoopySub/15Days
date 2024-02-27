using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


//������ ���Կ� ��ũ��Ʈ �߰� �Ϸ� / �ƿ����β��л���
public class ItemSlotUI : MonoBehaviour
{
    public Button button;              //����/����/����ϱ� ��ư
    public Image icon;
    public TextMeshProUGUI quatityText; //���ð����� ������ ����
    private ItemSlot curSlot;
    private Outline outline;

    public int index;
    public bool equipped;

    private void Awake()
    {
        outline = GetComponent<Outline>();
    }

    private void OnEnable()
    {
        outline.enabled = equipped;
    }

    public void Set(ItemSlot slot)
    {
        curSlot = slot;
        icon.gameObject.SetActive(true);
        icon.sprite = slot.item.icon;
        quatityText.text = slot.quantity > 1 ? slot.quantity.ToString() : string.Empty;

        if (outline != null)
        {
            outline.enabled = equipped;
        }
    }

    public void Clear()
    {
        curSlot = null;
        icon.gameObject.SetActive(false);
        quatityText.text = string.Empty;
    }

    public void OnButtonClick()
    {
        //Inventory.instance.SelectItem(index);
    }
}
