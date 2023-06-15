using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HanoiTowers : MonoBehaviour
{
    public List<GameObject> discs;
    
    public Stack<GameObject>[] Poles { get; } = { new Stack<GameObject>(), new Stack<GameObject>(), new Stack<GameObject>() };
    public bool IsSolved { get; private set; } = false;

    public void OnPoleStateChange() {
        if (Poles[^1].Count == discs.Count) CompletePuzzle();
    }
    

    public void CompletePuzzle()
    {
        IsSolved = true;
        Debug.Log("Towers of Hanoi puzzle completed!");
    }

    public void ResetPuzzle()
    {
        Debug.Log("Here, the puzzle would reset");
    }
}
