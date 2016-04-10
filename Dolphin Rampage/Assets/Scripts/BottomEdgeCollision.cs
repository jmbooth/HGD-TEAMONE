using UnityEngine;
using System.Collections;

public class BottomEdgeCollision : MonoBehaviour {
	public GameObject camera;
	private Transform cameraPos;
	private float offset;
	// Use this for initialization
	void Start () {
		cameraPos = camera.transform;
		offset = cameraPos.position.x - transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (cameraPos.position.x - offset, transform.position.y, transform.position.z);
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag != "Player") {
			coll.gameObject.GetComponent<Rigidbody2D> ().velocity = Vector3.zero;
			coll.gameObject.GetComponent<Rigidbody2D> ().isKinematic = true;
		}
	}
}
