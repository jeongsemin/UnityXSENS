using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class reader : MonoBehaviour
{
    public float speed = 1.0f;
    public int x = 0;
    bool IsPause;                                   //일시정지
    int size;                                       //데이터 크기
    int count = 0;                                  //데이터 출력
    List<float> listbar = new List<float>();        //바 높이
    List<float> listbarz = new List<float>();       //바 앞뒤 움직임
    float barHeight = 0f;                           //바 최고위치
    List<float> barposition = new List<float>();    //바 위치
    

    ColorChange colorchange;

    // Start is called before the first frame update
    void Start()
    {

        IsPause = true;
        Time.timeScale = 0;
        colorchange = GameObject.Find("Barbell_personal_2").GetComponent<ColorChange>();

        /*position = transform.position;*/

        List<Dictionary<string, object>> data_Dialog = CSVReader.Read("Z_1");

        size = data_Dialog.Count;

        for (int i = 0; i < data_Dialog.Count; i++)
        {
            listbar.Add(50 * float.Parse(data_Dialog[i]["Camera_S_X"].ToString()) + 12.0f);
            listbarz.Add(float.Parse(data_Dialog[i]["Camera_S_Z"].ToString()));          
        }

        

        for(int i=0;i<data_Dialog.Count;i++)
        {
            if(listbar[i] > barHeight)
            {
                barHeight = listbar[i];
            }
        }
        //바의 주기 지정

        //바의 위치 지정
        barposition.Add(21.5f);
        barposition.Add(12.0f);

        //맨처음 위치 지정
        transform.position = new Vector3(20, 12, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = new Vector3(20, barposition[count], 0);

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        //반복을하게되면 Reps + 1
        if (transform.position == target)
        {
            count = (++count) % 2;
            if(count == 0)
            {
                x += 1;
            }
        }

        ChangeSpeed();
        Exit();
        Pause();

        
    }
    void ChangeSpeed()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            speed += 1.0f;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            speed -= 1.0f;
        }
    }
    void Exit()
    {
        //ESC누를시 프로그램 종료
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    void Pause()
    {
        //spacebar 누를시 프로그램 일시정지
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //일시정지 활성화
            if (IsPause == false)
            {
                Time.timeScale = 0;
                IsPause = true;
                return;
            }

            //일시정지 비활성화
            if (IsPause == true)
            {
                Time.timeScale = 1;
                IsPause = false;
                return;
            }
        }
    }
}

//Update

/*if(transform.position == new Vector3(20,barHeight,0))
{
    target = new Vector3(20,12,0);
}*/
/*print(transform.position);*/
/*Vector3 target = new Vector3(20, listbar[count + 1], listbarz[count + 1]);

transform.position = Vector3.MoveTowards(transform.position, target, 1.0f * Time.deltaTime);

//다음 위치에 도착하면 다음 위치로 이동함
if(transform.position == target)
{
    count++;
}
//마지막까지 가면 다시 돌아감
else if(count == size-3)
{
    count = 0;
}*/

//현재 위치 출력
/*print(new Vector3(0, listbar[count + 1], listbarz[count + 1]));*/