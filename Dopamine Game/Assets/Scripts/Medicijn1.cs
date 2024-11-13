using UnityEngine;
using UnityEngine.UI; // Zorg ervoor dat je de UI namespace hebt voor toegang tot de UI-elementen

public class Medicijn1 : MonoBehaviour
{
    // Referentie naar het UI-element
    public GameObject panel; // Het paneel dat zichtbaar of onzichtbaar gemaakt moet worden

    // UI-elementen om te wijzigen wanneer het paneel wordt weergegeven
    public Text greenText;   // Groene tekst (voor #5BFE59)
    public Image activeImage; // De afbeelding die zichtbaar moet worden

    void Start()
    {
        // Maak het paneel in het begin onzichtbaar
        panel.SetActive(false);
    }

    // Methode om het paneel zichtbaar te maken
    public void Show10Panel()
    {
        // Maak het paneel zichtbaar
        panel.SetActive(true); 
        Debug.Log("Paneel is nu zichtbaar");

        // Pas de UI-elementen aan
        SetUIElements();
    }

    // Methode om de UI-elementen aan te passen
    private void SetUIElements()
    {
        // Zet de kleur van greenText naar groen (#5BFE59)
        if (greenText != null)
        {
            greenText.color = new Color(0.36f, 0.996f, 0.349f); // Groen (hex #5BFE59)
        }

        // Zet de afbeelding zichtbaar
        if (activeImage != null)
        {
            activeImage.gameObject.SetActive(true); // Zorg ervoor dat de afbeelding zichtbaar is
        }
    }
}
