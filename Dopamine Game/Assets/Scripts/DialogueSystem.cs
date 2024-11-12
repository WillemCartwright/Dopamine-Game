using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public GameObject dialoguePanel; // Panel voor dialoog
    public Text npcText; // Text element voor NPC
    public Text playerText; // Text element voor speler
    public Button nextButton; // Knop om de dialoog door te gaan

    private Queue<string> sentences; // Wachtrij voor zinnen
    private bool isPlayerTurn; // Boolean om te checken wiens beurt het is

    void Start()
    {
        sentences = new Queue<string>();
        dialoguePanel.SetActive(false); // Start met dialoog uit
        nextButton.onClick.AddListener(DisplayNextSentence);
    }

    public void StartDialogue(List<string> dialogueLines)
    {
        dialoguePanel.SetActive(true);
        sentences.Clear();
        isPlayerTurn = false;

        foreach (string sentence in dialogueLines)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        if (isPlayerTurn)
        {
            playerText.text = sentence;
            npcText.text = "";
        }
        else
        {
            npcText.text = sentence;
            playerText.text = "";
        }
        isPlayerTurn = !isPlayerTurn;
    }

    void EndDialogue()
    {
        dialoguePanel.SetActive(false);
    }
}
