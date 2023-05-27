using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotPaint : MonoBehaviour
{
    List<GameObject> dotList = new List<GameObject>();
    List<bool> isDotList = new List<bool>();
    GameObject dots;
    LineRenderer lineRenderer;

    int cnt = 0;

    void Start()
    {
        cnt = 0;
        dots = gameObject.transform.GetChild(0).gameObject;
        lineRenderer = gameObject.GetComponent<LineRenderer>();

        Transform[] transforms = dots.GetComponentsInChildren<Transform>();
        for(int i=0;i<transforms.Length;i++)
        {
            if (transforms[i] != dots.transform)
            {
                dotList.Add(transforms[i].gameObject);
                isDotList.Add(true);
            }
        }
        lineRenderer.positionCount = 0;
        lineRenderer.startColor = Color.green;
        lineRenderer.endColor = Color.green;
    }
    public void DotSetting(int n)
    {
        if (isDotList[n])
        {
            isDotList[n] = false;
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(cnt, new Vector3(dotList[n].transform.position.x, dotList[n].transform.position.y, 0f));
            cnt++;
            if (cnt == dotList.Count)
            {
                // 클리어시 행동 여기다가 추가
                Debug.Log("clear");
            }
        }
        else
        {
            DotReSet();
        }
    }

    public void DotReSet()
    {
        cnt = 0;
        lineRenderer.positionCount = 0;
        for(int i=0;i<isDotList.Count;i++)
        {
            isDotList[i] = true;
        }
    }
}
