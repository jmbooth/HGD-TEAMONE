using UnityEngine;
using System.Collections;
using System;

public class MineFloat : MonoBehaviour {

	private Vector3 basePosition;
	private float floatPos;
	public float floatRange;
	private bool up;
	public float floatRate;

	// Use this for initialization
	void Start () {
		basePosition = transform.position;
		floatPos = 0;
		up = false;
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 lastposition = transform.position;

		if (up) {
			if (floatPos <= floatRange) {
				floatPos += (Math.Min((floatRange - floatPos), (floatRange + floatPos)) / 64f) + .005f;
			} else {
				up = false;
			}
		} else {
			if (floatPos >= -floatRange) {
				floatPos -= (Math.Min((floatRange - floatPos), (floatRange + floatPos)) / 64f) + .005f;
			} else {
				up = true;
			}
		}

		transform.position = new Vector3 (lastposition.x, basePosition.y + floatPos, basePosition.z);
	}
}
