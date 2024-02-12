using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatingObject : MonoBehaviour
{
    [SerializeField] float beatSpeed = 5.0f; 
    [SerializeField] float beatScale = 0.3f; // Scale factor

    private Vector3 originalScale; // Original scale of the object

    // Start is called before the first frame update
    void Start()
    {
        originalScale = transform.localScale; // Store the original scale
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the scale factor using a sine wave
        float scale = 1 + Mathf.Sin(Time.time * beatSpeed) * beatScale;

        // Apply the scale to the object
        transform.localScale = originalScale * scale; // Multiply the original scale by the calculated factor
    }
}
