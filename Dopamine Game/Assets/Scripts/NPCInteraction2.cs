using UnityEngine;

public class NPCInteraction2 : MonoBehaviour
{
    public DialogueManager dialogueManager;

    // Unieke dialoog voor deze NPC
    private string[] npcDialogue = {
        "NPC 2: Wat brengt jou hier?",
        "NPC 2: Wees voorzichtig in deze buurt."
    };

    private string[] playerDialogue = {
        "Jij: Ik kijk gewoon rond.",
        "Jij: Bedankt voor de waarschuwing!"
    };

    private bool isPlayerNearby = false;

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            dialogueManager.StartDialogue(npcDialogue, playerDialogue);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
        }
    }
}

