using UnityEngine;
using UnityEngine.UI;

public class scherm : MonoBehaviour
{
    // References to the UI elements
    public GameObject panel;             // Panel that contains the button and input field
    public Button confirmButton;         // Button to trigger confirmation
    public InputField codeInputField;    // Input field for the four-digit code

    public AudioClip soundEffect;        // Sound that should play when the panel is shown
    private AudioSource audioSource;     // AudioSource to play the sound

    void Start()
    {
        // Make the panel invisible at the beginning
        panel.SetActive(false);

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

        Debug.Log("Confirm button pressed");
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