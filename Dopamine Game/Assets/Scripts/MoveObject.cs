using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public GameObject item;
    public GameObject tempParent;
    public Transform guide;

    private bool isHoldingItem = false;

    void Start()
    {
        item.GetComponent<Rigidbody>().useGravity = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            // P-toets ingedrukt: begin met het vasthouden van het object
            isHoldingItem = true;
            item.GetComponent<Rigidbody>().useGravity = false;
            item.GetComponent<Rigidbody>().isKinematic = true;
            item.transform.position = guide.transform.position;
            item.transform.rotation = guide.transform.rotation;
            item.transform.parent = tempParent.transform;
        }

        if (Input.GetKeyUp(KeyCode.P))
        {
            // P-toets losgelaten: laat het object los
            isHoldingItem = false;
            item.GetComponent<Rigidbody>().useGravity = true;
            item.GetComponent<Rigidbody>().isKinematic = false;
            item.transform.parent = null;
            item.transform.position = guide.transform.position;
        }
    }
}
