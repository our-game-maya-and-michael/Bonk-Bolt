using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerFell : MonoBehaviour
{
    [SerializeField] GameObject playerFellMenu;


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Catcher"))
        {
            playerFellMenu.SetActive(true);
        }
    }
}
