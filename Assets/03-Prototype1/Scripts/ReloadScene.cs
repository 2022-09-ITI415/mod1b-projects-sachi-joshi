using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ReloadScene : MonoBehaviour
{
    
    void onTriggerEnter(Collider col) {
        if (col.CompareTag("player")) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
