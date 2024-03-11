using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SensitivitySlider : MonoBehaviour
{
    private Slider slider;
    void Awake() {
        slider = GetComponent<Slider>();
    }
    public void ValueChanged() {
        GameSettings.sensitivity = slider.value;
    }
}
