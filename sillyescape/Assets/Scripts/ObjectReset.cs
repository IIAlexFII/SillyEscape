using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectReset : MonoBehaviour
{
    public class Obj
    {
        public GameObject reference;
        public Transform position;
    }

    [SerializeField]
    private GameObject[] Interactables;

    public List<Obj> objs = new List<Obj>();

    private void Awake()
    {
        for (int i = 0; i < Interactables.Length; i++)
        {
            Obj temp = new Obj();
            {
                temp.reference = Interactables[i];
                temp.position = Interactables[i].transform;
            }
            objs.Add(temp);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("HeavyObject"))
        {
            Debug.Log("hand touch");
            Reset();
        }
    }

    private void Reset()
    {
        foreach (var objects in objs)
        {
            objects.reference.transform.position = objects.position.position;
            objects.reference.transform.rotation = objects.position.rotation;

            //objects.reference.transform.localScale = new Vector3(10,10,10);
        }

    }

}
