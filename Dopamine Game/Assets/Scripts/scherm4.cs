using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class scherm4 : MonoBehaviour
{
    // UI elements
    public GameObject panel;             // Panel containing the button and feedback text
    public Text codeText;                // Text for displaying the generated code
    public Text additionalText;          // New text that will be displayed for 8 seconds
    public Button generateCodeButton;    // Button to generate the code
    public Button closeButton;           // Button to close the panel

    public Image activeImage;            // Image that will be shown as active
    public Image inactiveImage;          // Image that will be shown as inactive

    public AudioClip soundEffect;        // Sound to be played
    private AudioSource audioSource;     // AudioSource to play the sound

    void Start()
    {
        // Make the panel and texts invisible initially
        panel.SetActive(false);
        codeText.enabled = false;
        additionalText.gameObject.SetActive(false); // Set the additional text GameObject inactive initially

        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();

        // Link generateCodeButton to GenerateRandomCode method
        generateCodeButton.onClick.AddListener(GenerateRandomCode);

        // Link closeButton to ClosePanel method
        closeButton.onClick.AddListener(ClosePanel);
    }

    // Method to show the panel
    public void ShowPanel()
    {
        panel.SetActive(true); // Show the panel
        codeText.enabled = false; // Hide the code text until a code is generated

        // Set image states: make inactiveImage invisible and activeImage visible
        if (inactiveImage != null)
        {
            inactiveImage.enabled = false; // Set the inactive image to be invisible
        }

        if (activeImage != null)
        {
            activeImage.gameObject.SetActive(true); // Ensure the activeImage GameObject is enabled
            activeImage.enabled = true; // Set the active image to be visible
        }

        // Play the sound if it's set
        if (audioSource != null && soundEffect != null)
        {
            audioSource.PlayOneShot(soundEffect);
        }

        // Start the coroutines to show the texts for 8 seconds
        StartCoroutine(ShowTextForSeconds(codeText, 8f)); // Shows codeText
        StartCoroutine(ShowGameObjectForSeconds(additionalText.gameObject, 8f)); // Shows additionalText for 8 seconds
    }

    // Coroutine to show a text for a specified number of seconds
    private IEnumerator ShowTextForSeconds(Text text, float seconds)
    {
        text.enabled = true; // Make the text visible
        yield return new WaitForSeconds(seconds); // Wait for the specified time
        text.enabled = false; // Hide the text again
    }

    // Coroutine to activate a GameObject for a specified number of seconds
    private IEnumerator ShowGameObjectForSeconds(GameObject obj, float seconds)
    {
        obj.SetActive(true); // Activate the GameObject
        yield return new WaitForSeconds(seconds); // Wait for the specified time
        obj.SetActive(false); // Deactivate the GameObject again
    }

    // Method to generate a random four-digit code
    public void GenerateRandomCode()
    {
        // Generate a random four-digit code between 1000 and 9999
        int randomCode = Random.Range(1000, 10000);

        // Display the generated code in the text
        codeText.text = "Generated Code: " + randomCode.ToString();
    }

    // Method to close the panel
    public void ClosePanel()
    {
        panel.SetActive(false); // Hide the panel
    }
}
