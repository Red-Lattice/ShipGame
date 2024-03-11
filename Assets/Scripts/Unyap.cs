using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unyap : MonoBehaviour
{
    public StaticSceneLoader staticSceneLoader;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) {
            Unyapping();
        }
    }

    public void Unyapping() {
        staticSceneLoader.LoadGame();
    }
}
