using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float LimitTime=0;
    public Text text_Timer;
    

    // Update is called once per frame
    void Update()
    {
        LimitTime += Time.deltaTime;
        text_Timer.text = "Time : " + Mathf.Round(LimitTime);
    }
}
