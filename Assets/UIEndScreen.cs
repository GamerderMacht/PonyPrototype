using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIEndScreen : MonoBehaviour
{
    public GameObject gameLostScreen;





    public void GameLost()
    {
        gameLostScreen.SetActive(true);
    }


    public void ButtonRestart()
    {
        gameLostScreen.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ButtonQuit()
    {
        Application.Quit();
    }
}
