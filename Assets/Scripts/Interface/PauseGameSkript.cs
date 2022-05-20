using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGameSkript : MonoBehaviour
{
    [SerializeField] GameObject pauseGameObject;

    public void PauseGame()
    {
        pauseGameObject.SetActive(true);
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void ResumeButton()
    {
        pauseGameObject.SetActive(false);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
    }
    public void OptionButton()
    {
        //OptionsCanvas auf? -> OptionenSkript?
        //Speichert es auf auf einen anderen Skript? SO?
    }
    public void SaveAndQuitButton()
    {
        //Saved : Position, Gold, Tech, Time of the day, wave, ....
        //zurück zum Menü
    }




}
