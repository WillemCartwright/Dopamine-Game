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
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!isHoldingItem)
            {
                isHoldingItem = true;
                uiImage.gameObject.SetActive(true);
                item.GetComponent<Rigidbody>().useGravity = false;
                item.GetComponent<Rigidbody>().isKinematic = true;
                item.transform.position = guide.transform.position;
                item.transform.rotation = guide.transform.rotation;
                item.transform.parent = tempParent.transform;
            }
            else
            {
                isHoldingItem = false;
                uiImage.gameObject.SetActive(false);
                item.GetComponent<Rigidbody>().useGravity = true;
                item.GetComponent<Rigidbody>().isKinematic = false;
                item.transform.parent = null;
            }
        }

        if (isHoldingItem)
        {
            item.transform.position = guide.transform.position;
            item.transform.rotation = guide.transform.rotation;
        }
    }
}
