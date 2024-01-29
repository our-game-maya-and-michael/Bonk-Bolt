using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoseGame : MonoBehaviour
{
    [SerializeField] string sceneName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Catcher")
        {
            SceneManager.LoadScene(sceneName);    // Input can either be a serial number or a name; here we use name.
        }
    }
}
