using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectDetail : MonoBehaviour
{
    [SerializeField]
    GameObject obj;
    public void SeeDetail()
    {
        obj.transform.GetChild(1).GetComponent<Image>().sprite = gameObject.GetComponent<Image>().sprite;
        obj.SetActive(true);
    }
}
