using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{
    enum ItemList
    {
        test1,
        test2,
        test3,
        memo4_1,
        memo4_2,
        memo4_3,
        memo4_4,
        key,
        cable,
        card,
        hammer,
        powder,
        potion1,
        potion2,
        potion3,
        acid,
    }
    
    public Dictionary<string, Sprite> itemSprite;

    public void Init()
    {
        itemSprite = new Dictionary<string, Sprite>();
        GetAllItemData();
    }

    void GetAllItemData()
    {
        string[] ItemNames = System.Enum.GetNames(typeof(ItemList));
        for (int i = 0; i < ItemNames.Length; i++)
        {
            itemSprite.Add(ItemNames[i], Resources.Load<Sprite>("Item/" + ItemNames[i]));
        }
    }
}
