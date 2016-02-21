using UnityEngine;
using System.Collections;

public class HarpoonTravel : MonoBehaviour {

	public float travelspeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3 (-travelspeed, 0, 0));
	}
}
