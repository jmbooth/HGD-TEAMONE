using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CameraController : MonoBehaviour {

	public Text distanceText;
	public Text score;
	public float speed=1f;
	private Vector3 newPosition;

	// Use this for initialization
	void Start () {
		newPosition = this.transform.position;
	}
	
	// Update is called once per frame
	float totalDistance;
	void Update () {
		newPosition.x += Time.deltaTime * speed;
		totalDistance += (newPosition.x - transform.position.x);
		//score.text = "Score: " + ((int)(newPosition.x-transform.position.x)).ToString();
		//distanceText.text = "Distance: " + ((int)totalDistance).ToString ();//((int)newPosition.x).ToString();
		transform.position = newPosition;
	}
}
