using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroScreenController : MonoBehaviour
{
    public GameObject introPanel; // Verwijzing naar het Paneel dat het introductiescherm bevat
    public Button nextButton;     // Verwijzing naar de "Next" knop

    void Start()
    {
        // Zorg ervoor dat het paneel actief is bij het starten van de scene
        introPanel.SetActive(true);

        // Voeg de functie toe die de knop moet uitvoeren bij klikken
        nextButton.onClick.AddListener(CloseIntro);
    }

    // Functie om het introductiescherm te sluiten
    void CloseIntro()
    {
        introPanel.SetActive(false);
    }
}
