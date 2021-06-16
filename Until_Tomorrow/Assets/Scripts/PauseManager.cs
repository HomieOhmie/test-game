using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public string mainMenu;
    public GameObject pauseFirst;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("pause")){
            PauseUnpause();
        }  
    }

    public void PauseUnpause(){
        if(!pauseMenu.activeInHierarchy){
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            // Clear selected object
            EventSystem.current.SetSelectedGameObject(null);
            // Set a new selected object
            EventSystem.current.SetSelectedGameObject(pauseFirst);
        } else {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void Resume(){
        PauseUnpause();
    }

    public void MainMenu(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenu);
    }
}
