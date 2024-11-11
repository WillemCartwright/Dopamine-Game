using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    // Referentie naar de UI-elementen
    public GameObject panel;             // Panel dat de knop bevat
    public Button payButton;             // Knop om te betalen

    void Start()
    {
        // Maak het paneel in het begin onzichtbaar
        panel.SetActive(false);

        // Koppel de payButton aan de ShowPayPanel-methode
        payButton.onClick.AddListener(ShowPayPanel);
    }

    // Methode om het paneel zichtbaar te maken wanneer op "Pay" wordt gedrukt
    public void ShowPayPanel()
    {
        panel.SetActive(true); // Maak het paneel zichtbaar wanneer de knop wordt ingedrukt
        Debug.Log("Pay button pressed");
    }
}
