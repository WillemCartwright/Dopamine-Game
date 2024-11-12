using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterLuxis : MonoBehaviour
{
    void OnTriggerEnter() {
        SceneManager.LoadScene("Shop", LoadSceneMode.Single);
    }

}
