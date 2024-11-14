using UnityEngine;
using UnityEngine.UI; // For UI elements
using UnityEngine.SceneManagement; // For scene management
using System.Collections; // For IEnumerator and coroutines

public class Medicijn1 : MonoBehaviour
{
    // Reference to the UI element
    public GameObject panel; // The panel to be shown or hidden

    // UI elements to modify when the panel is displayed
    public Text greenText;   // Green text (for #5BFE59)
    public Image activeImage; // The image to make visible

    // Name of the new scene you want to load
    public string newSceneName; 

    void Start()
    {
        // Hide the panel initially
        panel.SetActive(false);
    }

    // Method to show the panel
    public void Show10Panel()
    {
        // Make the panel visible
        panel.SetActive(true); 
        Debug.Log("Panel is now visible");

        // Update the UI elements
        SetUIElements();

        // Start the coroutine to switch scenes after 8 seconds
        StartCoroutine(LoadSceneAfterDelay(8f));
    }

    // Method to update UI elements
    private void SetUIElements()
    {
        // Set the color of greenText to green (#5BFE59)
        if (greenText != null)
        {
            greenText.color = new Color(0.36f, 0.996f, 0.349f); // Green (hex #5BFE59)
        }

        // Set the image visible
        if (activeImage != null)
        {
            activeImage.gameObject.SetActive(true); // Ensure the image is visible
        }
    }

    // Coroutine to load the scene after an 8-second delay
    private IEnumerator LoadSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait 8 seconds

        // Load the new scene if the scene name is correctly set
        if (!string.IsNullOrEmpty(newSceneName))
        {
            SceneManager.LoadScene(newSceneName);
        }
        else
        {
            Debug.LogWarning("The new scene name is not set!");
        }
    }
}
