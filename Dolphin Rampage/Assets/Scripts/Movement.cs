using UnityEngine;
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
	public static bool isDead;
	public static int score;
    public static float dist;
    public static Vector3 dolphPos;
	// Used to stop the player from spinning wildly on death
	private Vector3 finalState;
	// Used to smooth out the player's "animation"
	private float tempZ;
	// Used to swap in the explosion prefab for the mine
	public GameObject explosion;
	public GameObject brokenFishingBoat1;
	public AudioSource killPlaneSound;

    //Power Up stuff:
    public static int scoreMultiplier;
    public static int powerUpTimer;
    public static bool inBubble;
    private string powerUp;
    private Object mObj;
    private Object bObj;

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
        scoreMultiplier = 1;
		finalState = transform.rotation.eulerAngles;
		tempZ = 0.0f;
        isDead = false;
        powerUp = " ";
        inBubble = false;
	}
	
	// Update is called once per frame
	void Update () {
		//don't allow the player to move if the player is dead
		if (isDead) { 
			//playerBody.transform.rotation = Quaternion.Euler(finalState);
			Vector3 butt = transform.rotation.eulerAngles;
			if (tempZ > 0) {
				tempZ -= .25f;
			} else if (tempZ < 0) {
				tempZ += .25f;
			}
			butt.z = tempZ;
			transform.rotation = Quaternion.Euler (butt);
			return;
		}
	
		//rotate the dolphin based on user input
		Vector3 temp = transform.rotation.eulerAngles;
		temp.z = 0.0f;
		transform.rotation = Quaternion.Euler (temp);


		if (Input.GetAxis ("Vertical") > 0) {
			temp = transform.rotation.eulerAngles;
			if (tempZ < 30)
				tempZ += 1.5f;
			//temp.z = 30.0f;
			temp.z = tempZ;
			transform.rotation = Quaternion.Euler (temp);
		} else if (Input.GetAxis ("Vertical") < 0) {
			temp = transform.rotation.eulerAngles;
			if (tempZ > -30)
				tempZ -= 1.5f;
			//temp.z = -30.0f;
			temp.z = tempZ;
			transform.rotation = Quaternion.Euler (temp);
		} else {
			if (tempZ > 0) {
				tempZ -= 1.5f;
			} else if (tempZ < 0) {
				tempZ += 1.5f;
			}
			temp = transform.rotation.eulerAngles;
			temp.z = tempZ;
			transform.rotation = Quaternion.Euler (temp);
		}

		finalState = transform.rotation.eulerAngles;


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

        if(scoreMultiplier > 1) {
            powerUpTimer--;
            if(powerUpTimer == 0) {
                powerUp = " ";
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
			Vector3 v = new Vector3 (other.gameObject.transform.position.x, other.gameObject.transform.position.y);
			randomDrop (v, "Fisherman");
		} else if (other.gameObject.CompareTag ("Mine") || other.gameObject.CompareTag ("Bomb")) {
			other.GetComponent<AudioSource> ().Play ();
			mineDeath (other.gameObject);
		} else if (other.gameObject.CompareTag ("Harpooner")) {
			Destroy (other.gameObject);
			score += 10 * scoreMultiplier;
			Vector3 v = new Vector3 (other.gameObject.transform.position.x, other.gameObject.transform.position.y);
			randomDrop (v, "Harpooner");
		} else if (other.gameObject.CompareTag ("Boat")) {
			if (playerBody.velocity.magnitude >= speedToDestroyBoat) {
				other.GetComponent<AudioSource> ().Play ();

				Transform copyObj = other.transform;
				Instantiate (brokenFishingBoat1, copyObj.transform.position, copyObj.transform.rotation);

				Vector3 pos = Camera.main.transform.position;
				pos.x -= 20f;
				other.transform.position = pos;

				score += 15 * scoreMultiplier;
				Vector3 v = new Vector3 (other.gameObject.transform.position.x, other.gameObject.transform.position.y);
				randomDrop (v, "Boat");
			}
		} else if (other.gameObject.CompareTag ("Net")) {
			if (inBubble) {
				powerUp = " ";
				inBubble = false;
				Destroy (other.gameObject);
			} else {
				netDeath ();
			}
		} else if (other.gameObject.CompareTag ("Harpoon")) {
			if (inBubble) {
				powerUp = " ";
				inBubble = false;
				Destroy (other.gameObject);
			} else {
				harpoonDeath ();
			}
		} else if (other.gameObject.CompareTag ("Plane")) {
			// Placeholder, change later
			other.GetComponent<AudioSource> ().Play ();
			Instantiate (explosion, other.transform.position, Quaternion.identity);
			Vector3 temp = other.transform.position;
			temp.x -= 100;
			other.transform.position = temp;
			Vector3 v = new Vector3 (other.gameObject.transform.position.x, other.gameObject.transform.position.y);
			Destroy (other.gameObject, 3);
			score += 10 * scoreMultiplier;
			randomDrop (v, "Harpooner");
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

		//stop the player
		playerBody.velocity = Vector2.zero;
		playerBody.AddForce (new Vector2 ((float)playerSpeed,(float)playerSpeed));
		playerBody.gravityScale = 0;

		sceneController.GetComponent<FadeInAndOut> ().EndScene ("DeathScreen");
		//Application.LoadLevel("DeathScreen");
	}

	void harpoonDeath(){
		isDead = true;

		playerBody.velocity = Vector2.zero;
		playerBody.AddForce (new Vector2 (-50, 0));
		playerBody.gravityScale = 0;

		sceneController.GetComponent<FadeInAndOut> ().EndScene ("DeathScreen");
	}

	void mineDeath(GameObject other){
		isDead = true;
		Instantiate (explosion, other.transform.position, Quaternion.identity);
		float xSpeed = (playerBody.transform.position.x - other.transform.position.x) * 2000;
		float ySpeed = (playerBody.transform.position.y - other.transform.position.y) * 2000;
		//float xSpeed = Random.Range (1000, 3000);
		//float ySpeed = Random.Range (1000, 3000);
		//if (xSpeed % 2 == 0)
			//xSpeed *= -1;
		//if (ySpeed % 2 == 0)
			//ySpeed *= -1;
		playerBody.AddForce (new Vector2 (xSpeed, ySpeed));
		Vector3 temp = other.transform.position;
		temp.x -= 100;
		other.transform.position = temp;
		Destroy (other.gameObject, 3);

		sceneController.GetComponent<FadeInAndOut> ().EndScene ("DeathScreen");
	}


    void randomDrop(Vector3 v, string type)
    {
        // Wood Boat = Bubble Shield, Metal Boat = Invincibility, Fisherman/Harpooner = x2
        int rnd = Random.Range(0, 3);
        if (rnd == 1 && powerUp.Equals(" "))
        {
            if (type == "Fisherman" || type == "Harpooner")
            {
                powerUp = "Multiplier";
				scoreMultiplier = Random.Range(2,5);
                powerUpTimer = 900;
            }
            else if (type == "Boat")
            {
                powerUp = "BubbleShield";
                inBubble = true;
            }
            else {

            }
        }
    }

}
