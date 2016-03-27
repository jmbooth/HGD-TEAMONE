using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Death_Stats : MonoBehaviour {

	public Text finalScore;
	public Text finalDist;

	// Use this for initialization
	void Start () {
		finalScore.text = "Final Score: " + Movement.score.ToString ();
        int textDist = (int)Movement.dist;
		finalDist.text = "Final Distance: " + textDist.ToString () + " ft";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
