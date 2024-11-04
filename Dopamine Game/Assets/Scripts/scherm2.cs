using UnityEngine;
using UnityEngine.UI;

public class scherm2 : MonoBehaviour
{
    public GameObject firstPanel;   // Het eerste paneel met invoerveld en knop
    public GameObject secondPanel;   // Het tweede lege paneel

    public Button confirmButton;     // De bevestigingsknop

    void Start()
    {
        // Zorg ervoor dat beide panelen in het begin onzichtbaar zijn
        firstPanel.SetActive(true);
        secondPanel.SetActive(false); // Zorg ervoor dat het tweede paneel niet zichtbaar is bij het starten

        // Koppel de bevestigingsknop aan de ShowSecondPanel-methode
        confirmButton.onClick.AddListener(ShowSecondPanel);
    }

    // Methode om het tweede paneel te tonen en het eerste paneel te verbergen
    public void ShowSecondPanel()
    {
        firstPanel.SetActive(false); // Verberg het eerste paneel
        secondPanel.SetActive(true);  // Toon het tweede paneel
    }
}

