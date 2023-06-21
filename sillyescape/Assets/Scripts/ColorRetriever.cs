using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorRetriever : MonoBehaviour
{
    public Color objectColor;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Renderer component from the object or its children
        Renderer objectRenderer = GetComponent<Renderer>();

        if (objectRenderer != null)
        {
            // Get the color of the object's material
            Color objectColor = objectRenderer.material.color;

            // Use the color as needed
            Debug.Log("Object color: " + objectColor);
        }
        else
        {
            Debug.Log("Object does not have a Renderer component.");
        }
    }
}
