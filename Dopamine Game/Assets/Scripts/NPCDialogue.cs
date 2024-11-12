using System.Collections.Generic;
using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    public List<string> dialogueLines; // Lijst van dialoogregels
    private DialogueSystem dialogueSystem;

    void Start()
    {
        dialogueSystem = FindObjectOfType<DialogueSystem>();
    }

    public void TriggerDialogue()
    {
        if (dialogueSystem != null)
        {
            dialogueSystem.StartDialogue(dialogueLines);
        }
    }
}


