using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public double playerSpeed;
	public Rigidbody2D body;
	//public BoxCollider2D water;
	//private GameObject water = GameObject.Find ("Water");
	//public bool inWater;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		double horizontal = Input.GetAxis ("Horizontal") * playerSpeed;
		double vertical = Input.GetAxis ("Vertical") * playerSpeed;
		body.AddForce (new Vector2 ((float)horizontal, (float)vertical));

		//if (inWater) {
		//	body.gravityScale = .1f;
		//} else {
		//	body.gravityScale = 1f;
		//}
	}

	void OnTriggerEnter2D(Collider2D other){
		body.gravityScale = .5f;

	}

	void OnTriggerExit2D(Collider2D other){
		body.gravityScale = 1f;
	}

}
