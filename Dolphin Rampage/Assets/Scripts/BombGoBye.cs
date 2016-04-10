using UnityEngine;
using System.Collections;

public class BombGoBye : MonoBehaviour {

	private int time;
	public GameObject explosion;

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
			Destroy (other.gameObject);
			Instantiate (explosion, this.transform.position, Quaternion.identity);
			Destroy (gameObject);
		}
	}
}
