using UnityEngine;

public class CloseAllPanels2 : MonoBehaviour
{
    // Verwijzingen naar de panels die je wilt sluiten
    public GameObject panel10;
    public GameObject panel11;
    public GameObject panel12;

    // Functie om alle panels te sluiten
    public void CloseAll()
    {
        panel10.SetActive(false);
        panel11.SetActive(false);
        panel12.SetActive(false);
    }
}

