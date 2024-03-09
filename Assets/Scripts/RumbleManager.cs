using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RumbleManager : MonoBehaviour
{
    float pitch;
    public AudioSource rumblingAudio;
    private bool deactivated;

    void Start() {
        pitch = 1f;
        deactivated = false;
    }

    void Update() {
        if (deactivated) {return;}
        UpdatePitch();
        rumblingAudio.pitch = pitch;
    }

    void UpdatePitch() {
        pitch += Input.GetMouseButton(1) ? Time.deltaTime : -Time.deltaTime;
        pitch = Mathf.Clamp(pitch, 1f, 2f);
    }

    public void Stop() {
        rumblingAudio.enabled = false;
        deactivated = true;
    }
}
