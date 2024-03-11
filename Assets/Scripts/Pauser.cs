using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pauser : MonoBehaviour
{
    public bool paused = false;
    public Animator pauseScreenAnimator;
    public Canvas canvas;
    public Canvas regularHud;
    public AudioSource rumble;
    // Start is called before the first frame update
    void Start()
    {
        paused = false;
        canvas.enabled = false;
        regularHud.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Pause();
        }
    }

    public void Pause() {
        Time.timeScale = paused ? 1f : 0f;
            rumble.enabled = paused;
            paused = !paused;
            Cursor.lockState = paused ? CursorLockMode.None : CursorLockMode.Locked;
            Cursor.visible = paused;
            canvas.enabled = paused;
            regularHud.enabled = !paused;
            if (paused) {
                pauseScreenAnimator.Play("PauseScreen");
            } else {
                pauseScreenAnimator.Play("Empty");
            }
    }
}
