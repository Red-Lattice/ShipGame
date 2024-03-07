using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Don't ask
/// </summary>
public class StaticSceneLoader : MonoBehaviour
{
    public void LoadGame() {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
}
