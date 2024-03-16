using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering;

public class DestroyOnTrigger : MonoBehaviour
{
    public TextMeshProUGUI playersLeftText;
    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] string triggeringTag;

    [Tooltip("Number of players to catch in this level")]
    [SerializeField]
    public int triggeringCount;

    [Tooltip("next level")]
    [SerializeField] GameObject nextLevel;
    [SerializeField] GameObject enemies;

    [Tooltip("The sound of being hit")]
    [SerializeField]
    public AudioClip hitClip; // Assign this in the inspector.
    public float volume = 0.3f; // Default volume level. Adjust this value between 0.0 and 1.0 

    private PlayerLocomotion playerLocomotion;
    private InputManager inputManager;
    private AnimatorManager animatorManager;
    private RandomMovement otherGuy;

    private void Awake()
    {
        animatorManager = GetComponent<AnimatorManager>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
        inputManager = GetComponent<InputManager>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == triggeringTag && animatorManager.animator.GetBool("isSlapping") && !other.GetComponent<RandomMovement>().GetCaught())
        {
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = hitClip;
            audioSource.loop = false; // Dont loop the hit sound
            audioSource.volume = volume; // Set the volume
            audioSource.Play();

            other.GetComponent<RandomMovement>().SetCaught();
            triggeringCount--;
            Debug.Log(triggeringCount);

            if (triggeringCount == 0)
            {
                GetComponent<InputManager>().enabled = false;
                enemies.SetActive(false);
                nextLevel.SetActive(true);
            }
        }
    }

    private void Update()
    {
        playersLeftText.text = "Players left to catch: " + triggeringCount;
    }
}
