using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueUI; // UI die de dialoog toont
    public Text dialogueText; // Tekst waar de dialoog op komt
    public Button endButton; // De button die de dialoog beëindigt

    private string[] npcDialogue;
    private string[] playerDialogue;
    private int dialogueIndex = 0; // Huidige positie in het gesprek
    private bool isTalking = false; // Controleren of er een gesprek gaande is

    // Ontvang de dialoog voor de huidige NPC
    public void StartDialogue(string[] npcDialogues, string[] playerDialogues)
    {
        if (!isTalking)
        {
            npcDialogue = npcDialogues;
            playerDialogue = playerDialogues;
            isTalking = true;
            dialogueIndex = 0;
            dialogueUI.SetActive(true);
            endButton.gameObject.SetActive(false);
            ShowNextDialogue();
        }
    }

    private void ShowNextDialogue()
    {
        if (dialogueIndex < npcDialogue.Length + playerDialogue.Length)
        {
            if (dialogueIndex % 2 == 0)
            {
                dialogueText.text = npcDialogue[dialogueIndex / 2];
                dialogueText.color = Color.blue;
            }
            else
            {
                dialogueText.text = playerDialogue[dialogueIndex / 2];
                dialogueText.color = Color.green;
            }
            dialogueIndex++;
        }
        else
        {
            endButton.gameObject.SetActive(true);
        }
    }

    private void EndDialogue()
    {
        isTalking = false;
        dialogueUI.SetActive(false);
    }

    public void OnEndButtonClick()
    {
        EndDialogue();
    }

    void Update()
    {
        if (isTalking && Input.GetKeyDown(KeyCode.E))
        {
            ShowNextDialogue();
        }
    }
}
