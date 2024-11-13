using UnityEngine;
using UnityEngine.UI;

public class Scherm5 : MonoBehaviour
{
    // Referenties naar de UI-elementen
    public GameObject panel;               // Panel dat de knop bevat
    public Button payButton;               // Knop om te betalen
    public Text statusText;                // Tekstvak dat groen (#1EFB1F) moet worden
    public Text additionalText;            // Het tweede tekstvak dat van grijs naar wit moet gaan
    public Image confirmationImage;        // Afbeelding die actief moet worden
    public AudioClip soundEffect;          // Geluid dat afgespeeld moet worden
    private AudioSource audioSource;       // AudioSource om het geluid af te spelen

    void Start()
    {
        // Maak het paneel en de afbeelding in het begin onzichtbaar
        panel.SetActive(false);
        confirmationImage.gameObject.SetActive(false);

        // Haal de AudioSource component op
        audioSource = GetComponent<AudioSource>();

        // Koppel de payButton aan de ShowPayPanel-methode
        payButton.onClick.AddListener(ShowPayPanel);

        // Zet de beginwaarden van de tekstkleuren
        statusText.color = Color.white; // Beginstatus voor statusText is wit
        additionalText.color = new Color(0.843f, 0.843f, 0.843f); // additionalText begint als grijs (#D7D7D7)
    }

    // Methode om het paneel zichtbaar te maken wanneer op "Pay" wordt gedrukt
    public void ShowPayPanel()
    {
        panel.SetActive(true);                     // Maak het paneel zichtbaar
        statusText.color = new Color(0.118f, 0.984f, 0.122f); // Verander statusText naar groen (#1EFB1F)
        additionalText.color = Color.white;        // Verander additionalText naar wit
        confirmationImage.gameObject.SetActive(true); // Zet de afbeelding actief

        // Speel het geluid af als het geluid is ingesteld
        if (audioSource != null && soundEffect != null)
        {
            audioSource.PlayOneShot(soundEffect);
        }

        Debug.Log("Pay button pressed");
    }
}