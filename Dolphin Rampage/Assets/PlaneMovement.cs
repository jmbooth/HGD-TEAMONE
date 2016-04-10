using UnityEngine;
using System.Collections;

public class PlaneMovement : MonoBehaviour {

	public float speed = 3f;
	public GameObject bomb;
	public float bombTimer = .5f;
	private float bombTimerRunning = 0f;
	public GameObject bombRot;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector2 (this.transform.position.x + Time.deltaTime * -speed, this.transform.position.y);

		if ((bombTimerRunning += Time.deltaTime) > bombTimer) {
			bombTimerRunning = 0;
			Vector3 temp = this.transform.position;
			temp.y -= .5f;
			Instantiate (bomb, temp, bombRot.transform.rotation);
		}
	}
}
