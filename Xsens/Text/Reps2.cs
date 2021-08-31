using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reps2 : MonoBehaviour
{
    public Text trainer;

    reader Reps;
    // Start is called before the first frame update
    void Start()
    {
        Reps = GameObject.Find("Barbell_teacher").GetComponent<reader>();
    }

    // Update is called once per frame
    void Update()
    {
        trainer.text = "트레이너 : " + Reps.x;
    }
}
