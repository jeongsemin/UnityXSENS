using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraSpeed : MonoBehaviour
{
    // Start is called before the first frame update
    public Text Speed;

    Axis colorchange;
    // Start is called before the first frame update
    void Start()
    {
        colorchange = GameObject.Find("Main Camera").GetComponent<Axis>();
    }
    // Update is called once per frame
    void Update()
    {
        Speed.text = "ī�޶� �ӵ�(<color=red>N</color>, <color=blue>M</color>�� ����) : " + colorchange.moveSpeed;
    }
}
