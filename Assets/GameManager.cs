using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    public GameObject ball;
    int score =0 ;
    int turnCounter = 0;
    
    GameObject[] pins;
    public Text ScoreUI;
    Vector3[] positions;
    public HighScore highScore;
    public GameObject menu;
    HelloWorld obj=new HelloWorld();
    // Start is called before the first frame update
    void Start()
    {
        pins = GameObject.FindGameObjectsWithTag("Pin");
        positions = new Vector3[pins.Length];

        for(int i = 0; i < pins.Length; i++)
        {
            positions[i] = pins[i].transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
       MoveBall();
       if(ball.transform.position.y < -20)
       {
           CountPinDown();
           turnCounter++;
           ResetPins();

           if(turnCounter == 1)
           {
               menu.SetActive(true);
           }
       }
    }

    void MoveBall()
    {
        Vector3 position = ball.transform.position;
        position += Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime ;
        position.x = Mathf.Clamp(position.x, -0.52f, 0.52f);
        ball.transform.position=position;
       // ball.transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime );
    }

    void CountPinDown()
    {
        for(int i = 0; i< pins.Length; i++)
        {
            if(pins[i].transform.eulerAngles.z > 5 &&  pins[i].transform.eulerAngles.z < 355 && pins[i].activeSelf)
            {
                score++;
                pins[i].SetActive(false);
            }
            
        }
        ScoreUI.text = score.ToString();

        // if(score > highScore.highscore)
        // {
        //     highScore.highscore = score;
        // }

        String history=obj.GetString("past");
        if(history.Length==0)
        obj.SetString("past",score+"");
        else
        obj.SetString("past",history+" "+score);
        highScore.highscore =obj.maximum();

        highScore.last10scores=obj.GetString("past");

        // obj.SetString("past","");


        Debug.Log(highScore.highscore);
    
    }
    void ResetPins()
    {
        for(int i = 0; i < pins.Length; i++)
        {
            pins[i].SetActive(true);
            pins[i].transform.position = positions[i];
            pins[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
            pins[i].GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            pins[i].transform.rotation = Quaternion.identity;
        }
        ball.transform.position = new Vector3(0, 0.08517202f, 0.3f);
        ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        ball.transform.rotation = Quaternion.identity;
    }
}

class HelloWorld {
  public int maximum() {

    
    String history=GetString("past");
    var arr=history.Split(new []{" "}, StringSplitOptions.None);
    // Debug.Log("Length of array ")
    if(arr.Length>=10){
    var arr2=history.Split(new []{" "},2, StringSplitOptions.None);
    history=arr2[1];
    }
    
   //  Debug.Log(history);
    
    SetString("past",history);
    int max=0;
    arr=history.Split(new []{" "}, StringSplitOptions.None);
    for(int i=0;i<arr.Length;i++)
    {
        if(Int16.Parse(arr[i])>max)
        max=Int16.Parse(arr[i]);
    }
    
   //  Debug.Log(max);
   return max;
  }
  
  public void SetString(string KeyName, string Value)
    {
        PlayerPrefs.SetString(KeyName, Value);
    }

    public string GetString(string KeyName)
    {
        return PlayerPrefs.GetString(KeyName);
    }
}

