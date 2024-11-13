using System.Collections;
using System.Collections.Generic; // Voeg deze regel toe
using UnityEngine;
using UnityEngine.UI;

public class NPCDialogue : MonoBehaviour
{
    public List<string> dialogueLines; // Lijst van dialoogregels voor deze NPC
    private DialogueSystem dialogueSystem;

    // UI-elementen om te wijzigen bij het starten van de dialoog
    public Text greenText;   // Tekstvak dat groen moet worden
    public Text whiteText;   // Tekstvak dat wit moet worden
    public Image activeImage; // Afbeelding die actief moet worden
    public Image extraImage;  // Extra afbeelding die zichtbaar moet worden
    public Image inactiveImage; // Afbeelding die inactief moet worden

    // UI-element voor het tekstvak dat getoond moet worden
    public Text temporaryText;  // Tekstvak dat tijdelijk in beeld komt

    void Start()
    {
        // Zoek het DialogueSystem-object in de scène
        dialogueSystem = FindObjectOfType<DialogueSystem>();

        // Verberg de afbeeldingen bij het starten van het spel
        if (activeImage != null)
        {
            activeImage.gameObject.SetActive(false);
        }

        if (extraImage != null)
        {
            extraImage.gameObject.SetActive(false);
        }

        if (inactiveImage != null)
        {
            inactiveImage.gameObject.SetActive(false);
        }

        // Verberg de tijdelijke tekst bij het starten van het spel
        if (temporaryText != null)
        {
            temporaryText.gameObject.SetActive(false);
        }
    }

    public void TriggerDialogue()
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

            if (extraImage != null)
            {
                // Zet de extra afbeelding actief (zichtbaar)
                extraImage.gameObject.SetActive(true);
            }

            if (inactiveImage != null)
            {
                // Zet de inactieve afbeelding uit (onzichtbaar)
                inactiveImage.gameObject.SetActive(false);
            }

            // Toon tijdelijke tekst voor 8 seconden
            if (temporaryText != null)
            {
                StartCoroutine(ShowTemporaryText());
            }
        }
    }

    // Coroutine voor het tonen van tijdelijke tekst
    private IEnumerator ShowTemporaryText()
    {
        temporaryText.gameObject.SetActive(true);
        yield return new WaitForSeconds(8f); // Wacht 8 seconden
        temporaryText.gameObject.SetActive(false); // Verberg de tekst
    }
}
