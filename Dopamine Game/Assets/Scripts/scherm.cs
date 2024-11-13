using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class scherm : MonoBehaviour
{
    // References to the UI elements
    public GameObject panel;             // Panel that contains the button and input field
    public Button confirmButton;         // Button to trigger confirmation
    public InputField codeInputField;    // Input field for the four-digit code
    public Text temporaryMessageText;    // Text that will be displayed temporarily for 14 seconds

    public Image activeImage;            // Image that should be shown as active
    public Image inactiveImage;          // Image that should be shown as inactive

    public AudioClip soundEffect;        // Sound that should play when the panel is shown
    private AudioSource audioSource;     // AudioSource to play the sound

    void Start()
    {
        // Make the panel and temporary message text invisible at the beginning
        panel.SetActive(false);
        temporaryMessageText.gameObject.SetActive(false); // Hide the temporary message initially

        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();

        // Link the confirmButton to the ShowConfirmPanel method
        confirmButton.onClick.AddListener(ShowConfirmPanel);
    }

    // Method to make the panel visible when "Confirm" is pressed
    public void ShowConfirmPanel()
    {
        panel.SetActive(true); // Show the panel when the button is pressed

        // Play the sound if the soundEffect is assigned
        if (audioSource != null && soundEffect != null)
        {
            audioSource.PlayOneShot(soundEffect); // Play the sound
        }

        // Show the temporary message, set images, and start the 14-second timer
        StartCoroutine(ShowTemporaryMessageWithImagesForSeconds(14f));

        Debug.Log("Confirm button pressed");
    }

    // Coroutine to show the temporary message for 14 seconds and toggle images
    private IEnumerator ShowTemporaryMessageWithImagesForSeconds(float seconds)
    {
        // Set the active/inactive images
        if (inactiveImage != null)
        {
            inactiveImage.enabled = false; // Set the inactive image to be invisible
            Debug.Log("inactiveImage is now hidden");
        }

        if (activeImage != null)
        {
            activeImage.gameObject.SetActive(true); // Ensure the activeImage GameObject is enabled
            activeImage.enabled = true; // Set the active image to be visible
            Debug.Log("activeImage is now visible");
        }
        else
        {
            Debug.LogWarning("activeImage is not assigned in the Inspector.");
        }

        // Show the temporary message
        temporaryMessageText.gameObject.SetActive(true);

        // Wait for the specified time (14 seconds)
        yield return new WaitForSeconds(seconds);

        // Hide the temporary message after 14 seconds
        temporaryMessageText.gameObject.SetActive(false);

        // Reset images to their original states
        if (inactiveImage != null)
        {
            inactiveImage.enabled = true; // Set the inactive image back to visible
            Debug.Log("inactiveImage is now visible again");
        }

        if (activeImage != null)
        {
            activeImage.enabled = false; // Hide the active image again
            Debug.Log("activeImage is now hidden again");
        }
    }

    // Method to validate the code input
    public void ValidateCode()
    {
        string code = codeInputField.text;

        // Check if the code is exactly 4 digits
        if (code.Length == 4 && int.TryParse(code, out int numericCode))
        {
            Debug.Log("Valid code entered: " + code);
            // Additional actions for a valid code can go here
        }
        else
        {
            Debug.Log("Invalid code! Please enter a 4-digit number.");
            // Optional: give feedback to the user
        }
    }
}
