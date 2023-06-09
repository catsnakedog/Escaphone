using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectGet : MonoBehaviour
{
    DataManager Single;

    public string name;
    public string condition;
    bool isActive;

    void Start()
    {
        Single = DataManager.Single;
        gameObject.AddComponent<Button>().onClick.AddListener(Get);
    }
    public void Get()
    {
        if(condition != "")
        {
            if (Single.saveData.inGameData.usingItem != condition)
            {
                return;
            }
        }

        if(name != "")
        {
            Single.saveData.inGameData.itemList.Add(name);
            GameObject.FindWithTag("InGame").GetComponent<InGame>().UISetting();
        }
        gameObject.SetActive(false);
    }
}
