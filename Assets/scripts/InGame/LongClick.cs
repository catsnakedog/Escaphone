using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LongClick : MonoBehaviour
{
    DataManager Single;

    Action timeCount;

    public GameObject detail;

    public int number;
    float count;
    bool isLongClick;

    void Start()
    {
        Single = DataManager.Single;
    }

    void Update()
    {
        timeCount?.Invoke();
    }

    public void ButtonDown()
    {
        timeCount = null;
        isLongClick = false;
        count = 0;
        timeCount += TimeCount;
    }

    public void ButtonUp()
    {
        timeCount = null;
        if (Single.saveData.inGameData.itemList.Count < number)
        {
            return;
        }
        if (isLongClick)
        {
            return;
        }
        else
        {
            Single.saveData.inGameData.usingItem = Single.saveData.inGameData.itemList[number-1];
            GameObject.FindWithTag("InventoryBT").transform.GetChild(0).GetComponent<Image>().sprite = Single.resource.itemSprite[Single.saveData.inGameData.usingItem];
        }
    }

    void TimeCount()
    {
        count += Time.deltaTime;
        if(count >= 1f)
        {
            detail.transform.GetChild(1).GetComponent<Image>().sprite = Single.resource.itemSprite[Single.saveData.inGameData.itemList[number - 1]];
            detail.SetActive(true);
            isLongClick = true;
        }
    }
}
