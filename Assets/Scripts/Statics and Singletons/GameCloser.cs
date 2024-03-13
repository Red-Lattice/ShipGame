using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCloser : MonoBehaviour
{
    public void QuitGame() {
        //Shamelessly stolen code from some guy on StackOverflow
        #if UNITY_STANDALONE
            Application.Quit();
        #elif UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
