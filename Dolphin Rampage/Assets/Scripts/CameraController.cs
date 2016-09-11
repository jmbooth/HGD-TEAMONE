using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CameraController : MonoBehaviour {


	public float speed=1f;
	private Vector3 newPosition;
	public GameObject player;
	private float playerY;
	private float playerX;
	Vector3 basePosition;
	public float moveThreshold;
	public float maxOffset;
	public float minOffset;
	private Vector3 velocity;
	// Use this for initialization
	void Start () {
		newPosition = this.transform.position;
		Camera.main.nearClipPlane = 0f;
		playerY = player.transform.position.y;
		playerX = player.transform.position.x;
		basePosition = transform.position;

		Vector3 velocity = Vector3.zero;
	}

	// Update is called once per frame
	float totalDistance;
	void Update () {
		transform.position = Vector3.SmoothDamp(transform.position, player.transform.position, ref velocity, 0.3F);
		//Debug.Log(transform.position);
	}

	void LateUpdate(){

		//move the camera up and down
		playerY = player.transform.position.y;
		basePosition = transform.position;
		//Debug.Log(gameObject.transform.position);
		if (playerY > moveThreshold) {
			/*if (playerY - moveThreshold >= maxOffset) {
				transform.position = new Vector3 (basePosition.x, maxOffset);
			} else {
				transform.position += new Vector3 (0, playerY - moveThreshold - basePosition.y);
			}*/
		} else if (playerY <= -moveThreshold) {
			if (playerY + moveThreshold <= -minOffset) {
				//Debug.Log(playerY + moveThreshold + " + " + -minOffset);
				transform.position = new Vector3 (basePosition.x, -minOffset);
			} else {
				transform.position += new Vector3 (0, playerY + moveThreshold - basePosition.y);
			}
		}

	}
		
}
