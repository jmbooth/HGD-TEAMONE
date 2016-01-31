using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public double playerSpeed;
	private Rigidbody2D playerBody;
	public float waterGrav;
	public float airGrav;
	public bool inWater;
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
		if (inWater) {
			double horizontal = Input.GetAxis ("Horizontal") * playerSpeed;
			double vertical = Input.GetAxis ("Vertical") * playerSpeed;
			playerBody.AddForce (new Vector2 ((float)horizontal, (float)vertical));
		}

		//if (inWater) {
		//	body.gravityScale = .1f;
		//} else {
		//	body.gravityScale = 1f;
		//}
	}

	void OnTriggerEnter2D(Collider2D other){
		playerBody.gravityScale = waterGrav;
		inWater = true;
	}

	void OnTriggerExit2D(Collider2D other){
		playerBody.gravityScale = airGrav;
		inWater = false;
	}

}
