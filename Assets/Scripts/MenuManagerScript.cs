using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }



    public void SpieStartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void GameQuitButton()
    {
        Application.Quit();
    }
  
}
