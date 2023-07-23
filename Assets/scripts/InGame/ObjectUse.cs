using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectUse : MonoBehaviour
{
    DataManager Single;
    [SerializeField]
    GameObject obj;
    public string condition;
    [SerializeField]
    int effectType;
    [SerializeField]
    GameObject secondObj;
    

    void Start()
    {
        Single = DataManager.Single;
        if(gameObject.GetComponent<Button>() == null)
        {
            gameObject.AddComponent<Button>().onClick.AddListener(Get);
        }
    }
    public void Get()
    {
        if (condition != "")
        {
            if (Single.saveData.inGameData.usingItem != condition)
            {
                return;
            }
        }

        Invoke("ObjEffect" + effectType, 0f);
        gameObject.SetActive(false);
    }

    void ObjEffect1()
    {
        obj.SetActive(false);
    }

    void ObjEffect2()
    {
        obj.SetActive(true);
    }

    void ObjEffect3()
    {
        obj.SetActive(true);
        secondObj.SetActive(true);
    }
}