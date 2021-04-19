using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // StartSimulation changes the scene from the MainMenu to the simulation.
    public void StartHoopsLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("Hoops Level Loaded");
    }

    public void StartTargetsLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 2);
        Debug.Log("Targets Level Loaded");
    }
    
    // QuitSimulation exits from the main menu and out of the Unity Application.
    public void QuitApplication()
    {
        Debug.Log("Quitting..."); // TODO: For debugging purposes only.
        Application.Quit();
    }

    public void GitHubLink()
    {
        Application.OpenURL("https://github.com/DannyT115/");
    }

    public void OverleafLink()
    {
        Application.OpenURL("https://www.overleaf.com/read/phpdrwfzfydw/");
    }
}
