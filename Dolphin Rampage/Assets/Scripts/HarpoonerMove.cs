using UnityEngine;
using System.Collections;

public class HarpoonerMove : MonoBehaviour {

	private Vector3 basePosition;
	public float swimRange;
	private bool up;
	public float swimRate;

	// Use this for initialization
	void Start () {
		basePosition = transform.position;
		swimRange = 0;
		up = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (up) {
			if (swimRange <= 2) {
				swimRange += swimRate;
			} else {
				up = false;
				swimRange -= swimRate;
			}
		} else {
			if (swimRange >= -2) {
				swimRange -= swimRate;
			} else {
				up = true;
				swimRange += swimRate;
			}
		}

		transform.position = new Vector3(basePosition.x, basePosition.y + swimRange, basePosition.z);
	}
}
