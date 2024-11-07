using UnityEngine;
using UnityEngine.UI;

public class scherm9 : MonoBehaviour
{
    public GameObject fifthPanel;      // Het eerste paneel met invoerveld en knop
    public GameObject sixthPanel;      // Het tweede paneel
    public Button payButton;           // De bevestigingsknop
    public Button closeButton;         // De sluitknop voor het tweede paneel

    void Start()
    {
        // Zorg ervoor dat het eerste paneel zichtbaar is en het tweede onzichtbaar bij het starten
        fifthPanel.SetActive(true);
        sixthPanel.SetActive(false);

        // Koppel de bevestigingsknop aan de ShowSixthPanel-methode
        payButton.onClick.AddListener(ShowSixthPanel);

        // Koppel de sluitknop aan de CloseSixthPanel-methode
        closeButton.onClick.AddListener(CloseSixthPanel);
    }

    // Methode om het tweede paneel te tonen en het eerste paneel te verbergen
    public void ShowSixthPanel()
    {
        fifthPanel.SetActive(false); // Verberg het eerste paneel
        sixthPanel.SetActive(true);  // Toon het tweede paneel
    }

    // Methode om het tweede paneel te verbergen
    public void CloseSixthPanel()
    {
        sixthPanel.SetActive(false);  // Verberg het tweede paneel
        fifthPanel.SetActive(true);   // Optioneel: toon het eerste paneel opnieuw
    }
}

