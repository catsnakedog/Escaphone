using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class Scrollcontroller : MonoBehaviour
{
    public Scrollbar SB;

    public void Awake()
    {
        SB = GetComponent<Scrollbar>();
        float SV = SB.value;
        EndDrag(SV);
    }
    public void EndDrag(float SV)
    {
        SV = (float)Math.Round(SV, 1);
        Debug.Log("HI " + SV);
        SB.value = SV;
    }
}