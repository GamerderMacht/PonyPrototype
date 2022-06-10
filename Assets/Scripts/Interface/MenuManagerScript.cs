using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class MenuManagerScript : MonoBehaviour
{
   public GameObject mainMenu;
   public GameObject optionsMenu;
   public GameObject creditsAndScoreMenu;
   public GameObject howToPlayMenu;
   public GameObject pauseMenu;

   //Audio
   public AudioSource audioSource;
   public AudioClip audioClip;



    void Update()
    {
        
    }

    void PauseMenu()
    {
        
    }
    //MAIN MENU
    public void SpieStartButton()
    {

        SceneManager.LoadScene("MainGame",LoadSceneMode.Single);
    }
    public void OptionsButton()
    {
        audioSource.PlayOneShot(audioClip);
        if(SceneManager.GetActiveScene().buildIndex == 0) //Wenn man im Menu ist
        {
            OpenMenu(mainMenu, optionsMenu);
        }
        else    //Wenn man im Game ist
        {
            OpenMenu(pauseMenu, optionsMenu);
        }
        
    }
    public void HowtoPlayButton()
    {
        audioSource.PlayOneShot(audioClip);
        if(SceneManager.GetActiveScene().buildIndex == 0) //Wenn man im Menu ist
        {
            OpenMenu(mainMenu, howToPlayMenu);
        }
        else    //Wenn man im Game ist
        {
            OpenMenu(pauseMenu, howToPlayMenu);
        }
        
        
    }
    public void Credits()
    {
        audioSource.PlayOneShot(audioClip);
        if(SceneManager.GetActiveScene().buildIndex == 0) //Wenn man im Menu ist
        {
            OpenMenu(mainMenu, creditsAndScoreMenu);
        }
        else    //Wenn man im Game ist
        {
            OpenMenu(pauseMenu, creditsAndScoreMenu);
        }
        
    }

    void OpenMenu(GameObject menuOut, GameObject menuIn)
    {
        //menuOut Canvas Out
        var menuOutCanvasGroup = menuOut.GetComponent<CanvasGroup>();
        menuOutCanvasGroup.alpha = 0;
        menuOutCanvasGroup.interactable = false;
        menuOutCanvasGroup.blocksRaycasts = false;


        //menuIn Canvas On
        var menuInCanvasGroup = menuIn.GetComponent<CanvasGroup>();
        menuInCanvasGroup.alpha = 1;
        menuInCanvasGroup.interactable = true;
        menuInCanvasGroup.blocksRaycasts = true;
    }

    public void GameQuitButton()
    {
        Application.Quit();
    }


    //Options Menu Buttons
    
    public void OptionBackButton()
    {
        audioSource.PlayOneShot(audioClip);
        if(SceneManager.GetActiveScene().buildIndex == 0) //Wenn man im Menu ist
        {
            OpenMenu(optionsMenu, mainMenu);
        }
        else    //Wenn man im Game ist
        {
            OpenMenu(optionsMenu, pauseMenu);
        }
        
    }

    //HowtoPlay Buttons

    public void HowtoPlayBackButton()
    {
        audioSource.PlayOneShot(audioClip);
        if(SceneManager.GetActiveScene().buildIndex == 0) //Wenn man im Menu ist
        {
            OpenMenu(howToPlayMenu, mainMenu);
        }
        else    //Wenn man im Game ist
        {
            OpenMenu(howToPlayMenu, pauseMenu);
        }
        
    }

    //Credits Buttons
    public void CreditsBackButton()
    {
        audioSource.PlayOneShot(audioClip);
        if(SceneManager.GetActiveScene().buildIndex == 0) //Wenn man im Menu ist
        {
            OpenMenu(creditsAndScoreMenu, mainMenu);
        }
        else    //Wenn man im Game ist
        {
            OpenMenu(creditsAndScoreMenu, pauseMenu);
        }
        
    }



    


    
    
  
}
