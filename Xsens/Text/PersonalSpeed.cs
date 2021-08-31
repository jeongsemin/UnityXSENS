using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersonalSpeed : MonoBehaviour
{
    public Text Speed;

    ColorChange colorchange;
    // Start is called before the first frame update
    void Start()
    {
        colorchange = GameObject.Find("Barbell_personal_2").GetComponent<ColorChange>();

    }
    // Update is called once per frame
    void Update()
    {
        Speed.text = "���� �ӵ�(<color=red>K</color>, <color=blue>L</color>�� ����) : " + colorchange.speed;
    }
}
