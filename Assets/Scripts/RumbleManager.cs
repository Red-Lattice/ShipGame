using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RumbleManager : MonoBehaviour
{
    float pitch;
    public AudioSource rumblingAudio;

    void Start() {
        pitch = 1f;
    }

    void Update() {
        UpdatePitch();
        rumblingAudio.pitch = pitch;
    }

    void UpdatePitch() {
        pitch += Input.GetMouseButton(1) ? Time.deltaTime : -Time.deltaTime;
        pitch = Mathf.Clamp(pitch, 1f, 2f);
    }
}
