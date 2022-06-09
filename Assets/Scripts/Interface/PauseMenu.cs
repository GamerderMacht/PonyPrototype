using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject PlayerHud;
    public GameObject wheelHud;
    public GameObject wheelLevel;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }


    public void Resume()
    {
        var pauseCanvasGroup = pauseMenuUI.GetComponent<CanvasGroup>();
        pauseCanvasGroup.alpha = 0;
        pauseCanvasGroup.interactable = false;
        pauseCanvasGroup.blocksRaycasts = false;

        //enable Player HUD
        var PlayerHudCanvasGroup = PlayerHud.GetComponent<CanvasGroup>();
        PlayerHudCanvasGroup.alpha = 1;
        PlayerHudCanvasGroup.interactable = true;
        PlayerHudCanvasGroup.blocksRaycasts = true;

        Time.timeScale = 1f;
        GameIsPaused = false;
        wheelHud.SetActive(true);
        wheelLevel.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Pause()
    {
        //Enable Pause HUD
        var pauseCanvasGroup = pauseMenuUI.GetComponent<CanvasGroup>();
        pauseCanvasGroup.alpha = 1;
        pauseCanvasGroup.interactable = true;
        pauseCanvasGroup.blocksRaycasts = true;

        //disable Player HUD
        var PlayerHudCanvasGroup = PlayerHud.GetComponent<CanvasGroup>();
        PlayerHudCanvasGroup.alpha = 0;
        PlayerHudCanvasGroup.interactable = false;
        PlayerHudCanvasGroup.blocksRaycasts = false;

        Time.timeScale = 0f;
        GameIsPaused = true;
        wheelHud.SetActive(false);
        wheelLevel.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    //PauseGame Buttons
    
    public void PausedQuitButton()
    {
        //add "are you sure you want to quit? Game wont save your Score"
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu",LoadSceneMode.Single);
    }
}
