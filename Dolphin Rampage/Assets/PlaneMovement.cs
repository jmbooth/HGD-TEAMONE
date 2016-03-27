using UnityEngine;
using System.Collections;

public class PlaneMovement : MonoBehaviour {

	public float speed = 3f;
	public GameObject bomb;
	public float bombTimer = 5f;
	private float bombTimerRunning = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector2 (this.transform.position.x + Time.deltaTime * -speed, this.transform.position.y);

		if ((bombTimerRunning += Time.deltaTime) > bombTimer) {
			bombTimerRunning = 0;
			Instantiate (bomb, this.transform.position, this.transform.rotation);
		}
	}
}
