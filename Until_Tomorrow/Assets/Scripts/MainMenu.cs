using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator animator;

    public void NewGame(){
        SceneManager.LoadScene("StartCutscene");
    }

    public void QuitToDesktop(){
        Application.Quit();
    }
}
