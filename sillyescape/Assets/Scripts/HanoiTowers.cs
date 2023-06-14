using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HanoiTowers : MonoBehaviour
{
    public int discCount = 5;
    
    public List<HanoiDisc>[] Poles { get; } = { new List<HanoiDisc>(), new List<HanoiDisc>(), new List<HanoiDisc>() };
    public bool IsSolved { get; private set; } = false;
    

    public void CompletePuzzle()
    {
        IsSolved = true;
        Debug.Log("Towers of Hanoi puzzle completed!");
    }
}
