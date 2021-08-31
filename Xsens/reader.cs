using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class reader : MonoBehaviour
{
    public float speed = 1.0f;
    public int x = 0;
    bool IsPause;                                   //�Ͻ�����
    int size;                                       //������ ũ��
    int count = 0;                                  //������ ���
    List<float> listbar = new List<float>();        //�� ����
    List<float> listbarz = new List<float>();       //�� �յ� ������
    float barHeight = 0f;                           //�� �ְ���ġ
    List<float> barposition = new List<float>();    //�� ��ġ
    

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
        //���� �ֱ� ����

        //���� ��ġ ����
        barposition.Add(21.5f);
        barposition.Add(12.0f);

        //��ó�� ��ġ ����
        transform.position = new Vector3(20, 12, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = new Vector3(20, barposition[count], 0);

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        //�ݺ����ϰԵǸ� Reps + 1
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
        //ESC������ ���α׷� ����
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    void Pause()
    {
        //spacebar ������ ���α׷� �Ͻ�����
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //�Ͻ����� Ȱ��ȭ
            if (IsPause == false)
            {
                Time.timeScale = 0;
                IsPause = true;
                return;
            }

            //�Ͻ����� ��Ȱ��ȭ
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

//���� ��ġ�� �����ϸ� ���� ��ġ�� �̵���
if(transform.position == target)
{
    count++;
}
//���������� ���� �ٽ� ���ư�
else if(count == size-3)
{
    count = 0;
}*/

//���� ��ġ ���
/*print(new Vector3(0, listbar[count + 1], listbarz[count + 1]));*/