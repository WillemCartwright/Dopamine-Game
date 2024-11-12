using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Referentie naar het UI-element
    public GameObject panel;             // Panel dat zichtbaar/onniet zichtbaar gemaakt moet worden

    void Start()
    {
        // Maak het paneel in het begin onzichtbaar
        panel.SetActive(false);
    }

    // Methode om het paneel zichtbaar te maken
    public void Show1_1Panel()
    {
        panel.SetActive(true); // Maak het paneel zichtbaar wanneer deze methode wordt aangeroepen
        Debug.Log("Panel is now visible");
    }
}
