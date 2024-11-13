using UnityEngine;

public class CloseAllPanels : MonoBehaviour
{
    // Verwijzingen naar de panels die je wilt sluiten
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;

    // Functie om alle panels te sluiten
    public void CloseAll()
    {
        panel1.SetActive(false);
        panel2.SetActive(false);
        panel3.SetActive(false);
    }
}
