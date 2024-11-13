using UnityEngine;
using UnityEngine.UI;

public class scherm4 : MonoBehaviour
{
    // Referenties naar de UI-elementen
    public GameObject panel;             // Panel dat de knop en de feedbacktekst bevat
    public Text codeText;                // Text om de gegenereerde code weer te geven
    public Button generateCodeButton;    // Knop om de code te genereren
    public Button closeButton;           // Knop om het paneel te sluiten

    public AudioClip soundEffect;        // Geluid dat afgespeeld moet worden
    private AudioSource audioSource;     // AudioSource om het geluid af te spelen

    void Start()
    {
        // Maak het paneel en de tekst onzichtbaar in het begin
        panel.SetActive(false);
        codeText.enabled = false;

        // Haal de AudioSource component op
        audioSource = GetComponent<AudioSource>();

        // Koppel de generateCodeButton aan de GenerateRandomCode-methode
        generateCodeButton.onClick.AddListener(GenerateRandomCode);

        // Koppel de closeButton aan de ClosePanel-methode
        closeButton.onClick.AddListener(ClosePanel);
    }

    // Methode om het paneel zichtbaar te maken
    public void ShowPanel()
    {
        panel.SetActive(true); // Maak het paneel zichtbaar
        codeText.enabled = false; // Verberg de tekst totdat een code gegenereerd wordt

        // Speel het geluid af als het geluid is ingesteld
        if (audioSource != null && soundEffect != null)
        {
            audioSource.PlayOneShot(soundEffect);
        }
    }

    // Methode om een willekeurige viercijferige code te genereren
    public void GenerateRandomCode()
    {
        // Genereer een willekeurige viercijferige code tussen 1000 en 9999
        int randomCode = Random.Range(1000, 10000);

        // Toon de code in de tekst
        codeText.text = "Generated Code: " + randomCode.ToString();
        codeText.enabled = true; // Maak de tekst zichtbaar
    }

    // Methode om het paneel te sluiten
    public void ClosePanel()
    {
        panel.SetActive(false); // Verberg het paneel
    }
}