using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour
{
	public Transform camTransform;
	public GameObject netTransform;
	public GameObject boatTransform;
	public GameObject fisherTransform;
	public GameObject HarpoonerTransform;
	public GameObject MineTransform;
	public GameObject PlaneTransform;
	float timeb;
	public float spawnTime; 
	int distance;
	// Use this for initialization
	void Start ()
	{
		timeb = 0;
		spawnTime = Random.Range(10,15);
	}

	// Update is called once per frame
	Vector3 boatPosition; 

	/***************
	 * 
	 * r controls what can spawn
	 * one object is spawned every interval defined by spawnTime
	 * 
	 * 
	 * 
	 ****************/

	void Update ()
	{
		distance = (int)Movement.dist;
		//Debug.Log (distance.ToString ());
		timeb += Time.deltaTime;
		boatPosition = new Vector3 (camTransform.position.x + 19.2f, 5.62f);

		//control when planes,mines, and harpooners start appearing
		int r=3;
		if (distance >= 50)
			r = 6;
		else if (distance >= 100)
			r = 5;
		else if (distance >= 150)
			r = 4;
		
		if (timeb >= spawnTime) {

			timeb = 0;
			spawnTime = Random.Range (10, 15);
			int extraSpawns = Random.Range (1, r);
			Debug.Log ("Dist: " + distance.ToString () + " r: " + r.ToString () + "extraSpawns: " + extraSpawns.ToString ());
			switch (extraSpawns) {
			case 5:
				//spawn plane
				Vector3 PlanePosition = new Vector3 (Random.Range (camTransform.position.x + 19.2f, camTransform.position.x + 38.4f), Random.Range (6f, 10f));
				Instantiate (PlaneTransform, PlanePosition, PlaneTransform.transform.rotation);
				break;

			case 4:
				//spawn mine
				Vector3 MinePosition = new Vector3 (Random.Range (camTransform.position.x + 19.2f, camTransform.position.x + 38.4f), Random.Range (-2.6f, 4f));
				Instantiate (MineTransform, MinePosition, MineTransform.transform.rotation) ;
				break;

			case 3:
				//spawn harpooner
				Vector3 HarpoonerPosition = new Vector3 (Random.Range (camTransform.position.x + 19.2f, camTransform.position.x + 38.4f), Random.Range (-2.6f, 4f));
				Instantiate (HarpoonerTransform, HarpoonerPosition, HarpoonerTransform.transform.rotation) ;
				break;

			case 2:
				Instantiate (boatTransform.transform, boatPosition, boatTransform.transform.rotation);
				//spawn fisherman and net
				boatPosition = new Vector3 (Random.Range (boatPosition.x - .3f, boatPosition.x + .3f), boatPosition.y + .3f);
				Instantiate (fisherTransform.transform, boatPosition, fisherTransform.transform.rotation) ;

				boatPosition = new Vector3 (Random.Range (boatPosition.x - .3f, boatPosition.x + .3f), boatPosition.y - boatTransform.transform.localScale.y * 1.4f);
				Instantiate (netTransform.transform, boatPosition, netTransform.transform.rotation) ;
				break;

			case 1:
				Instantiate (boatTransform.transform, boatPosition, boatTransform.transform.rotation);
				//spawn fisherman
				boatPosition = new Vector3 (Random.Range (boatPosition.x - .3f, boatPosition.x + .3f), boatPosition.y + .3f);
				Instantiate (fisherTransform.transform, boatPosition, fisherTransform.transform.rotation) ;
				break;
			}
		}
	}
}