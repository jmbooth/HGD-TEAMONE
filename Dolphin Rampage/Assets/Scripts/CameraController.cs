using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CameraController : MonoBehaviour {

	public Text distanceText;
	public Text score;
	public float speed=1f;
	private Vector3 newPosition;
	public GameObject player;
	private float playerY;
	private Vector3 basePosition;
	private float baseY;
	public float moveThreshold;
	public float maxOffset;
	public float minOffset;

	// Use this for initialization
	void Start () {
		newPosition = this.transform.position;
		Camera.main.nearClipPlane = 0f;
		//player =  GameObject.FindWithTag ("Player");
		playerY = player.transform.position.y;
		basePosition = transform.position;

	}

	// Update is called once per frame
	float totalDistance;
	void Update () {
		//transform.position = pos;
		newPosition.x += Time.deltaTime * speed;

		totalDistance += (newPosition.x - transform.position.x);
		//score.text = "Score: " + ((int)(newPosition.x-transform.position.x)).ToString();
		//distanceText.text = "Distance: " + ((int)totalDistance).ToString ();//((int)newPosition.x).ToString();
		transform.position = newPosition;
	}

	void LateUpdate(){
		playerY = player.transform.position.y;
		basePosition = transform.position;
		if (playerY > moveThreshold) {
			if (playerY - moveThreshold >= maxOffset) {
				transform.position = new Vector3 (basePosition.x, maxOffset);
			} else {
				transform.position += new Vector3 (0, playerY - moveThreshold - basePosition.y);
			}
		} else if (playerY <= -moveThreshold) {
			if (playerY + moveThreshold <= -minOffset) {
				transform.position = new Vector3 (basePosition.x, -minOffset);
			} else {
				transform.position += new Vector3 (0, playerY + moveThreshold - basePosition.y);
			}
		}
	}
		
}
