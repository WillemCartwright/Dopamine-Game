using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bloemenanimatie : MonoBehaviour
{
    // Definieer een Animator variabele
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        // Haal de Animator component op van dit object
        animator = GetComponent<Animator>();
    }

    // Methode om de animatie te triggeren
    public void Openen()
    {
        // Zet de trigger voor de animatie
        animator.SetTrigger("open");
    }
}
