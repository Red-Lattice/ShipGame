using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairIcon : MonoBehaviour
{
    public Material mat;

    void Start() {
        mat.renderQueue = 4000;
    }

    // Update is called once per frame
    /*void Update()
    {
        transform.position = grabbyPoint.forward * 5f;
    }*/
}
