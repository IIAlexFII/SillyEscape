using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HanoiTowersDebug : MonoBehaviour
{

    public TextMeshProUGUI text;
    public HanoiTowers tower;


    // Update is called once per frame
    void Update()
    {
        text.SetText($"{tower.Poles[0].Count} {tower.Poles[1].Count} {tower.Poles[2].Count}");
    }
}
