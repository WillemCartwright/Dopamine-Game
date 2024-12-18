using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public DialogueManager dialogueManager;

    // Unieke dialoog voor deze NPC
    private string[] npcDialogue = { 
        "NPC 1: Hallo daar! Wat brengt je naar de stad?",
        "NPC 1: Geniet van je verblijf!"
    };

    private string[] playerDialogue = { 
        "Jij: Dankjewel! Ik ben hier voor avontuur.",
        "Jij: Ik zal zeker genieten, bedankt!"
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
