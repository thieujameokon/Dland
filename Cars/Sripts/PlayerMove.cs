using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    // 0: Punch
    // 1: Cut
    // 2: Leaf
    public GameObject BlueCar;
    public GameObject OrangeCar;
    // variable of sprites car
    public static int priorityofBlue;
    public static int priorityofOrange;
    private int[] priority1 = { 0, 1, 2 };
    private int[] priority2 = { 2, 0, 1 };
     bool Change;
    public float t;
    void Start()
    {
        priorityofBlue = priority1[Random.Range(0, priority1.Length)];
        priorityofOrange = priority2[Random.Range(0, priority2.Length)];
        Change = false;
        Time.timeScale = 1.3f;
        t = Time.timeScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.IsGameOver == false)
        {
            //if Blue car is at left move it to right and if its right moves it to left.
            if (GameController.BlueAtLeft)
            {
                BlueCar.transform.position = Vector3.Lerp(BlueCar.transform.position, new Vector3(-0.75f, -3.7f, 0), 0.1f);
            }
            else
            {
                BlueCar.transform.position = Vector3.Lerp(BlueCar.transform.position, new Vector3(-2.25f, -3.7f, 0), 0.1f);
            }
            //if Orange car is at left move it to right and if its right moves it to left.
            if (GameController.OrangeAtLeft)
            {
                OrangeCar.transform.position = Vector3.Lerp(OrangeCar.transform.position, new Vector3(2.25f, -3.7f, 0), 0.1f);
            }
            else
            {
                OrangeCar.transform.position = Vector3.Lerp(OrangeCar.transform.position, new Vector3(0.75f, -3.7f, 0), 0.1f);
            }
        }
        if(GameController.score % 10==0 && Change && GameController.score !=0)
        {
            priorityofBlue = priority1[Random.Range(0, priority1.Length)];
            priorityofOrange = priority2[Random.Range(0, priority2.Length)];
            Change = false;
            t = t + 0.3f;
            Time.timeScale = t;
        }
        if (GameController.score % 10 == 1)
        {
            Change = true;
        }
    }
}
