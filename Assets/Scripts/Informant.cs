using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Informant : MonoBehaviour
{
    public PlayerUI playerUI;
    public void AnimComplete() {
        playerUI.InitNexWave();
    }
}
