using UnityEngine;
using UnityEngine.UI;

public class ShowTextOnLook : MonoBehaviour
{
    public Text hintText;  // Sleep hier je Text-object naartoe in de Inspector
    public float detectionDistance = 5.0f;  // Afstand waarop de kleur van de tekst verandert
    public Transform playerCamera;  // Sleep hier de Camera van de speler naartoe in de Inspector

    private Color defaultColor = new Color32(0x28, 0x28, 0x28, 0xFF);  // Standaardkleur (#282828)
    private Color highlightColor = Color.white;  // Highlightkleur (#FFFFFF)

    private void Start()
    {
        hintText.color = defaultColor;  // Stel de standaardkleur in
        hintText.text = "Press [E] to interact";  // Stel standaardtekst in
        hintText.enabled = true;  // Zorg ervoor dat de tekst altijd zichtbaar is
    }

    private void Update()
    {
        // Controleer of dit object binnen de detectieafstand is
        float distanceToPlayer = Vector3.Distance(playerCamera.position, transform.position);

        if (distanceToPlayer <= detectionDistance)
        {
            // Voer een Raycast uit vanaf de camera naar dit object
            Ray ray = new Ray(playerCamera.position, playerCamera.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, detectionDistance))
            {
                if (hit.collider.gameObject == gameObject)  // Controleer of dit object geraakt wordt
                {
                    // Verander de tekstkleur naar wit als we naar dit object kijken en binnen bereik zijn
                    hintText.color = highlightColor;
                    return;
                }
            }
        }

        // Verander de tekstkleur terug naar de standaardkleur als we niet naar het object kijken of te ver zijn
        hintText.color = defaultColor;
    }
}
