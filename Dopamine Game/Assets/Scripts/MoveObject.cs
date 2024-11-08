
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveObject : MonoBehaviour
{
    public GameObject item;            // Het object dat je wilt oppakken
    public GameObject tempParent;      // De tijdelijke parent (waar het object vastgehouden wordt)
    public Transform guide;            // Het punt waar het object wordt vastgehouden (bijvoorbeeld je hand)
    public Image uiImage;              // De afbeelding die verschijnt wanneer je het object oppakt
    public Image extraUIImage;         // De vink afbeelding die we willen tonen

    private bool isHoldingItem = false;
    private bool hasPickedUpItem = false; // Boolean om bij te houden of het item al is opgepakt

    void Start()
    {
        // Zet de graviteit aan voor het object bij het starten
        item.GetComponent<Rigidbody>().useGravity = true;
        
        // Zorg ervoor dat uiImage en extraUIImage niet zichtbaar zijn bij het starten
        uiImage.gameObject.SetActive(false); 
        extraUIImage.gameObject.SetActive(false); // Zet de vink afbeelding uit bij het starten
    }

    void Update()
    {
        // Als de speler de E-toets indrukt
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!isHoldingItem && CanPickUpItem())
            {
                // Oppakken van het object
                PickUpItem();
            }
            else if (isHoldingItem)
            {
                // Object loslaten
                DropItem();
            }
        }

        // Als het object wordt vastgehouden, blijf het bij de guide houden
        if (isHoldingItem)
        {
            item.transform.position = guide.transform.position;
            item.transform.rotation = guide.transform.rotation;
        }
    }

    // Methode voor het oppakken van het object
    private void PickUpItem()
    {
        isHoldingItem = true;

        // Toon de uiImage (alleen de afbeelding voor het object)
        uiImage.gameObject.SetActive(true);  

        // Toon de vink afbeelding (extraUIImage) **alleen** als het item voor het eerst wordt opgepakt
        if (!hasPickedUpItem)
        {
            extraUIImage.gameObject.SetActive(true);  // De vink afbeelding wordt zichtbaar
            hasPickedUpItem = true; // Markeer dat het item is opgepakt
        }

        // Zet de object fysica instellingen
        Rigidbody rb = item.GetComponent<Rigidbody>();
        rb.useGravity = false;    // Zet graviteit uit
        rb.isKinematic = true;    // Zet de kinematische waarde aan zodat de fysica niet meer het object beïnvloedt

        // Verplaats het object naar de guide (de positie waar je het wilt houden)
        item.transform.position = guide.position;
        item.transform.rotation = guide.rotation;

        // Maak het item een kind van de tempParent
        item.transform.parent = tempParent.transform;
    }

    // Methode voor het loslaten van het object
    private void DropItem()
    {
        isHoldingItem = false;
        
        // Verberg de uiImage (alleen de afbeelding voor het object)
        uiImage.gameObject.SetActive(false);  

        // Zet de object fysica instellingen terug
        Rigidbody rb = item.GetComponent<Rigidbody>();
        rb.useGravity = true;    // Zet graviteit weer aan
        rb.isKinematic = false;  // Zet de kinematica weer uit

        // Maak het object los van de tempParent
        item.transform.parent = null;
    }

    // Controleert of het object kan worden opgepakt (de speler kijkt naar het object)
    bool CanPickUpItem()
    {
        // Raycast vanuit het midden van het scherm (centraal gericht)
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        // Controleer of de raycast een object raakt
        if (Physics.Raycast(ray, out hit, 10f)) // Stel hier de max range in (10f is een voorbeeld)
        {
            // Als het object dat we raken hetzelfde is als het item, kan het opgepakt worden
            return hit.transform.gameObject == item;
        }
        return false;
    }
    
}
