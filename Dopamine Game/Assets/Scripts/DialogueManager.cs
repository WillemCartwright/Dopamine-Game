using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    // Dialoogzinnen voor de NPC en de speler
    private string[] npcDialogue = { 
        "Wat heb je daar toch op je hoofd, kind? Zo’n… ding voor je ogen?",
        "En wat moet je daarmee? Je kunt toch gewoon om je heen kijken?",
        "Maar waarom zou je dat willen? De echte wereld is toch ook mooi?",
        "Vroeger gingen we gewoon naar buiten. Wandelingetje, praatje maken met de buren. Dat was genoeg belevenis, hoor.",
        "Nou, daar snap ik niks van. Wat is het leven nog waard als je geen echte mensen meer spreekt?",
        "Makkelijk? Misschien. Maar écht leven… dat is het toch niet."
    };

    private string[] playerDialogue = { 
        "Een VR-bril, mevrouw.",
        "Nou, hiermee kan ik in een andere wereld stappen, mevrouw. Even weg van alles.",
        "Mensen vinden het leuk om dingen te beleven die ze in het echt niet kunnen.",
        "Ja, maar nu gaat alles digitaal. Mensen zien elkaar bijna niet meer.",
        "Sommigen vinden het makkelijker zo, denk ik."
    };

    public GameObject dialogueUI; // UI die de dialoog toont
    public Text dialogueText; // Tekst waar de dialoog op komt
    public Button endButton; // De button die de dialoog beëindigt

    private int dialogueIndex = 0; // Huidige positie in het gesprek
    private bool isTalking = false; // Controleren of er een gesprek gaande is

    public void StartDialogue()
    {
        if (!isTalking) // Checken of er al een gesprek gaande is
        {
            isTalking = true;
            dialogueIndex = 0;
            dialogueUI.SetActive(true); // UI zichtbaar maken
            endButton.gameObject.SetActive(false); // Verberg de knop in het begin
            ShowNextDialogue(); // Eerste zin tonen
        }
    }

    public void ShowNextDialogue()
    {
        // Check of er nog dialoog is om weer te geven
        if (dialogueIndex < npcDialogue.Length + playerDialogue.Length)
        {
            if (dialogueIndex % 2 == 0) // NPC's beurt (even indexen)
            {
                dialogueText.text = npcDialogue[dialogueIndex / 2];
                dialogueText.color = Color.blue; // Stel de kleur in op blauw voor de NPC
            }
            else // Speler's beurt (oneven indexen)
            {
                dialogueText.text = playerDialogue[dialogueIndex / 2];
                dialogueText.color = Color.green; // Stel de kleur in op groen voor de speler
            }
            dialogueIndex++;
        }
        else
        {
            // Wanneer we de laatste zin hebben bereikt, tonen we de knop
            endButton.gameObject.SetActive(true); // Maak de button zichtbaar
        }
    }

    private void EndDialogue()
    {
        isTalking = false;
        dialogueUI.SetActive(false); // UI verbergen
    }

    public void OnEndButtonClick()
    {
        EndDialogue(); // Stop de dialoog wanneer de speler op de knop drukt
    }

    void Update()
    {
        if (isTalking && Input.GetKeyDown(KeyCode.E)) // Wacht op de E-toets om verder te gaan
        {
            ShowNextDialogue(); // Toon de volgende zin in het gesprek
        }
    }
}
