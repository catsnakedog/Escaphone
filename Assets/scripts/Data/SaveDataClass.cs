using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class SaveDataClass
{
    public InGameData inGameData;
    public SaveDataClass(InGameData inGameData)
    {
        this.inGameData = inGameData;
    }
    public SaveDataClass()
    {
        inGameData = new InGameData();
    }
}

[System.Serializable]
public class InGameData
{
    public List<string> itemList;
    public string usingItem;

    public InGameData(List<string> itemList, string usingItem)
    {
        this.itemList = itemList;
        this.usingItem = usingItem;
    }

    public InGameData()
    {
        this.itemList = new List<string>();
        usingItem = "";
    }
}