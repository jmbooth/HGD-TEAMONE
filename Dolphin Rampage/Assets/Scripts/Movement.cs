﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Movement : MonoBehaviour {

	public double playerSpeed;
	public double playerSpeedInAir;
	private Rigidbody2D playerBody;
	public float waterGrav;
	public float airGrav;
	public float speedToDestroyBoat;
	private bool inWater;
	private bool isDead = false;
	public Text distanceText;
	public Text scoreText;
	public Text endText;
	private int score;
	private int dist;
	private bool destroyed;
	private int distCtr;
	//public BoxCollider2D water;
	//private GameObject water = GameObject.Find ("Water");
	//public bool inWater;

	public GameObject sceneController;

	// Use this for initialization
	void Start () {
		playerBody = GetComponent<Rigidbody2D>();
		playerBody.gravityScale = airGrav;
		inWater = false;
		score = 0;
		dist = 0;
		setText ();
		destroyed = false;
		distCtr = 0;
	}
	
	// Update is called once per frame
	void Update () {
		//don't allow the player to move if the player is dead
		if (isDead) 
			return;
	

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

		if (distCtr == 60) {
			dist += 1;
			distCtr = 0;
		}
		distCtr++;
		setText ();

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
			score += 10;
		} else if (other.gameObject.CompareTag ("Boat")) {
			if (playerBody.velocity.magnitude >= speedToDestroyBoat) {
				Destroy (other.gameObject);
				score += 15;
			}
		} else if (other.gameObject.CompareTag ("Net")) {
			//Destroy (other.gameObject);
			netDeath ();
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.CompareTag ("Water")) {
			playerBody.gravityScale = airGrav;
			inWater = false;
		}
	}

	void netDeath(){
		//Destroy (GameObject.Find ("Player"));
		isDead = true;
		destroyed = true;
		setText ();

		//stop the player
		playerBody.velocity = Vector2.zero;
		playerBody.AddForce (new Vector2 ((float)playerSpeed,(float)playerSpeed));
		playerBody.gravityScale = 0;

		sceneController.GetComponent<FadeInAndOut> ().EndScene ("DeathScreen");
		//Application.LoadLevel("DeathScreen");
	}

	void setText(){
		if (!destroyed) {
			scoreText.text = "Score: " + score.ToString ();
			distanceText.text = "Distance: " + dist.ToString ();
			endText.text = "";
		} else {
			scoreText.text = "";
			distanceText.text = "";
			endText.text = "Final Score: " + score.ToString() + " Total Distance: " + dist.ToString();
		}
	}

}
