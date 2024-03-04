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
        if(ItemSrc.item.displayName == "연구소 출입 카드키") 
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
