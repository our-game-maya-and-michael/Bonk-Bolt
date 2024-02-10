using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DestroyOnTrigger : MonoBehaviour
{
    public Text playersLeftText;
    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] string triggeringTag;

    [Tooltip("Number of players to catch in this level")]
    [SerializeField]
    public int triggeringCount;

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
        playersLeftText.text = "Players left to catch: " + triggeringCount;
    }
}
