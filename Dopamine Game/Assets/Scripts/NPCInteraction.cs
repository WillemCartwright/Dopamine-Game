using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public GameObject dialogueManager; // Verwijzing naar het DialogueManager-object

    private bool playerInRange; // Om te controleren of de speler dichtbij is

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            dialogueManager.GetComponent<DialogueManager>().StartDialogue(); // Start het gesprek via DialogueManager
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            // Hier kun je ook de code plaatsen om het Crosshair te veranderen in een hand
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            // Hier kun je het Crosshair terugveranderen naar normaal
        }
    }
}
