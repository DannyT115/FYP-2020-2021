using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // StartSimulation changes the scene from the MainMenu to the simulation.
    public void StartSimulation()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void StartSecondLevel()
    {
        //TODO: Start SecondLevel
    }

    public void StartSandbox()
    {
        //TODO: Start Sandbox level
    }
    
    // QuitSimulation exits from the main menu and out of the Unity Application.
    public void QuitSimulation()
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
