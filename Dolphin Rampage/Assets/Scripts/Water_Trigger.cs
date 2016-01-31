using UnityEngine;
using System.Collections;

public class Water_Trigger : MonoBehaviour {

	public Collider2D ThisTrigger;
	public GameObject player;
	public Collider2D playerCollider;
	public bool characterInWater;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	//	if (ThisTrigger.IsTouching (playerCollider)) {
	//		playerCollider.attachedRigidbody.gravityScale = .1f;	
	//	} else {
	//		playerCollider.attachedRigidbody.gravityScale = 1f;
	//	}
	}

	//void OnTriggerEnter2D(Collider2D other) {
	//	characterInWater = true;
	//}

	//void OnTriggerExit2D(Collider2D other) {
	//	characterInWater = false;
	//}
}
