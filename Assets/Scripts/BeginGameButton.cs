using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BeginGameButton : MonoBehaviour
{
    public Animator cinematicAnimator;
    public void BeginGameButtonPressed() {
        cinematicAnimator.Play("FadeOut");
    }
}
