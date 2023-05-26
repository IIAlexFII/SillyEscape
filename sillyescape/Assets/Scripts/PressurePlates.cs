using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlates : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject targetObject;  // The object that should be activated when the plate is pressed

    private bool isPressed = false;  // Flag to track if the plate is pressed

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HeavyObject")) //make sure the object has this tag
        {
            isPressed = true;
            ActivateTarget();
            print("Is Pressed");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("HeavyObject")) //make sure the object has this tag
        {
            isPressed = false;
            DeactivateTarget();
            print("Not Pressed");
        }
    }

    private void ActivateTarget()
    {
        targetObject.SetActive(true);  // Activate the target object when the plate is pressed
    }

    private void DeactivateTarget()
    {
        targetObject.SetActive(false);  // Deactivate the target object when the plate is released
    }
}
