using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ColorChange : MonoBehaviour
{
    Renderer Barbell_personal;
    int size;                                       //데이터 크기
    public int count = 0;                           //데이터 출력
    public int taketime = 0;   
    public float speed = 1.0f;                             //스피드
    public int takestatus;
    List<float> bar_rightPosition = new List<float>();      //바 R Position
    List<float> bar_leftPosition = new List<float>();       //바 L Position
    public List<int> status = new List<int>();
    List<float> bar_rightfront = new List<float>();         //바 R z
    List<float> bar_leftfront = new List<float>();          //바 L z
    List<int> Reps = new List<int>();               //Reps 수
    float barLPXM;
    float barLPXm;
    float barRPXM;
    float barRPXm;
    float barLPZM;
    float barLPZm;
    float barRPZM;
    float barRPZm;
    public float barPXM;
    public float barPXm;
    public float barPZM;
    public float barPZm;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Barbell_personal = gameObject.GetComponent<Renderer>();      

        List<Dictionary<string, object>> data_Dialog = CSVReader.Read("PersonalData10");

        size = data_Dialog.Count;

        for (int i = 0; i < data_Dialog.Count; i++)
        {
            bar_rightPosition.Add(float.Parse(data_Dialog[i]["R_Position_X"].ToString()));
            bar_leftPosition.Add(float.Parse(data_Dialog[i]["L_Position_X"].ToString()));

            bar_rightfront.Add(float.Parse(data_Dialog[i]["R_Position_Z"].ToString()));
            bar_leftfront.Add(float.Parse(data_Dialog[i]["L_Position_Z"].ToString()));

            status.Add(int.Parse(data_Dialog[i]["Status"].ToString()));

            Reps.Add(int.Parse(data_Dialog[i]["Reps"].ToString()));
        }
        barLPXM = bar_leftPosition.Max();
        barLPXm = bar_leftPosition.Min();
        barRPXM = bar_rightPosition.Max();
        barRPXm = bar_rightPosition.Min();

        barLPZM = bar_leftfront.Max();
        barLPZm = bar_leftfront.Min();
        barRPZM = bar_rightfront.Max();
        barRPZm = bar_rightfront.Min();

        barPXM = Mathf.Max(barLPXM, barRPXM);
        barPXm = Mathf.Min(barLPXm, barLPXm);

        barPZM = Mathf.Max(barLPZM, barRPZM);
        barPZm = Mathf.Min(barLPZm, barRPZm);

        int scaley = 10;
        int scalez = 10;

        //바벨 움직이는 범위 지정
        for(int i=0;i<data_Dialog.Count;i++)
        {
            bar_rightPosition[i] = scalez * (bar_rightPosition[i] - barPXm) / (barPXM - barPXm);
            bar_leftPosition[i] = scalez * (bar_leftPosition[i] - barPXm) / (barPXM - barPXm);
            bar_leftfront[i] = scaley * (bar_leftfront[i] - barPZm) / (barPZM - barPZm);
            bar_rightfront[i] = scaley * (bar_rightfront[i] - barPZm) / (barPZM - barPZm);
        }

        transform.position = new Vector3(-20, 12, -4);
    }


    // Update is called once per frame
    void Update()
    {
        taketime = Reps[count];
        takestatus = status[count];
        //바벨 다음 위치 지정
        Vector3 target = new Vector3(-20, (bar_leftfront[count] + bar_rightfront[count]) / 2 + 12.0f, 
            (bar_rightPosition[count] + bar_leftPosition[count])/2 - 4.0f);

        //이동
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position == target)
        {
            count++;
        }
        //마지막까지 가면 다시 돌아감
        if (count == size)
        {
            count = 0;
        }

        Mouse();
        ChangeSpeed();
        /*Checklean();*/
    }



    void ChangeSpeed()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            speed += 1.0f;
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            speed -= 1.0f;
        }
    }
    void Mouse()
    {
        if(Input.GetMouseButtonDown(1))
        {
            Cursor.visible = true;
        }
        if(Input.GetMouseButtonDown(0))
        {
            Cursor.visible = false;
        }
    }
}



/// start
/*for (int i = 0; i < data_Dialog.Count; i++)
{
    if (bar_rightfront[i] > barHeight && bar_leftfront[i] > barHeight)
    {
        barHeight = bar_front[i];
    }
    if(bar_front[i] < barLow)
    {
        barLow = bar_front[i];
    }
    if(bar_rightfront)
}*/


///Update
/* print(barHeight);

  Vector3 target = new Vector3(-20, barposition[count], 0);
  *//*Vector3 target = new Vector3(-20, 12, 0);*//*

  transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

  if (transform.position == target)
  {
      count = (++count) % 2;
      if(count == 1)
      {
          taketime++;
      }
  }*/
/*//다음 위치에 도착하면 다음 위치로 이동함
if (transform.position == target)
{
    count++;
}
//마지막까지 가면 다시 돌아감
else if (count == size - 3)
{
    count = 0;
}*/
/*print(transform.position);*/

/*print(Reps[count]);*/


/*void Checklean()
{
    if (Reps[count] > 0)
    {
        //바가 왼쪽으로 기울었다.
        if ((bar_leftPosition[count] - bar_rightPosition[count]) > 2.0f)
        {
            Barbell_personal.material.color = Color.blue;
        }
        //바가 오른쪽으로 기울었다.
        else if ((bar_leftPosition[count] - bar_rightPosition[count]) < -2.0f)
        {
            Barbell_personal.material.color = Color.red;
        }
        //나머지
        else
        {
            Barbell_personal.material.color = Color.green;
        }
    }
}*/