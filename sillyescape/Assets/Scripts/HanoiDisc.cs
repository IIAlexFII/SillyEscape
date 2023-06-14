using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HanoiDisc : MonoBehaviour
{

    HanoiTowers tower;


    void Start()
    {
        tower = GameObject.Find("hanoi towers").GetComponent<HanoiTowers>();
        tower.Poles[0].Add(this as HanoiDisc);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!tower.IsSolved) {
            if (other.gameObject.name == "Pole 1" && !tower.Poles[0].Contains(this)) {
                tower.Poles[0].Add(this as HanoiDisc);
            }

            if (other.gameObject.name == "Pole 2" && !tower.Poles[1].Contains(this)) {
                tower.Poles[1].Add(this as HanoiDisc);
            }

            if (other.gameObject.name == "Pole 3" && !tower.Poles[2].Contains(this)) {
                tower.Poles[2].Add(this as HanoiDisc);
            }

            if (tower.Poles[2].Count == tower.discCount) tower.CompletePuzzle();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        {
            if (other.gameObject.name == "Pole 1" && tower.Poles[0].Contains(this)) {
                tower.Poles[0].Remove(this as HanoiDisc);
            }

            if (other.gameObject.name == "Pole 2" && tower.Poles[1].Contains(this)) {
                tower.Poles[1].Remove(this as HanoiDisc);
            }

            if (other.gameObject.name == "Pole 3" && tower.Poles[2].Contains(this)) {
                tower.Poles[2].Remove(this as HanoiDisc);
            }
        }

        Debug.Log($"OnTriggerExit triggered on {name}");
    }
}
