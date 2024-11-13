using UnityEngine;

public class Medicijn1 : MonoBehaviour
{
    // Referentie naar het UI-element
    public GameObject panel; // Het paneel dat zichtbaar of onzichtbaar gemaakt moet worden

    void Start()
    {
        // Maak het paneel in het begin onzichtbaar
        panel.SetActive(false);
    }

    // Methode om het paneel zichtbaar te maken
    public void Show10Panel() // Verander de methodenaam hier
    {
        panel.SetActive(true); // Maak het paneel zichtbaar wanneer deze methode wordt aangeroepen
        Debug.Log("Paneel is nu zichtbaar");
    }
}
