using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class scherm8 : MonoBehaviour
{
    public GameObject fifthPanel;   // Het eerste paneel met invoerveld en knop
    public GameObject sixthPanel;   // Het tweede lege paneel

    public Button payButton;        // De bevestigingsknop

    void Start()
    {
        // Zorg ervoor dat beide panelen in het begin onzichtbaar zijn
        fifthPanel.SetActive(true);       // Het eerste paneel is zichtbaar bij start
        sixthPanel.SetActive(false);      // Het tweede paneel is verborgen bij start

        // Koppel de bevestigingsknop aan de ShowSixthPanel-methode
        payButton.onClick.AddListener(ShowSixthPanel);
    }

    // Methode om het tweede paneel te tonen en het eerste paneel te verbergen
    public void ShowSixthPanel()
    {
        Debug.Log("Showing Sixth Panel and hiding Fifth Panel");
        fifthPanel.SetActive(false);     // Verberg het eerste paneel
        sixthPanel.SetActive(true);      // Toon het tweede paneel

        // Start de coroutine om beide panelen na 3 seconden te sluiten
        StartCoroutine(CloseAllPanelsAfterDelay());
    }

    // Coroutine die 3 seconden wacht en vervolgens beide panelen sluit
    private IEnumerator CloseAllPanelsAfterDelay()
    {
        yield return new WaitForSeconds(3);  // Wacht 3 seconden

        // Zorg ervoor dat beide panelen verborgen zijn
        fifthPanel.SetActive(false);         // Verberg het eerste paneel
        sixthPanel.SetActive(false);         // Verberg het tweede paneel

        Debug.Log("Both panels should now be hidden");
    }
}
