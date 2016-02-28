using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour {
	public Transform camTransform;
	public Transform netTransform;
	public Transform boatTransform;
	public Transform fisherTransform;
	public Transform HarpoonerTransform;
	private Object[,] spawnedMat = new Object[5, 3];
	float timeb;
	float timeh;
	// Use this for initialization
	void Start () {
		 timeb=timeh=0;

	}

	// Update is called once per frame
	private Object bObj, nObj, fObj, hObj;
	void Update () {
		timeb += Time.deltaTime;
		timeh += Time.deltaTime;
		Vector3 boatPosition = new Vector3 (camTransform.position.x + 19.2f, 5.62f);
		if (timeb >= 10) {
			bObj = Instantiate (boatTransform, boatPosition, boatTransform.rotation);
			timeb = 0;
			int extraSpawns = Random.Range (1, 3);
			switch (extraSpawns) {
			case 3:
				//spawn fisherman and net
				boatPosition = new Vector3 (Random.Range (boatPosition.x - .3f, boatPosition.x + .3f), boatPosition.y + .3f);
				fObj = Instantiate (fisherTransform, boatPosition, fisherTransform.rotation);
		
				boatPosition = new Vector3 (Random.Range (boatPosition.x - .3f, boatPosition.x + .3f), boatPosition.y - boatTransform.localScale.y * 1.4f);
				nObj = Instantiate (netTransform, boatPosition, netTransform.rotation);

				break;
			case 2:
				//spawn fisherman
				boatPosition = new Vector3 (Random.Range (boatPosition.x - .3f, boatPosition.x + .3f), boatPosition.y + .3f);
				fObj = Instantiate (fisherTransform, boatPosition, fisherTransform.rotation);
				break;
			case 1:
				//spawn net
				boatPosition = new Vector3 (Random.Range (boatPosition.x - .3f, boatPosition.x + .3f), boatPosition.y - (boatTransform.localScale.y * 1.4f));
				nObj = Instantiate (netTransform, boatPosition, netTransform.rotation);
				break;
			case 0:
				break;
			}
			
		} else if (timeh >= 15) {
			timeh = 0;
			Vector3 HarpoonerPosition = new Vector3 (Random.Range (camTransform.position.x + 19.2f, camTransform.position.x + 38.4f), Random.Range (1f, 3f));
			hObj = Instantiate (HarpoonerTransform, HarpoonerPosition, HarpoonerTransform.rotation);
		}
			
	}
}