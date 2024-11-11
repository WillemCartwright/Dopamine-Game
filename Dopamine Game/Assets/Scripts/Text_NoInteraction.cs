using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowInteractTextAlternative : MonoBehaviour
{
    public Camera playerCamera;
    public Text interactText;
    public List<InteractableObject> interactableObjects; // Lijst met objecten om te interageren
    public float maxDistance = 5f;

    private void Start()
    {
        interactText.enabled = false;
    }

    private void Update()
    {
        // Cast een ray vanuit de camera
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        // Check of de ray een object in de lijst raakt binnen de afstand
        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            foreach (var interactable in interactableObjects)
            {
                if (hit.collider.gameObject == interactable.gameObject)
                {
                    interactText.text = interactable.interactionText; // Toon de specifieke tekst voor dit object
                    interactText.enabled = true;

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Debug.Log($"Interactie gestart met {hit.collider.gameObject.name}!");
                        // Voeg object-specifieke interactielogica hier toe
                    }
                    return;
                }
            }
            interactText.enabled = false; // Verberg tekst als het geen interactief object is
        }
        else
        {
            interactText.enabled = false;
        }
    }
}

[System.Serializable]
public class InteractableObject
{
    public GameObject gameObject;
    public string interactionText; // De specifieke tekst voor dit object
}



