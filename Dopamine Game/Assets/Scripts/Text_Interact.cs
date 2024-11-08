using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowInteractText : MonoBehaviour
{
    public Camera playerCamera;
    public Text interactText;
    public List<GameObject> interactableObjects; // Lijst met objecten om te interageren
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
            if (interactableObjects.Contains(hit.collider.gameObject))
            {
                interactText.text = "Press E to interact"; // Dit kun je uitbreiden per object
                interactText.enabled = true;

                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log($"Interactie gestart met {hit.collider.gameObject.name}!");
                    // Voeg object-specifieke interactielogica hier toe
                }
            }
            else
            {
                interactText.enabled = false;
            }
        }
        else
        {
            interactText.enabled = false;
        }
    }
}

