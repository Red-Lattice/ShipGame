using UnityEngine;
using TMPro;

public class IntroText : MonoBehaviour
{
    public TextMeshProUGUI tmp;

    private static string fullText = "Hello and welcome to your first day on the job at Erandise Mining Co.\n\nWe would like to apologize for the unusual circumstances presenting itself at the current moment. One of our projects included extracting matter from a singularity, and a strange alien race found that to be unacceptable and in violation of the laws of physics.\n\nUnfortunately your ship is not equipped with weaponry, but what you will be doing is fending them off by using your built in Matter Grabbers™.\n\nRemember that we are a family here at Erandise Mining Co. Thank you for your cooperation.";

    public char[] charray;
    public string displayingText = "";
    public Animator overallAnimator;
    // Start is called before the first frame update
    void Start()
    {
        tmp.text = "";
        charray = fullText.ToCharArray();
    }

    // Update is called once per frame
    void Update()
    {
        tmp.text = displayingText;
    }

    void FixedUpdate() {
        if (displayingText == fullText) {return;}
        displayingText += charray[displayingText.Length]; //Lol
        if (displayingText == fullText) {overallAnimator.Play("EndYapping");}
    }
}
