using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class DestroyOnTrigger : MonoBehaviour
{
    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] string triggeringTag;

    [Tooltip("Number of players to catch in this level")]
    [SerializeField]
    int triggeringCount;

    [Tooltip("next scene")]
    [SerializeField]
    string nextScene;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == triggeringTag)
        {
            triggeringCount--;
            Destroy(other.gameObject);
            if (triggeringCount == 0)
            {
                SceneManager.LoadScene(nextScene);
            }
        }
    }

    private void Update()
    {
        /* Just to show the enabled checkbox in Editor */
    }
}
