using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deur : MonoBehaviour
{     private Animator animator;  // Animator voor de deur
 void Start() 
    {
        animator = GetComponent<Animator>();  // Haal de Animator component op
    }

    public void Openen() 
    {
            animator.SetTrigger("open");  // Zet de trigger om de deur te openen
       
    }
    
 
}
