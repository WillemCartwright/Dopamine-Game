using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{
    public GameObject firstPanel; // Het eerste panel (welkomstpanel)
    public GameObject secondPanel; // Het tweede panel (met de Close button)
    
    public Button nextButton; // De "Next" knop
    public Button closeButton; // De "Close" knop

    void Start()
    {
        // Zorg ervoor dat alleen het eerste panel zichtbaar is
        firstPanel.SetActive(true);
        secondPanel.SetActive(false);
        
        // Voeg event listeners toe aan de knoppen
        nextButton.onClick.AddListener(ShowNextPanel);
        closeButton.onClick.AddListener(ClosePanel);
    }

    // Functie om naar het volgende panel te gaan
    void ShowNextPanel()
    {
        firstPanel.SetActive(false); // Verberg het eerste panel
        secondPanel.SetActive(true); // Toon het tweede panel
    }

    // Functie om het tweede panel te sluiten
    void ClosePanel()
    {
        secondPanel.SetActive(false); // Verberg het tweede panel
    }
}
