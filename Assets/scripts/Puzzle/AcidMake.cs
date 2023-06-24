using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class AcidMake : MonoBehaviour
{
    [SerializeField]
    GameObject A;
    string As;
    [SerializeField]
    GameObject B;
    string Bs;
    [SerializeField]
    GameObject C;
    string Cs;
    [SerializeField]
    GameObject correct;
    [SerializeField]
    GameObject wrong;

    [SerializeField]
    List<string> answer;

    bool isActive;

    void Start()
    {
        isActive = true;
    }

    public void SetPotionA()
    {
        if (!isActive) return;
        string[] tempString = {"potion1", "potion2", "potion3"};
        if(!tempString.Contains(DataManager.Single.saveData.inGameData.usingItem)) return;
        A.GetComponent<Image>().sprite = DataManager.Single.resource.itemSprite[DataManager.Single.saveData.inGameData.usingItem];
        As = DataManager.Single.saveData.inGameData.usingItem;
    }
    public void SetPotionB()
    {
        if (!isActive) return;
        string[] tempString = { "potion1", "potion2", "potion3" };
        if (!tempString.Contains(DataManager.Single.saveData.inGameData.usingItem)) return;
        B.GetComponent<Image>().sprite = DataManager.Single.resource.itemSprite[DataManager.Single.saveData.inGameData.usingItem];
        Bs = DataManager.Single.saveData.inGameData.usingItem;
    }
    public void SetPotionC()
    {
        if (!isActive) return;
        string[] tempString = { "potion1", "potion2", "potion3" };
        if (!tempString.Contains(DataManager.Single.saveData.inGameData.usingItem)) return;
        C.GetComponent<Image>().sprite = DataManager.Single.resource.itemSprite[DataManager.Single.saveData.inGameData.usingItem];
        Cs = DataManager.Single.saveData.inGameData.usingItem;
    }

    public void Make()
    {
        if (DataManager.Single.saveData.inGameData.usingItem != "powder") return;
        string[] tempString = { "potion1", "potion2", "potion3" };
        if (!isActive) return;
        if (!tempString.Contains(As)) return;
        if (!tempString.Contains(Bs)) return;
        if (!tempString.Contains(Cs)) return;
        if (((answer[0] == As) && (answer[1] == Bs)) && (answer[2] == Cs))
        {
            isActive = false;
            correct.SetActive(true);
        }
        else
        {
            StartCoroutine(Wrong());
        }
    }

    IEnumerator Wrong()
    {
        wrong.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        wrong.SetActive(false);
    }
}