using UnityEngine;

public class PanelController : MonoBehaviour
{
    // Verwijzingen naar de panels
    public GameObject panel10;
    public GameObject panel11;
    public GameObject panel12;

    // Start functie die bij het starten van de scene wordt aangeroepen
    void Start()
    {
        // Zet alle panels uit bij het starten van de scene, behalve panel10
        panel10.SetActive(true);
        panel11.SetActive(false);
        panel12.SetActive(false);
    }

    // Functie om naar Panel 10 te gaan
    public void ShowPanel10()
    {
        panel10.SetActive(true);
        panel11.SetActive(false);
        panel12.SetActive(false);
    }

    // Functie om naar Panel 11 te gaan
    public void ShowPanel11()
    {
        panel10.SetActive(false);
        panel11.SetActive(true);
        panel12.SetActive(false);
    }

    // Functie om naar Panel 12 te gaan
    public void ShowPanel12()
    {
        panel10.SetActive(false);
        panel11.SetActive(false);
        panel12.SetActive(true);
    }

    // Functie om alle panels te sluiten
    public void CloseAllPanels()
    {
        panel10.SetActive(false);
        panel11.SetActive(false);
        panel12.SetActive(false);
    }
}
