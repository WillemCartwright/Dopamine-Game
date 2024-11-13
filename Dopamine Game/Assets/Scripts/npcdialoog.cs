
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class npcdialoog : MonoBehaviour
{
    public List<string> dialogueLines; // Lijst van dialoogregels
    private DialogueSystem dialogueSystem;

    // UI elementen
    // UI-elementen om te wijzigen bij het starten van de dialoog
    public Text greenText;   // Tekstvak dat groen moet worden
    public Text whiteText;   // Tekstvak dat wit moet worden
    public Image activeImage; // Afbeelding die actief moet worden


    // Start is called before the first frame update
    void Start()
   {
        // Zoek het DialogueSystem-object in de scène
        dialogueSystem = FindObjectOfType<DialogueSystem>();

        // Verberg de afbeelding bij het starten van het spel
        if (activeImage != null)
        {
            activeImage.gameObject.SetActive(false);
        }
    }
    public void TriggerDialogue()
    {
        if (dialogueSystem != null)
        {
            // Stel de visuele elementen in
            SetUIElements();

            // Start de dialoog
            dialogueSystem.StartDialogue(dialogueLines);
        }
    }

    private void SetUIElements()
       {
        if (dialogueSystem != null)
        {
            // Start de dialoog
            dialogueSystem.StartDialogue(dialogueLines);

            // Pas de UI-elementen aan
            if (greenText != null)
            {
                // Zet de kleur van greenText naar groen (#5BFE59)
                greenText.color = new Color(0.36f, 0.996f, 0.349f); // Groen (hex #5BFE59)
            }

            if (whiteText != null)
            {
                // Zet de kleur van whiteText naar wit
                whiteText.color = Color.white;
            }

            if (activeImage != null)
            {
                // Zet de afbeelding actief (zichtbaar)
                activeImage.gameObject.SetActive(true);
            }
        }
    }
}
