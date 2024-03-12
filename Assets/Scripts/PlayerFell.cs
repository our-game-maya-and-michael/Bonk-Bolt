using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerFell : MonoBehaviour
{
    [SerializeField] GameObject playerFellMenu;

    [SerializeField] GameObject player;
    [SerializeField] GameObject enemies;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Catcher"))
        {
            player.GetComponent<InputManager>().enabled = false;
            enemies.SetActive(false);
            playerFellMenu.SetActive(true);
        }
    }
}
