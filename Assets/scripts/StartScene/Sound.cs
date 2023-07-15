using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    void Start()
    {
        SoundManager.sound.Play("mainSound");
    }
}
