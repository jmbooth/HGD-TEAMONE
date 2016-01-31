using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	
	public float speed=100f;
	private Vector3 newPosition;

	// Use this for initialization
	void Start () {
		newPosition = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		newPosition.x += Time.deltaTime * speed;
		transform.position = newPosition;
	}
}
