using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloemenautomaat : MonoBehaviour
{
    // Deze functie wordt aangeroepen wanneer je op het object klikt
    void OnMouseDown()
    {
        // Verberg het object
        gameObject.SetActive(false);
    }
}
