using UnityEngine;

public class panelswitcher1 : MonoBehaviour
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

    // Functie om naar Panel 1 te gaan
    public void ShowPanel1()
    {
        panel1.SetActive(true);
        panel2.SetActive(false);
        panel3.SetActive(false);
    }

    // Functie om naar Panel 2 te gaan
    public void ShowPanel2()
    {
        panel1.SetActive(false);
        panel2.SetActive(true);
        panel3.SetActive(false);
    }

    // Functie om naar Panel 3 te gaan
    public void ShowPanel3()
    {
        panel1.SetActive(false);
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
}
