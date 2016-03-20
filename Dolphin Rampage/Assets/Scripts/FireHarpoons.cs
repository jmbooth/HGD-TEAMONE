using UnityEngine;
using System.Collections;

public class FireHarpoons : MonoBehaviour {

	public GameObject harpoon;
	private float timecount;

	// Use this for initialization
	void Start () {
		timecount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		timecount += 1;
		if (timecount >= 120) {
			//Vector3 temp = transform.rotation.eulerAngles;
			//temp.z += 90;
			Instantiate (harpoon, transform.position, Quaternion.identity);
			timecount = 0;
		}
	}
}
