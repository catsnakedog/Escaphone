using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBackFront : MonoBehaviour
{
    bool isFront;
    [SerializeField]
    GameObject front;
    [SerializeField]
    GameObject back;

    private void Start()
    {
        isFront = true;
    }
    public void Convert()
    {
        if(isFront)
        {
            front.SetActive(false);
            back.SetActive(true);
            isFront = false;
        }
        else
        {
            front.SetActive(true);
            back.SetActive(false);
            isFront = true;
        }
    }
}
