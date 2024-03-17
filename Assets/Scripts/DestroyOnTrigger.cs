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
    [SerializeField] GameObject timer = null;
    [Tooltip("The sound of being hit")]
    [SerializeField]
    public AudioClip hitClip;// Assign this in the inspector.
    public float volume = 0.3f;// Default volume level. Adjust this value between 0.0 and 1.0
    [Tooltip("The effect to show when hitting someone")]
    [SerializeField] GameObject hitEffectPrefab;// Assign this in the inspector.
    public Transform armTransform;// Assign this in the inspector to your arm's transform

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

    [System.Obsolete]
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == triggeringTag && animatorManager.animator.GetBool("isSlapping") && !other.GetComponent<RandomMovement>().GetCaught())
        {
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = hitClip;
            audioSource.loop = false;// Dont loop the hit sound
            audioSource.volume = volume;// Set the volume
            audioSource.Play();

            Instantiate(hitEffectPrefab, armTransform.position, armTransform.rotation);

            other.GetComponent<RandomMovement>().SetCaught();

            Transform arrow = other.transform.FindChild("Arrow");
            if (arrow != null)
            {
                arrow.gameObject.SetActive(false);
            }

            Transform caught = other.transform.FindChild("caught");
            if (caught != null)
            {
                caught.gameObject.SetActive(true);
            }
            triggeringCount--;
            Debug.Log(triggeringCount);

            if (triggeringCount == 0)
            {
                GetComponent<InputManager>().enabled = false;
                if (timer != null)
                {
                    timer.SetActive(false);

                }
                nextLevel.SetActive(true);
                Cursor.lockState = CursorLockMode.None;//Unlocks the cursor
                Cursor.visible = true;//Makes the cursor visible
            }
        }
    }

    private void Update()
    {
        playersLeftText.text = "Players left to catch: " + triggeringCount;
    }
}
