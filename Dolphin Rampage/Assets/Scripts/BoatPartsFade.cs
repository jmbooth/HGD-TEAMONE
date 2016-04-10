using UnityEngine;
using System.Collections;

public class BoatPartsFade : MonoBehaviour {

	int timecount;

	// Use this for initialization
	void Start () {
		timecount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (timecount++ >= 30) {
			Destroy (GetComponent<PolygonCollider2D> ());
			Destroy (GetComponent<Rigidbody> ());
		}
		if (timecount++ >= 1200) {
			Destroy (gameObject);
		}
	}
}
