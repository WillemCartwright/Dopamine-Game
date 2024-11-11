using UnityEngine;

public class panelswitcher : MonoBehaviour
{
    // Verwijzingen naar de panels
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;

    // Start functie die bij het starten van de scene wordt aangeroepen
    void Start()
    {
        // Zet alle panels uit bij het starten van de scene, behalve panel1
        panel1.SetActive(true);
        panel2.SetActive(false);
        panel3.SetActive(false);
    }

    // Functie om naar Panel 5 te gaan (reeds werkend volgens jou)
    public void ShowPanel1()
    {
        // Zet Panel 5 aan, en alle andere panels uit
        panel1.SetActive(true);
        panel2.SetActive(false);
        panel3.SetActive(false);
    }

    // Functie om naar Panel 6 te gaan
    public void ShowPanel2()
    {
        // Panel 1 uitzetten en Panel 2 aanzetten
        panel1.SetActive(false);
        panel2.SetActive(true);
        panel3.SetActive(false);
    }

    // Functie om naar Panel 7 te gaan
    public void ShowPanel3()
    {
        // Panel 2 uitzetten en Panel 3 aanzetten
        panel2.SetActive(false);
        panel3.SetActive(true);
    }

    // Functie om alle panels te sluiten
    public void CloseAllPanelss()
    {
        panel1.SetActive(false);
        panel2.SetActive(false);
        panel3.SetActive(false);
    }

    // Functie die door de knop in Panel 1 wordt aangeroepen om naar Panel 2 te gaan
    public void GoToPanel2()
    {
        ShowPanel2(); // Roep de functie aan die Panel 2 toont
    }
}

