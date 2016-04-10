using UnityEngine;
using System.Collections;

public class FireHarpoons : MonoBehaviour {

	public GameObject harpoon;
	private float timecount;
	public GameObject boob;

	// Use this for initialization
	void Start () {
		timecount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		timecount += 1;
		if (timecount >= 120) {

			Vector3 temp = transform.position;
			temp += new Vector3 (-1.2f, -.28f, 0f);
			Instantiate (harpoon, temp, boob.transform.rotation);

			//Instantiate (harpoon, new Vector3(transform.position.x-3f,transform.position.y), Quaternion.identity);

			timecount = 0;
		}
	}
}
