using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour
{
    // Referenties naar UI-elementen
    public GameObject panel;                 // Panel dat zichtbaar/onzichtbaar gemaakt moet worden
    public Text textFieldGreen;              // Tekstvak dat groen moet worden
    public Text textFieldWhite;              // Tekstvak dat wit moet worden
    public Text temporaryMessage;            // Tijdelijk tekstvak voor de 4-seconden-boodschap
    public GameObject targetImageObject;     // Het GameObject van de afbeelding die actief moet worden gezet
    public GameObject inactiveImageObject;   // Het GameObject van de afbeelding die inactief moet worden gezet
    public GameObject additionalImageObject; // De extra afbeelding die tegelijkertijd actief moet worden gezet

    // Geluidsbron en geluid
    public AudioClip soundEffect;            // Het geluid dat moet worden afgespeeld
    private AudioSource audioSource;          // De AudioSource component

    void Start()
    {
        // Zorg ervoor dat de AudioSource is toegevoegd aan het huidige GameObject
        audioSource = gameObject.AddComponent<AudioSource>();

        // Maak het paneel in het begin onzichtbaar
        panel.SetActive(false);

        // Maak de afbeelding onzichtbaar in het begin
        if (targetImageObject != null)
            targetImageObject.SetActive(false);

        // Maak de tijdelijke tekst onzichtbaar in het begin
        if (temporaryMessage != null)
            temporaryMessage.gameObject.SetActive(false);

        // Zorg ervoor dat de andere afbeelding in het begin actief is
        if (inactiveImageObject != null)
            inactiveImageObject.SetActive(true);

        // Zorg ervoor dat de extra afbeelding in het begin inactief is
        if (additionalImageObject != null)
            additionalImageObject.SetActive(false);
    }

    // Methode om het paneel zichtbaar te maken
    public void Show1_1Panel()
    {
        panel.SetActive(true); // Maak het paneel zichtbaar wanneer deze methode wordt aangeroepen
        Debug.Log("Panel is now visible");

        // Verander de kleur van het eerste tekstvak naar groen
        if (textFieldGreen != null)
            textFieldGreen.color = Color.green;

        // Verander de kleur van het tweede tekstvak naar wit
        if (textFieldWhite != null)
            textFieldWhite.color = Color.white;

        // Zet de afbeelding actief
        if (targetImageObject != null)
            targetImageObject.SetActive(true);

        // Zet de extra afbeelding actief
        if (additionalImageObject != null)
            additionalImageObject.SetActive(true);

        // Maak de andere afbeelding inactief
        if (inactiveImageObject != null)
            inactiveImageObject.SetActive(false);

        // Speel het geluid af als het is toegewezen
        if (soundEffect != null && audioSource != null)
        {
            audioSource.PlayOneShot(soundEffect); // Speel het geluid af
        }

        // Start de coroutine om de tijdelijke boodschap te tonen
        if (temporaryMessage != null)
        {
            StartCoroutine(DisplayTemporaryMessage());
        }
    }

    // Coroutine om de tijdelijke boodschap te tonen voor 4 seconden
    private IEnumerator DisplayTemporaryMessage()
    {
        temporaryMessage.gameObject.SetActive(true); // Maak het tekstvak zichtbaar
        yield return new WaitForSeconds(8);          // Wacht 4 seconden
        temporaryMessage.gameObject.SetActive(false); // Verberg het tekstvak weer
    }
}
