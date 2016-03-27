using UnityEngine;
using System.Collections;

public class HarpoonTravel : MonoBehaviour {

	public float travelspeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3 (0, travelspeed, 0));
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Player")) {
			travelspeed = (float)0.5 * travelspeed;
		}
	}
}
