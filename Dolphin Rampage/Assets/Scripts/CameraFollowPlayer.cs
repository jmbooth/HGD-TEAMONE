using UnityEngine;
using System.Collections;

public class CameraFollowPlayer : MonoBehaviour {

	private GameObject player;
	private float playerY;
	private Vector3 basePosition;
	private float baseY;
	public float moveThreshold;
	public float maxOffset;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		playerY = player.transform.position.y;
		basePosition = transform.position;
	}

	// Update is called once per frame
	void LateUpdate () {
		playerY = player.transform.position.y;
		basePosition = transform.position;
		//transform.position = basePosition;
		if (playerY > moveThreshold) {
			if (playerY - moveThreshold >= maxOffset) {
				transform.position = new Vector3 (basePosition.x, maxOffset, basePosition.z);
			} else {
				transform.position += new Vector3 (0, playerY - moveThreshold - basePosition.y, 0);
			}
		} else if (playerY < -moveThreshold) {
			if (playerY + moveThreshold <= -maxOffset) {
				transform.position = new Vector3 (basePosition.x, -maxOffset, basePosition.z);
			} else {
				transform.position += new Vector3 (0, playerY + moveThreshold - basePosition.y, 0);
			}
		}
	}
}
