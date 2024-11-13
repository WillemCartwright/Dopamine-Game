using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectInteraction : MonoBehaviour
{
    public string objectName;
    public Sprite cursor;
    public UnityEvent interactFunction;

    public void OnInteract() {
      Debug.Log("Interacted with " + objectName);
      if (interactFunction != null)
        interactFunction.Invoke();
    }
}