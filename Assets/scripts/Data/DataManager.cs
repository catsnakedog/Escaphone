using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    JsonManager jsonManager; // json���� ���� �о���ų� �����ϴ� JsonManager
    public SaveDataClass saveData; // �����͸� �����ϴ� ������ SaveDataClass
    public static DataManager Single;

    public ResourceManager resource;

    void Awake()
    {
        if (Single == null) // DataManager�� ���ϼ� ����
        {
            Single = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
     
        jsonManager = new JsonManager();
        saveData = new SaveDataClass();
        resource = new ResourceManager();

        Load();
        resource.Init();
    }
    public void Save() // saveData�� ��ϵ� �����͵��� json�� �����Ѵ�
    {
        jsonManager.SaveJson(saveData);
    }

    public void Load() // json�� ��ϵ��ִ� �����͵��� saveData�� �����´�
    {
        saveData = jsonManager.LoadSaveData();
    }
}