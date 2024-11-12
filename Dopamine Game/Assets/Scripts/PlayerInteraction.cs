using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private NPCDialogue currentNPC; // Huidige NPC waar de speler mee kan praten

    void Update()
    {
        // Controleert of de speler in de buurt van een NPC is en op "E" drukt om te praten
        if (currentNPC != null && Input.GetKeyDown(KeyCode.E))
        {
            currentNPC.TriggerDialogue(); // Start de dialoog van de huidige NPC
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Controleer of het object een NPC is (gebruik de "NPC"-tag om NPC's te identificeren)
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
        }
    }
}