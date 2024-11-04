using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public GameObject firstPanel;   // Het eerste paneel
    public GameObject secondPanel;  // Het tweede paneel
    public GameObject thirdPanel;   // Het derde paneel

    public Button button7;          // Button 7
    public Button closeButton;      // De sluitknop voor het derde paneel

    void Start()
    {
        // Zorg ervoor dat alle panelen in het begin onzichtbaar zijn, behalve het eerste
        firstPanel.SetActive(true);
        secondPanel.SetActive(false);
        thirdPanel.SetActive(false);

        // Koppel de knoppen aan de methoden
        button7.onClick.AddListener(ShowThirdPanel);
        closeButton.onClick.AddListener(HideAllPanels);
    }

    // Methode om het derde paneel te tonen
    public void ShowThirdPanel()
    {
        secondPanel.SetActive(false); // Verberg het tweede paneel als het derde paneel verschijnt
        thirdPanel.SetActive(true);   // Maak het derde paneel zichtbaar
    }

    // Methode om alle panelen te verbergen
    public void HideAllPanels()
    {
        firstPanel.SetActive(false);  // Verberg het eerste paneel
        secondPanel.SetActive(false); // Verberg het tweede paneel
        thirdPanel.SetActive(false);  // Verberg het derde paneel
    }
}

