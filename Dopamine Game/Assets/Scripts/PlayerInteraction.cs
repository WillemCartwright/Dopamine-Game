using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    public Text interactText; // Verwijzing naar de UI-tekst voor interactie
    private NPCDialogue primaryNPC; // Eerste NPC waar de speler mee kan praten
    private NPCDialogue secondaryNPC; // Tweede NPC waar de speler mee kan praten

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
        if (primaryNPC != null && Input.GetKeyDown(KeyCode.E))
        {
            primaryNPC.TriggerDialogue(); // Start de dialoog van de eerste NPC
        }
        else if (secondaryNPC != null && Input.GetKeyDown(KeyCode.E))
        {
            secondaryNPC.TriggerDialogue(); // Start de dialoog van de tweede NPC
        }

        // Check of de speler naar een NPC kijkt en toon interactie tekst
        ShowInteractionText();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Controleer of het object een primaire NPC is
        if (other.CompareTag("NPC") && primaryNPC == null)
        {
            primaryNPC = other.GetComponent<NPCDialogue>(); // Bewaar de eerste NPC die de speler heeft benaderd
        }
        // Controleer of het object een secundaire NPC is
        else if (other.CompareTag("NPC") && secondaryNPC == null)
        {
            secondaryNPC = other.GetComponent<NPCDialogue>(); // Bewaar de tweede NPC die de speler heeft benaderd
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Reset de primaire NPC als de speler het bereik verlaat
        if (other.CompareTag("NPC") && other.GetComponent<NPCDialogue>() == primaryNPC)
        {
            primaryNPC = null;
            interactText.gameObject.SetActive(false); // Verberg interactie tekst
        }
        // Reset de secundaire NPC als de speler het bereik verlaat
        else if (other.CompareTag("NPC") && other.GetComponent<NPCDialogue>() == secondaryNPC)
        {
            secondaryNPC = null;
            interactText.gameObject.SetActive(false); // Verberg interactie tekst
        }
    }

    private void ShowInteractionText()
    {
        // Controleer of we dicht bij een NPC zijn
        if (primaryNPC != null || secondaryNPC != null)
        {
            // Raycast vanuit het midden van het scherm (voor een crosshair-effect)
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;

            // Controleer of we de NPC "raken" met de ray
            if (Physics.Raycast(ray, out hit))
            {
                // Alleen tonen als de hit NPC gelijk is aan de huidige NPC's
                if (hit.collider != null && 
                    (hit.collider.gameObject == primaryNPC?.gameObject || hit.collider.gameObject == secondaryNPC?.gameObject))
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
