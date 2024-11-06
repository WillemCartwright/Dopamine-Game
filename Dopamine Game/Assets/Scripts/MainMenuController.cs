using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public CanvasGroup OptionPanel;

    public void PlayGame()
    {
        // Laad de volgende scène
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Options()
    {
        // Controleer of OptionPanel niet null is
        if (OptionPanel != null)
        {
            OptionPanel.alpha = 1;
            OptionPanel.interactable = true;
            OptionPanel.blocksRaycasts = true;  // Correctie hier
        }
        else
        {
            Debug.LogError("OptionPanel is niet toegewezen in de Inspector!");
        }
    }

    public void Back()
    {
        // Controleer of OptionPanel niet null is
        if (OptionPanel != null)
        {
            OptionPanel.alpha = 0;
            OptionPanel.interactable = false;
            OptionPanel.blocksRaycasts = false;  // Correctie hier
        }
        else
        {
            Debug.LogError("OptionPanel is niet toegewezen in de Inspector!");
        }
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game afsluiten");
    }
}


