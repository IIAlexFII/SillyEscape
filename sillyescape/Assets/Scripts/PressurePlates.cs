using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlates : MonoBehaviour
{

    public GameObject[] targetObject;  // The object that should be activated when the plate is pressed

    [SerializeField]
    private bool isInverted;  // Flag to track if the plate is pressed

    private void Awake() {
        if(isInverted == true)
        {
            foreach (GameObject item in targetObject)
            {
                item.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HeavyObject")) //make sure the object has this tag
        {
            ActivateTarget();
            print("Is Pressed");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("HeavyObject")) //make sure the object has this tag
        {
            DeactivateTarget();
            print("Not Pressed");
        }
    }

    private void ActivateTarget()
    {
        // Activate the target object when the plate is pressed
        if (isInverted == false)
        {
            foreach (GameObject item in targetObject)
            {
                item.SetActive(false);
            }
        }
        else
        {
            foreach (GameObject item in targetObject)
            {
                item.SetActive(true);
            }
        }


    }


    private void DeactivateTarget()
    {
        // Deactivate the target object when the plate is released
        if (isInverted == false)
        {
            foreach (GameObject item in targetObject)
            {
                item.SetActive(true);
            }
        }
        else
        {
            foreach (GameObject item in targetObject)
            {
                item.SetActive(false);
            }
        }
    }
}
