using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ItemCreator : MonoBehaviour
{
    [SerializeField]
    private GameObject Item;

    void Start()
    {
        ItemObject ItemSrc = Item.GetComponent<ItemObject>();
        if(ItemSrc.item.displayName == "������ ���� ī��Ű") 
        { 
            if(OverallManager.Instance.PublicVariable.IsLabMainKeyGet == true)
            {

            }
            else
            {
                Instantiate(Item);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
