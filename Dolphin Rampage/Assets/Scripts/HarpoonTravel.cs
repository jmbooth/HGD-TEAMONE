using UnityEngine;
using System.Collections;

public class HarpoonTravel : MonoBehaviour {

	public float travelspeed;

	// Zac's recently added stuff
	private Vector2 offset;
	private GameObject player;
	private bool stuck;

	// Use this for initialization
	void Start () {
		offset = new Vector2 (0, 0);
		stuck = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (stuck) {
			float tempX = player.transform.position.x + offset.x;
			float tempY = player.transform.position.y + offset.y;
			transform.position = new Vector2 (tempX, tempY);
		} else {
			transform.Translate (new Vector3 (0, travelspeed, 0));
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Player")) {
			player = other.gameObject;
			float tempX = transform.position.x - player.transform.position.x;
			float tempY = transform.position.y - player.transform.position.y;
			offset = new Vector2 (tempX, tempY);
			stuck = true;
		}
		else if(other.gameObject.CompareTag("Harpooner"))
			Destroy(other.gameObject);	
	}
}
