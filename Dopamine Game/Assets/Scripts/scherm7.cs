using UnityEngine;
using UnityEngine.UI;

public class scherm7 : MonoBehaviour
{
    public GameObject fifthPanel;   // Het eerste paneel met invoerveld en knop
    public GameObject sixthPanel;   // Het tweede lege paneel

    public Button payButton;     // De bevestigingsknop

    void Start()
    {
        // Zorg ervoor dat beide panelen in het begin onzichtbaar zijn
        fifthPanel.SetActive(true);
        sixthPanel.SetActive(false); // Zorg ervoor dat het tweede paneel niet zichtbaar is bij het starten

        // Koppel de bevestigingsknop aan de ShowSecondPanel-methode
        payButton.onClick.AddListener(ShowSixthPanel);
    }

    // Methode om het tweede paneel te tonen en het eerste paneel te verbergen
    public void ShowSixthPanel()
    {
        fifthPanel.SetActive(false); // Verberg het eerste paneel
        sixthPanel.SetActive(true);  // Toon het tweede paneel
    }
}