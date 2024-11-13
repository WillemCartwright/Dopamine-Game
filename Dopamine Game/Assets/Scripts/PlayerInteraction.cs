using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    public Text interactText; // Verwijzing naar de UI-tekst voor interactie
    private NPCDialogue currentNPC; // Huidige NPC waar de speler mee kan praten

    void Start()
    {
        // Verberg interactie tekst bij de start van het spel
        if (interactText != null)
        {
            interactText.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        // Controleert of de speler in de buurt van een NPC is en op "E" drukt om te praten
        if (currentNPC != null && Input.GetKeyDown(KeyCode.E))
        {
            currentNPC.TriggerDialogue(); // Start de dialoog van de huidige NPC
        }

        // Check of de speler naar de NPC kijkt en toon interactie tekst
        ShowInteractionText();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Controleer of het object een NPC is
        if (other.CompareTag("NPC"))
        {
            currentNPC = other.GetComponent<NPCDialogue>(); // Bewaar de NPC die de speler heeft benaderd
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Reset de huidige NPC als de speler het bereik verlaat
        if (other.CompareTag("NPC"))
        {
            currentNPC = null; // Geen interactie meer mogelijk
            if (interactText != null)
            {
                interactText.gameObject.SetActive(false); // Verberg interactie tekst
            }
        }
    }

    private void ShowInteractionText()
    {
        // Controleer of we dicht bij een NPC zijn
        if (currentNPC != null)
        {
            // Raycast vanuit het midden van het scherm (voor een crosshair-effect)
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;

            // Controleer of we de NPC "raken" met de ray
            if (Physics.Raycast(ray, out hit))
            {
                // Alleen tonen als de hit NPC gelijk is aan de huidige NPC
                if (hit.collider != null && hit.collider.gameObject == currentNPC.gameObject)
                {
                    interactText.gameObject.SetActive(true); // Toon interactie tekst
                }
                else
                {
                    interactText.gameObject.SetActive(false); // Verberg interactie tekst
                }
            }
            else
            {
                interactText.gameObject.SetActive(false); // Verberg interactie tekst als de ray niets raakt
            }
        }
        else
        {
            interactText.gameObject.SetActive(false); // Verberg interactie tekst als er geen NPC in de buurt is
        }
    }
}
