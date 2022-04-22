using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
       if(Input.GetKeyDown(KeyCode.Space) || ball.transform.position.y < -20)
       {
           CountPinDown();
           turnCounter++;
           ResetPins();

           if(turnCounter == 10)
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

        if(score > highScore.highscore)
        {
            highScore.highscore = score;
        }

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
