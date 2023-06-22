using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HanoiPole : MonoBehaviour
{
    public int poleNumber;
    
    HanoiTowers tower;

    // Start is called before the first frame update
    void Start()
    {
        tower = GetComponentInParent<HanoiTowers>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!tower.IsSolved && other.gameObject.tag == "HanoiDisc") {

            if (tower.Poles[poleNumber].Count > 0 && GetDiscSize(tower.Poles[poleNumber].Peek()) > GetDiscSize(other.gameObject))
                tower.ResetPuzzle();

            if (!tower.Poles[poleNumber].Contains(other.gameObject)) {
                tower.Poles[poleNumber].Push(other.gameObject);
            }

            if (tower.Poles[^1].Count == tower.discs.Count) tower.CompletePuzzle();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!tower.IsSolved && other.gameObject.tag == "HanoiDisc") {
            if (tower.Poles[poleNumber].Contains(other.gameObject) && tower.Poles[poleNumber].Peek() == other.gameObject)
            {
                tower.Poles[poleNumber].Pop();
            }
        }

        Debug.Log($"OnTriggerExit triggered on {name}");
    }

    private int GetDiscSize(GameObject obj)
    {
        string[] result = obj.name.Split(' ');

        if (obj.gameObject.tag != "HanoiDisc") Debug.LogError("Tried to return disc size of an object that is not a towers of hanoi disc");

        return int.Parse(result[^1]);
    }
}
