using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainerSpeed : MonoBehaviour
{
    // Start is called before the first frame update
    public Text Speed;

    reader colorchange;
    // Start is called before the first frame update
    void Start()
    {
        colorchange = GameObject.Find("Barbell_teacher").GetComponent<reader>();
    }
    // Update is called once per frame
    void Update()
    {
        Speed.text = "Ʈ���̳� �ӵ�(<color=red>O</color>, <color=blue>P</color>�� ����) : " + colorchange.speed;
    }
}
