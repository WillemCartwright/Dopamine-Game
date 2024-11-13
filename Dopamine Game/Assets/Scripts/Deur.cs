using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deur : MonoBehaviour
{
    private Animator animator;  // Animator voor de deur
    private AudioSource audioSource;  // AudioSource voor het geluid

    public AudioClip deurGeluid;  // Het geluid dat afgespeeld moet worden

    void Start()
    {
        animator = GetComponent<Animator>();  // Haal de Animator component op
        audioSource = GetComponent<AudioSource>();  // Haal de AudioSource component op
    }

   

    public void Openen()
    {
        animator.SetTrigger("open");  // Zet de trigger om de deur te openen
         if (audioSource != null && deurGeluid != null)
        {
            audioSource.PlayOneShot(deurGeluid);
        }
    }
}