using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ShowImageOnProximity : MonoBehaviour
{
    public List<Transform> targetObjects;  // Lijst van objecten waar je dichtbij wilt komen
    public Image displayImage;             // De UI-afbeelding die wordt getoond
    public Image crosshairImage;           // De crosshair-afbeelding (UI-element)
    public float proximityDistance = 5f;   // Afstand waarop de afbeelding verschijnt
    public float maxAngle = 45f;           // Maximale kijkhoek om het handje te tonen

    private void Start()
    {
        displayImage.enabled = false;    // Verberg de proximity-afbeelding in het begin
        crosshairImage.enabled = true;   // Zorg dat de crosshair standaard zichtbaar is
    }

    private void Update()
    {
        bool isNearObject = false;

        // Doorloop alle target-objecten en kijk of de speler dichtbij is en naar het object kijkt
        foreach (Transform target in targetObjects)
        {
            // Bereken de afstand tussen de speler en het object
            float distance = Vector3.Distance(transform.position, target.position);

            // Kijk of de speler dichtbij genoeg is
            if (distance <= proximityDistance)
            {
                // Bereken de richting van de speler naar het object
                Vector3 directionToObject = target.position - transform.position;

                // Controleer of de speler naar het object kijkt
                float angle = Vector3.Angle(transform.forward, directionToObject);

                // Als de speler naar het object kijkt binnen de maxAngle, toon de afbeelding
                if (angle <= maxAngle)
                {
                    isNearObject = true;
                    break;  // Stop zodra we een object hebben gevonden dat binnen bereik is en waar we naar kijken
                }
            }
        }

        // Als we dichtbij en naar een object kijken, toon de proximity-afbeelding en verberg de crosshair
        if (isNearObject)
        {
            displayImage.enabled = true;      // Toon de proximity-afbeelding
            crosshairImage.enabled = false;   // Verberg de crosshair-afbeelding
        }
        else
        {
            displayImage.enabled = false;     // Verberg de proximity-afbeelding
            crosshairImage.enabled = true;    // Maak de crosshair weer zichtbaar
        }
    }
}

