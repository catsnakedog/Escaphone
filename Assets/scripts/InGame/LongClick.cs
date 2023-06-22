using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        }
    }

    void TimeCount()
    {
        count += Time.deltaTime;
        if(count >= 1f)
        {
            detail.SetActive(true);
            isLongClick = true;
        }
    }
}
