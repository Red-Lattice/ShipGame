using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicScript : MonoBehaviour
{
    public StaticSceneLoader loader;
    public void OnFadeComplete() {
        TutorialChecker.tutorialRan = false;
        loader.BeginYapping();
    }
}
