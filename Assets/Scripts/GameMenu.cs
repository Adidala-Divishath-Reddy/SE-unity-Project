using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public GameObject menu;

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(menu.activeSelf)
            {
                menu.SetActive(false);
            }
            else
            {
                menu.SetActive(true);

            }
        }   
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager
        .GetActiveScene().buildIndex);
    }
    // Start is called before the first frame update
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
   
}
