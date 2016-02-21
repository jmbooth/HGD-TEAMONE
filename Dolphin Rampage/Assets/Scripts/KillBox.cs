using UnityEngine;
using System.Collections;

public class KillBox : MonoBehaviour {

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

	void OnTriggerEnter2D(Collider2D other){
		Destroy (other.gameObject);
	}
}
