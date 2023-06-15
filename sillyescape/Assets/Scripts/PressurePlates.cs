using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlates : MonoBehaviour
{

    public GameObject[] targetObject; // The object that should be activated when the plate is pressed

    public Transform startingPosition; // This is the position in which the target object starts so that once the pressure
                                       // plate stopes being pressed it would go back to his original position

    public Transform targetPosition; // This position is to where the target object will slide to

    public float slidingSpeed = 35f; // This is the speed at which the target object is going to move if isSliding is true

    public Color requiredColor; // This is the color that the heavy object needs to have to activate the pressure plate

    [SerializeField]
    private bool isInverted; // Flag to track if the plate is pressed

    [SerializeField]
    private bool isSlidding; // If true the object will slide instead of just disappear

    private void Awake()
    {
        requiredColor = GetComponent<MeshRenderer>().material.color;

        if (isInverted == true)
        {
            foreach (GameObject item in targetObject)
            {
                item.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HeavyObject")) // Make sure the object has this tag
        {
            ColorRetriever heavyObject = other.GetComponent<ColorRetriever>();
            if (heavyObject != null && heavyObject.objectColor == requiredColor)
            {
                ActivateTarget();
                print("Is Pressed");
            }
            else
            {
                print("Wrong Color");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("HeavyObject")) //make sure the object has this tag
        {
            ColorRetriever heavyObject = other.GetComponent<ColorRetriever>();
            if (heavyObject != null && heavyObject.objectColor == requiredColor)
            {
                DeactivateTarget();
                print("Not Pressed");
            }
            else 
            {
                print("The color was incorrect");
            }
        }
    }

    private void ActivateTarget()
    {
        // Activate the target object when the plate is pressed
        if (isInverted == false)
        {
            if (isSlidding == true)
            {
                foreach (GameObject item in targetObject)
                {
                    float step = slidingSpeed * Time.deltaTime;
                    item.transform.position = Vector3.MoveTowards(targetPosition.position, targetPosition.position, step);
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
        else
        {
            if (isSlidding == true)
            {
                foreach (GameObject item in targetObject)
                {
                    float step = slidingSpeed * Time.deltaTime;
                    item.transform.position = Vector3.MoveTowards(startingPosition.position, startingPosition.position, step);
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
    }

    private void DeactivateTarget()
    {
        // Deactivate the target object when the plate is released
        if (isInverted == false)
        {
            if (isSlidding == true)
            {
                foreach (GameObject item in targetObject)
                {
                    float step = slidingSpeed * Time.deltaTime;
                    item.transform.position = Vector3.MoveTowards(startingPosition.position, startingPosition.position, step);
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
        else
        {
            if (isSlidding == true)
            {
                foreach (GameObject item in targetObject)
                {
                    float step = slidingSpeed * Time.deltaTime;
                    item.transform.position = Vector3.MoveTowards(targetPosition.position, targetPosition.position, step);
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
}