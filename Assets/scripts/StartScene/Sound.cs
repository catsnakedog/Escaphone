using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public string soundName;

    void Start()
    {
        SoundManager.sound.Play(soundName);
    }
}
