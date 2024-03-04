using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ItemCreator : MonoBehaviour
{
    [SerializeField]
    private GameObject Item;

    [SerializeField]
    private Transform Transform;

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
                Instantiate(Item,Transform);
            }
        }
        else if(ItemSrc.item.displayName == "미완성 백신 A")
        {
            if (OverallManager.Instance.PublicVariable.IsDetoA == true)
            {

            }
            else
            {
                Instantiate(Item, Transform);
            }
        }
        else if (ItemSrc.item.displayName == "미완성 백신 B")
        {
            if (OverallManager.Instance.PublicVariable.IsDetoB == true)
            {

            }
            else
            {
                Instantiate(Item, Transform);
            }
        }
        else if( ItemSrc.item.displayName == "미완성 백신 C")
        {
            if (OverallManager.Instance.PublicVariable.IsDetoC == true)
            {

            }
            else
            {
                Instantiate(Item, Transform);
            }
        }
        else if(ItemSrc.item.displayName == "배터리")
        {

        }
        else if(ItemSrc.item.displayName == "연구소 내부 카드키")
        {
            if (OverallManager.Instance.PublicVariable.IsLabkey_B == true)
            {

            }
            else
            {
                Instantiate(Item, Transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
