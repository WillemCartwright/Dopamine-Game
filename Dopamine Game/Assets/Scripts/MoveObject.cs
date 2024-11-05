using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveObject : MonoBehaviour
{
    public GameObject item;
    public GameObject tempParent;
    public Transform guide;
    public Image uiImage;

    private bool isHoldingItem = false;

    void Start()
    {
        item.GetComponent<Rigidbody>().useGravity = true;
        uiImage.gameObject.SetActive(false); // Verberg de afbeelding bij het starten van de game
    }

    void Update()
    {
        // Check of de P-toets wordt ingedrukt
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!isHoldingItem && CanPickUpItem())
            {
                // Object oppakken
                isHoldingItem = true;
                uiImage.gameObject.SetActive(true);
                item.GetComponent<Rigidbody>().useGravity = false;
                item.GetComponent<Rigidbody>().isKinematic = true;
                item.transform.position = guide.transform.position;
                item.transform.rotation = guide.transform.rotation;
                item.transform.parent = tempParent.transform;
            }
            else if (isHoldingItem)
            {
                // Object loslaten
                isHoldingItem = false;
                uiImage.gameObject.SetActive(false);
                item.GetComponent<Rigidbody>().useGravity = true;
                item.GetComponent<Rigidbody>().isKinematic = false;
                item.transform.parent = null;
            }
        }

        // Houdt het object op de juiste positie als het wordt vastgehouden
        if (isHoldingItem)
        {
            item.transform.position = guide.transform.position;
            item.transform.rotation = guide.transform.rotation;
        }
    }

    // Controleert of de speler naar het object kijkt
    bool CanPickUpItem()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            return hit.transform.gameObject == item;
        }
        return false;
    }
}
