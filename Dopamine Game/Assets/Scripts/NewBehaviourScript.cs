using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    // Referenties naar UI-elementen
    public GameObject panel;             // Panel dat zichtbaar/onzichtbaar gemaakt moet worden
    public Text textFieldGreen;          // Tekstvak dat groen moet worden
    public Text textFieldWhite;          // Tekstvak dat wit moet worden
    public GameObject targetImageObject; // Het GameObject van de afbeelding die actief moet worden gezet

    void Start()
    {
        // Maak het paneel in het begin onzichtbaar
        panel.SetActive(false);

        // Maak de afbeelding onzichtbaar in het begin
        if (targetImageObject != null)
            targetImageObject.SetActive(false);
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
    }
}
