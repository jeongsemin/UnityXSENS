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
        Speed.text = "개인 속도(<color=red>K</color>, <color=blue>L</color>로 조절) : " + colorchange.speed;
    }
}
