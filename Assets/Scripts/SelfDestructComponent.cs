using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructComponent : MonoBehaviour
{
    public bool timer;
    public float timeToDestroy = 3f;
    public void SelfDestruct() {
        Destroy(transform.gameObject);
    }

    void Update() {
        if (!timer) {return;}
        timeToDestroy -= Time.deltaTime;
        if (timeToDestroy <= 0f) {SelfDestruct();}
    }
}
