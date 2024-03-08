using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public TextMeshProUGUI txtObject;
    public string txt;
    public Animator waveCompAnim;

    void Start() {
    }

    // Update is called once per frame
    void Update()
    {
        if (Overwatch.Instance.GameWonCheck()) {
            // Play cool animation
            waveCompAnim.Play("WaveComplete");
        }
        txt = "Killed Targets: " + Overwatch.Instance.destroyedAsteroids.ToString() + "/" + Overwatch.Instance.neededAsteroids;
        txtObject.text = txt;
    }
    public void InitNexWave() {
        Overwatch.Instance.StartNewWave();
    }
}
