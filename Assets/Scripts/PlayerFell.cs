using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerFell : MonoBehaviour
{
    public string losingScene;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Catcher"))
        {
            SceneManager.LoadScene(losingScene);
        }
    }
}
