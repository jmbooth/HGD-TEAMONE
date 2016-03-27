﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Movement : MonoBehaviour {

	public double playerSpeed;
	public double playerSpeedInAir;
	public double PlayerMaxSpeed = 10;
	private Rigidbody2D playerBody;
	public float waterGrav;
	public float airGrav;
	public float speedToDestroyBoat;
	private bool inWater;
	private bool isDead = false;
	public Text distanceText;
	public Text scoreText;
	public static int score;
    public static float dist;
    private Vector3 dolphPos;
    private int scoreMultiplier;
    private int powerUpTimer;
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
        dolphPos = transform.position;
        setText ();
        scoreMultiplier = 1;
	}
	
	// Update is called once per frame
	void Update () {
		//don't allow the player to move if the player is dead
		if (isDead) 
			return;
	
		//rotate the dolphin based on user input
		Vector3 temp = transform.rotation.eulerAngles;
		temp.z = 0.0f;
		transform.rotation = Quaternion.Euler (temp);

		if (Input.GetAxis ("Vertical") > 0) {
			temp = transform.rotation.eulerAngles;
			temp.z = 30.0f;
			transform.rotation = Quaternion.Euler (temp);
		} else if (Input.GetAxis ("Vertical") < 0) {
			temp = transform.rotation.eulerAngles;
			temp.z = -30.0f;
			transform.rotation = Quaternion.Euler (temp);
		}


		double horizontal;
		double vertical;
		if (inWater) {
			horizontal = Input.GetAxis ("Horizontal") * playerSpeed;
			vertical = Input.GetAxis ("Vertical") * playerSpeed;
		} else {
			horizontal = Input.GetAxis ("Horizontal") * playerSpeedInAir;
			vertical = Input.GetAxis ("Vertical") * playerSpeedInAir;
		}
		if (playerBody.velocity.magnitude > PlayerMaxSpeed)
			horizontal = 0;

		playerBody.AddForce (new Vector2 ((float)horizontal, (float)vertical));

        if(transform.position.x < dolphPos.x){
            dist -= Vector3.Distance(transform.position, dolphPos);
        }
        else {
            dist += Vector3.Distance(transform.position, dolphPos);
        }
        dolphPos = transform.position;
		setText ();

        if(scoreMultiplier > 1) {
            powerUpTimer--;
            if(powerUpTimer == 0) {
                scoreMultiplier = 1;
                powerUpTimer = 900;
            }
        }

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
			score += 10 * scoreMultiplier;
            Vector3 v = new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y);
            randomDrop(v);
		} else if (other.gameObject.CompareTag ("Harpooner")) {
			Destroy (other.gameObject);
			score += 10 * scoreMultiplier;
            Vector3 v = new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y);
            randomDrop(v);
        } else if (other.gameObject.CompareTag ("Boat")) {
			if (playerBody.velocity.magnitude >= speedToDestroyBoat) {
				Destroy (other.gameObject);
				score += 15 * scoreMultiplier;
                Vector3 v = new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y);
                randomDrop(v);
            }
		} else if (other.gameObject.CompareTag ("Net")) {
			//Destroy (other.gameObject);
			netDeath ();
		} else if (other.gameObject.CompareTag ("Harpoon")) {
			harpoonDeath ();
		} else if (other.gameObject.CompareTag ("PowerUp")) {
            Destroy(other.gameObject);
            scoreMultiplier = 2;
            powerUpTimer = 900;
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
		setText ();

		//stop the player
		playerBody.velocity = Vector2.zero;
		playerBody.AddForce (new Vector2 ((float)playerSpeed,(float)playerSpeed));
		playerBody.gravityScale = 0;

		sceneController.GetComponent<FadeInAndOut> ().EndScene ("DeathScreen");
		//Application.LoadLevel("DeathScreen");
	}

	void harpoonDeath(){
		isDead = true;
		setText ();

		playerBody.velocity = Vector2.zero;
		playerBody.AddForce (new Vector2 (-50, 0));
		playerBody.gravityScale = 0;

		sceneController.GetComponent<FadeInAndOut> ().EndScene ("DeathScreen");
	}

	void setText(){
		if (!isDead) {
			scoreText.text = "Score: " + score.ToString ();
            int textDist = (int)dist;
			distanceText.text = "Distance: " + textDist.ToString () + " ft";
		} else {
			scoreText.text = "";
			distanceText.text = "";
		}
	}

    void randomDrop(Vector3 v) {
        GameObject powerup = GameObject.Find("PowerUp");
        int rnd = Random.Range(0, 3);
        if(/*rnd == 1*/ true) {
            // Drop random power up
            Object rObj = Instantiate(powerup, v, powerup.transform.rotation);
        }
    }

}
