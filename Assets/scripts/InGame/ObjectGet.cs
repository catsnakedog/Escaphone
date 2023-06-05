using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGet : MonoBehaviour
{
    DataManager Single;

    public string name;
    bool isActive;

    void Start()
    {
        Single = DataManager.Single;
    }
    public void Get()
    {
        if(isActive)
        {
            return;
        }
        Single.saveData.inGameData.itemList.Add(name);
        isActive = false;
    }
}
