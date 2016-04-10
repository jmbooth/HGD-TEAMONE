using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour {

    public Text distanceText;
    public Text scoreText;
    public Text powerUpText;

    // Use this for initialization
    void Start () {
        setText();
	}
	
	// Update is called once per frame
	void Update () {
        setText();
	}

    void setText()
    {
        if (!Movement.isDead)
        {
            scoreText.text = "Score: " + Movement.score.ToString();
            int textDist = (int) Movement.dist;
            distanceText.text = "Distance: " + textDist.ToString() + " ft";
            if (Movement.scoreMultiplier > 1)
            {
                powerUpText.text = "x2 Score: " + ((int)(Movement.powerUpTimer / 60) + 1).ToString();
            }
            else if (Movement.inBubble)
            {
                powerUpText.text = "Bubble Shield";
            }
            else {
                powerUpText.text = "";
            }
        }
        else {
            scoreText.text = "";
            distanceText.text = "";
            powerUpText.text = "";
        }
    }
}
