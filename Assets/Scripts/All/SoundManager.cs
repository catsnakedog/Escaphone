using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.CodeDom.Compiler;
using System;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static SoundManager sound;

    AudioClip[] BGMs = new AudioClip[(int)BGM.MaxCount];
    AudioClip[] SFXs = new AudioClip[(int)SFX.MaxCount];

    HashSet<string> SFXNames = new HashSet<string>();
    HashSet<string> BGMNames = new HashSet<string>();

    AudioSource BGMSource;
    AudioSource SFXSource;

    public Slider BGMSlider;
    public Slider SFXSlider;

    float BGMVolume = 0.5f;
    float SFXVolume = 0.5f;

    GameObject optionCanvas;

    enum BGM
    {
        Ȩȭ��,
        MaxCount
    }

    enum SFX
    {
        MaxCount
    }

    void Awake()
    {
        if (sound == null)
        {
            sound = this;
            OptionSetting();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        SoundPooling(); // ���� ���ϵ��� Ǯ�� �ؿ´�
        SetAudioSource(); // ����� �ҽ� ����
        Play("Ȩȭ��");
    }

    void OptionSetting()
    {
        GameObject optionCanvas = Resources.Load<GameObject>("Prefabs/OptionCanvas"); // �ɼ� ������ �ҷ�����
        this.optionCanvas = Instantiate(optionCanvas);
        optionCanvas.GetComponent<Canvas>().worldCamera = GameObject.Find("Main Camera").GetComponent<Camera>(); // �ɼ� �˹����� ī�޶� ����
        BGMSlider = this.optionCanvas.transform.GetChild(2).GetComponent<Slider>();
        SFXSlider = this.optionCanvas.transform.GetChild(3).GetComponent<Slider>();
        // ���̽����� ����� BGM, SFX ���� �о���� �ڵ� �߰� �ʿ�
        BGMSlider.value = BGMVolume;
        SFXSlider.value = SFXVolume;
        BGMSlider.onValueChanged.AddListener(ChangeBGMValue);
        SFXSlider.onValueChanged.AddListener(ChangeSFXValue);
        this.optionCanvas.transform.SetParent(gameObject.transform);
    }

    void ChangeBGMValue(float value)
    {
        BGMVolume = value;
        BGMSource.volume = BGMVolume;
    }

    void ChangeSFXValue(float value)
    {
        SFXVolume = value;
        SFXSource.volume = SFXVolume;
    }

    void SoundPooling() // enum���� ���� �̸��� �о�ͼ� �ش��ϴ� ���� ������ �ε� ��Ų��
    {
        string[] BGMNames = System.Enum.GetNames(typeof(BGM));
        string[] SFXNames = System.Enum.GetNames(typeof(SFX));
        for (int i = 0; i < BGMNames.Length - 1; i++)
        {
            BGMs[i] = Resources.Load<AudioClip>("sound/BGM/" + BGMNames[i]);
            this.BGMNames.Add(BGMNames[i]);
        }
        for (int i = 0; i < SFXNames.Length - 1; i++)
        {
            SFXs[i] = Resources.Load<AudioClip>("sound/SFX/" + SFXNames[i]);
            this.SFXNames.Add(SFXNames[i]);
        }
    }

    void SetAudioSource() // ������ҽ��� �Ҵ��Ѵ�
    {
        AudioSource[] temp;
        temp = gameObject.GetComponents<AudioSource>();
        BGMSource = temp[0];
        SFXSource = temp[1];
        BGMSource.loop = true;
        BGMSource.volume = BGMVolume;
        SFXSource.volume = SFXVolume;
    }

    public void Play(string soundName, float pitch = 1.0f) // ���޹��� soundName�� ã�Ƽ� �����Ų��
    {
        if (BGMNames.Contains(soundName))
        {
            if (BGMSource.isPlaying)
            {
                BGMSource.Stop();
            }
            BGMSource.pitch = pitch;
            BGMSource.clip = BGMs[(int)((BGM)Enum.Parse(typeof(BGM), soundName))];
            BGMSource.Play();
        }
        else if (SFXNames.Contains(soundName))
        {
            SFXSource.pitch = pitch;
            SFXSource.PlayOneShot(SFXs[(int)((SFX)Enum.Parse(typeof(SFX), soundName))]);
        }
        else
        {
            Debug.Log("�ش� ����� �������� �ʽ��ϴ�");
        }
    }
}
