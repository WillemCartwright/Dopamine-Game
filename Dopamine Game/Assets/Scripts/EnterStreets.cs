using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterStreets : MonoBehaviour
{
    void OnTriggerEnter() {
        SceneManager.LoadScene("streetdeel2", LoadSceneMode.Single);
    }

}