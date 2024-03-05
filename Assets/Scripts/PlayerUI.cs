using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public TextMeshProUGUI txtObject;
    public string txt;

    void Start() {
        Overwatch.GameStart();
    }

    // Update is called once per frame
    void Update()
    {
        txt = "Killed Targets: " + Overwatch.destroyedAsteroids.ToString() + "/" + Overwatch.neededAsteroids;
        txtObject.text = txt;
    }
}
