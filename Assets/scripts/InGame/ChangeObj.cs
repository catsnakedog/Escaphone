using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeObj : MonoBehaviour
{
    [SerializeField]
    GameObject obj1;
    [SerializeField]
    GameObject obj2;

    public void Change()
    {
        obj1.SetActive(false);
        obj2.SetActive(true);
    }
}
