using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class Password : MonoBehaviour
{
    [SerializeField]
    GameObject obj;
    [SerializeField]
    int type;
    Text passwordText;
    public List<int> correctPassword = new List<int>();
    public List<int> inputPassword = new List<int>();
    int passwordCount;
    int cnt;

    void Start()
    {
        inputPassword.Clear();    
        passwordCount = correctPassword.Count;
        passwordText = gameObject.transform.GetChild(0).GetChild(0).GetComponent<Text>();
        passwordText.text = "";
        cnt = 0;
    }

    public void InputPassword(int n)
    {
        cnt++;
        inputPassword.Add(n);
        if(cnt == passwordCount)
        {
            IsPasswordCorrect();
        }
        else
        {
            passwordText.text = passwordText.text + n.ToString();
        }
    }

    void IsPasswordCorrect()
    {
        bool isCorrect = true;
        for(int i=0;i<passwordCount;i++)
        {
            if (correctPassword[i] != inputPassword[i])
            {
                isCorrect = false;
            }
        }
        if(isCorrect)
        {
            passwordText.text = "CORRECT";
            Debug.Log("clear");
            Invoke("objEffect" + type, 0f);
        }
        else
        {
            passwordText.text = "WRONG";
            Invoke("passwordReset", 1f);
        }
    }

    void passwordReset()
    {
        inputPassword.Clear();
        cnt = 0;
        passwordText.text = "";
    }

    void objEffect1()
    {
        obj.SetActive(true);
    }
}
