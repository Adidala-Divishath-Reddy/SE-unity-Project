using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public HighScore highScore;
    public Text highScoreValue;
    public Text Last10;
    public GameObject highScoreMenu;
   public void StartGame() 
   {
       SceneManager.LoadScene("Game");
       //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   }
   public void QuitGame()
   {
       Application.Quit();
   }
   public void ShowHighScore()
   {
      highScoreMenu.SetActive(true);
       highScoreValue.text = highScore.highscore.ToString();
       Last10.text = highScore.last10scores.ToString();
       Debug.Log(highScore.last10scores);
   }
    public void CloseHighScore()
   {
       highScoreMenu.SetActive(false);
   }
   public void ResetHighScore()
   {
       highScore.highscore = 0;
       highScoreValue.text = highScore.highscore.ToString();
   }


}
