using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour {
	public Transform camTransform;
	public Transform netTransform;
	public Transform boatTransform;
	public Transform fisherTransform;
	private Object[,] spawnedMat = new Object[5, 3];
	float time;
	// Use this for initialization
	void Start () {
		 time=0;

	}

	// Update is called once per frame
	private Object bObj, nObj, fObj;
	void Update () {
		time += Time.deltaTime;
		Vector3 boatPosition = new Vector3 (camTransform.position.x + 6f, 5.62f);
		if (time >= 10) {
			bObj = Instantiate (boatTransform, boatPosition, boatTransform.rotation);
			time = 0;
			int extraSpawns = Random.Range (0, 3);
			switch (extraSpawns) {
			case 3:
				//spawn fisherman and net
				boatPosition = new Vector3 (Random.Range (boatPosition.x - .3f, boatPosition.x + .3f), boatPosition.y + .1f);
				fObj = Instantiate (fisherTransform, boatPosition, fisherTransform.rotation);
		
				boatPosition = new Vector3 (Random.Range (boatPosition.x - .3f, boatPosition.x + .3f), boatPosition.y - boatTransform.localScale.y);
				nObj = Instantiate (netTransform, boatPosition, netTransform.rotation);

				break;
			case 2:
				//spawn fisherman
				boatPosition = new Vector3(Random.Range(boatPosition.x-.3f,boatPosition.x+.3f),boatPosition.y+.1f);
				fObj = Instantiate (fisherTransform, boatPosition, fisherTransform.rotation);
				break;
			case 1:
				//spawn net
				boatPosition = new Vector3(Random.Range(boatPosition.x-.3f,boatPosition.x+.3f),boatPosition.y-(boatTransform.localScale.y*1.3f));
				nObj = Instantiate (netTransform, boatPosition, netTransform.rotation);
				break;
			case 0:
				break;
			}
			
		}
	}
}