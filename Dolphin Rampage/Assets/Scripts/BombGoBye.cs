using UnityEngine;
using System.Collections;

public class BombGoBye : MonoBehaviour {

	private int time;
	public GameObject explosion;
	public GameObject brokenBoat;

	// Use this for initialization
	void Start () {
		time = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (time++ >= 240) {
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.CompareTag ("Boat")){
			Instantiate (brokenBoat, other.transform.position, Quaternion.identity);
			Destroy (other.gameObject);
			Instantiate (explosion, this.transform.position, Quaternion.identity);
			Destroy (gameObject, .02f);
		} else if (other.gameObject.CompareTag ("Mine") || other.gameObject.CompareTag ("Fisherman") || other.gameObject.CompareTag ("Harpooner")){
			Destroy (other.gameObject);
			Instantiate (explosion, this.transform.position, Quaternion.identity);
			Destroy (gameObject);
		}
	}
}
