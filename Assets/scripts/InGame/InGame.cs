using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.TerrainAPI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InGame : MonoBehaviour
{
    DataManager Single;

    GameObject BG;
    GameObject option;
    GameObject changeView;
    GameObject inventoryBT;
    GameObject inventory;
    GameObject sound;
    GameObject detail;

    [SerializeField] private List<GameObject> itemObject;

    bool isInventory;

    void Start()
    {
        Single = DataManager.Single;
        BG = transform.GetChild(0).gameObject;
        inventoryBT = transform.GetChild(2).gameObject;
        inventory = transform.GetChild(3).gameObject;
        detail = transform.GetChild(4).gameObject;
        option = transform.GetChild(5).gameObject;
        changeView = transform.GetChild(6).gameObject;
        itemObject = new List<GameObject>();

        List<string> temp = new List<string>();
        Transform[] transforms = inventory.transform.GetChild(0).GetChild(0).GetComponentsInChildren<Transform>();
        foreach(Transform transform in transforms)
        {
            if(transform.name != inventory.transform.GetChild(0).GetChild(0).name && !temp.Contains(transform.name))
            {
                itemObject.Add(transform.gameObject);
                temp.Add(transform.name);
                transform.GetChild(0).GetComponent<LongClick>().number = int.Parse(transform.name);
                transform.GetChild(0).GetComponent<LongClick>().detail = detail;
            }
        }

        option.GetComponent<Button>().onClick.AddListener(Option);
        changeView.GetComponent<Button>().onClick.AddListener(ChangeView);
        inventoryBT.GetComponent<Button>().onClick.AddListener(Inventory);

        Invoke("SoundSetting", 0.5f);
    }

    void SoundSetting()
    {
        sound = GameObject.FindWithTag("Sound").transform.GetChild(0).gameObject;
    }

    void Option()
    {
        sound.SetActive(true);
    }

    void ChangeView()
    {
        // 화면 변경 관련
    }

    void Inventory()
    {
        if(!isInventory)
        {
            UISetting();
            isInventory = true;
            inventory.SetActive(true);
            inventoryBT.GetComponent<RectTransform>().localPosition = new Vector3(0f, -100f, 0f);
        }
        else
        {
            UISetting();
            isInventory = false;
            inventory.SetActive(false);
            inventoryBT.GetComponent<RectTransform>().localPosition = new Vector3(0f, -1000f, 0f);
        }
    }

    public void UISetting()
    {
        int cnt = 0;
        foreach(string item in Single.saveData.inGameData.itemList)
        {
            itemObject[cnt].transform.GetChild(0).GetComponent<Image>().sprite = Single.resource.itemSprite[item];
            cnt++;
        }
    }
}
