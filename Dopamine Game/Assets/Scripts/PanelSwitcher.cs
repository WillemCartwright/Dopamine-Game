using UnityEngine;

public class PanelSwitcher : MonoBehaviour
{
    // Verwijzingen naar de panels
    public GameObject panel5;
    public GameObject panel6;
    public GameObject panel7;
    public GameObject panel8;

    // Functie om naar Panel 5 te gaan (reeds werkend volgens jou)
    public void ShowPanel5()
    {
        panel5.SetActive(true);
    }

    // Functie om naar Panel 6 te gaan
    public void ShowPanel6()
    {
        panel5.SetActive(false);  // Panel 5 verbergen
        panel6.SetActive(true);   // Panel 6 tonen
    }

    // Functie om naar Panel 7 te gaan
    public void ShowPanel7()
    {
        panel6.SetActive(false);  // Panel 6 verbergen
        panel7.SetActive(true);   // Panel 7 tonen
    }

    // Functie om naar Panel 8 te gaan
    public void ShowPanel8()
    {
        panel7.SetActive(false);  // Panel 7 verbergen
        panel8.SetActive(true);   // Panel 8 tonen
    }

    // Functie om alle panels te sluiten
    public void CloseAllPanels()
    {
        panel5.SetActive(false);
        panel6.SetActive(false);
        panel7.SetActive(false);
        panel8.SetActive(false);
    }
}

