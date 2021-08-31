using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Status : MonoBehaviour
{
    public Text Times;
    string[] number = { "GOOD",
        "왼손이 앞서있습니다.",
        "오른손이 앞서있습니다.",
        "",
        "왼손이 더 높습니다.",
        "왼손이 더 높고 앞서있습니다.",
        "오른손이 더 높고 앞서있습니다.",
        "",
        "오른손이 더 높습니다.",
        "왼손이 앞서있고 오른손이 더 높습니다.",
        "왼손이 더 높고 오른손이 앞서있습니다."};

    ColorChange colorchange;
    // Start is called before the first frame update
    void Start()
    {
        colorchange = GameObject.Find("Barbell_personal_2").GetComponent<ColorChange>();
    }
    // Update is called once per frame
    void Update()
    {
        if (colorchange.takestatus == 0)
        {
            Times.text = number[0];
        }
        else if(colorchange.takestatus == 1)
        {
            Times.text = number[1];
        }
        else if (colorchange.takestatus == 2)
        {
            Times.text = number[2];
        }
        else if (colorchange.takestatus == 4)
        {
            Times.text = number[4];
        }
        else if (colorchange.takestatus == 5)
        {
            Times.text = number[5];
        }
        else if (colorchange.takestatus == 6)
        {
            Times.text = number[6];
        }
        else if (colorchange.takestatus == 8)
        {
            Times.text = number[8];
        }
        else if (colorchange.takestatus == 9)
        {
            Times.text = number[9];
        }
        else if (colorchange.takestatus == 10)
        {
            Times.text = number[10];
        }
        else
        {
            Times.text = " ";
        }
    }
}
