using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public double playerSpeed;
	public double playerSpeedInAir;
	private Rigidbody2D playerBody;
	public float waterGrav;
	public float airGrav;
	public float speedToDestroyBoat;
	private bool inWater;
	//public BoxCollider2D water;
	//private GameObject water = GameObject.Find ("Water");
	//public bool inWater;

	// Use this for initialization
	void Start () {
		playerBody = GetComponent<Rigidbody2D>();
		playerBody.gravityScale = airGrav;
		inWater = false;
	}
	
	// Update is called once per frame
	void Update () {
		double horizontal;
		double vertical;
		if (inWater) {
			horizontal = Input.GetAxis ("Horizontal") * playerSpeed;
			vertical = Input.GetAxis ("Vertical") * playerSpeed;
		} else {
			horizontal = Input.GetAxis ("Horizontal") * playerSpeedInAir;
			vertical = Input.GetAxis ("Vertical") * playerSpeedInAir;
		}
		playerBody.AddForce (new Vector2 ((float)horizontal, (float)vertical));

		//if (inWater) {
		//	body.gravityScale = .1f;
		//} else {
		//	body.gravityScale = 1f;
		//}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Water")) {
			playerBody.gravityScale = waterGrav;
			inWater = true;
		} else if (other.gameObject.CompareTag ("Fisherman")) {
			Destroy (other.gameObject);
		} else if (other.gameObject.CompareTag ("Boat")) {
			if (playerBody.velocity.magnitude >= speedToDestroyBoat) {
				Destroy (other.gameObject);
			}
		} else if (other.gameObject.CompareTag ("Net")) {
			Destroy (other.gameObject);
			damageTaken ();
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.CompareTag ("Water")) {
			playerBody.gravityScale = airGrav;
			inWater = false;
		}
	}

	void damageTaken(){
		Destroy (GameObject.Find ("Player"));
	}

}
