using UnityEngine;
using UnityEngine.UI;

public class scherm9 : MonoBehaviour
{
    public GameObject fifthPanel;   // Het eerste panel met input veld en knop
    public GameObject sixthPanel;   // Het tweede panel om weer te geven
    public GameObject seventhPanel; // Derde panel
    public GameObject eighthPanel;  // Vierde panel

    public Button payButton;        // De bevestigingsknop
    public Button closeButton;      // De close-knop voor het zesde panel

    void Start()
    {
        // Zorg ervoor dat alleen het vijfde panel zichtbaar is bij de start
        fifthPanel.SetActive(true);
        sixthPanel.SetActive(false);
        seventhPanel.SetActive(false);
        eighthPanel.SetActive(false);

        // Link de bevestigingsknop aan de ShowSixthPanel methode
        payButton.onClick.AddListener(ShowSixthPanel);

        // Link de close-knop aan de CloseAllPanels methode
        closeButton.onClick.AddListener(CloseAllPanels);
    }

    // Methode om het zesde panel weer te geven en het vijfde panel te verbergen
    public void ShowSixthPanel()
    {
        fifthPanel.SetActive(false);
        sixthPanel.SetActive(true);
    }

    // Methode om alle panels te verbergen wanneer de close-knop op het zesde panel wordt ingedrukt
    public void CloseAllPanels()
    {
        fifthPanel.SetActive(false);
        sixthPanel.SetActive(false);
        seventhPanel.SetActive(false);
        eighthPanel.SetActive(false);
    }
}



