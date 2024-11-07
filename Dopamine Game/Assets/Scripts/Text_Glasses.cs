using UnityEngine;
using UnityEngine.UI;

public class ShowTextOnLook : MonoBehaviour
{
    public Text hintText;  // Sleep hier je Text-object naartoe in de Inspector
    public float detectionDistance = 5.0f;  // Afstand waarop de tekst verschijnt
    public Transform playerCamera;  // Sleep hier de Camera van de speler naartoe in de Inspector
    public GameObject targetObject; // Het object waar je naar kijkt

    private void Start()
    {
        hintText.enabled = false;  // Zorg ervoor dat de tekst standaard niet zichtbaar is
    }

    private void Update()
    {
        // Controleer of het object binnen de detectie-afstand is
        float distanceToTarget = Vector3.Distance(playerCamera.position, targetObject.transform.position);

        if (distanceToTarget <= detectionDistance)
        {
            // Voer een Raycast uit vanaf de camera naar het object
            Ray ray = new Ray(playerCamera.position, playerCamera.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, detectionDistance))
            {
                if (hit.collider.gameObject == targetObject)
                {
                    // Toon de tekst als we naar het object kijken en binnen bereik zijn
                    hintText.text = "Press E to pick up object";
                    hintText.enabled = true;
                    return;  // Stop de rest van de code zodat de tekst niet uitgeschakeld wordt in dezelfde frame
                }
            }
        }

        // Verberg de tekst als we te ver zijn of niet naar het object kijken
        hintText.enabled = false;
    }
}

