using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinalScoreShower : MonoBehaviour
{
    public TextMeshProUGUI text;
    void Update() {
        string submission = "Ships Killed: " + Overwatch.Instance.totalDestroyed +
            "\nWaves Completed: " + Overwatch.Instance.totalWaves;
        text.text = submission;
    }
}
