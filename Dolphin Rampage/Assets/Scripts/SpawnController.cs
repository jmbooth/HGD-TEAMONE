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
	public int baseSpawnTime;
	float spawnTime;
	int distance;
	int minSpawnTime;
	// Use this for initialization
	void Start ()
	{
		timeb = 0;
		spawnTime = 10;
		distance = 0;
		//limits spawn rate to minSpawnTime seconds
		minSpawnTime = 5;
	}

	// Update is called once per frame
	Vector3 boatPosition; 

	/***************
	 * higher spawnRate means slower spawns
	 * r controls what can spawn
	 * one object is spawned every interval defined by spawnTime
	 * 
	 * 
	 * 
	 ****************/

	void Update ()
	{
		if((int)Movement.dist > distance)
			distance = (int)Movement.dist;
		
		timeb += Time.deltaTime;
		boatPosition = new Vector3 (camTransform.position.x + 19.2f, 5.62f);

		//control when planes,mines, and harpooners start appearing
		int r=3;
		if (distance >= 600)
			r = 4;
		else if (distance >= 300)
			r = 3;
		else if (distance >= 100)
			r = 2;

		if (timeb >= spawnTime) {
			int extraSpawns = Random.Range (1, r);
			timeb = 0;

			//spawn time decreases by 1 for each 1000 distance traveled
				spawnTime = baseSpawnTime-(distance/500);
						if(spawnTime<5)
				spawnTime=5;

			//Debug.Log ("Dist: " + distance.ToString () + " r: " + r.ToString () + "extraSpawns: " + extraSpawns.ToString ());
			//Debug.Log (spawnTime.ToString ()+" timeb = "+timeb);

			switch (extraSpawns) {
			case 4:
				//spawn plane
				Vector3 PlanePosition = new Vector3 (Random.Range (camTransform.position.x + 19.2f, camTransform.position.x + 38.4f), Random.Range (6f, 10f));
				Instantiate (PlaneTransform, PlanePosition, PlaneTransform.transform.rotation);
				break;

			case 3:
				Vector3 MinePosition = new Vector3 (Random.Range (camTransform.position.x + 19.2f, camTransform.position.x + 38.4f), Random.Range (-4f, 2f));
				int n = distance/1000;
				if(Random.Range(1,3)!=1)
					n=0;
				for(int i=0; i<=n; i++){
					//spawn mine
					Instantiate (MineTransform, MinePosition, MineTransform.transform.rotation) ;
					MinePosition = new Vector3((MinePosition.x+3),MinePosition.y);
				}
				break;

			case 2:
				//spawn harpooner
				Vector3 HarpoonerPosition = new Vector3 (Random.Range (camTransform.position.x + 19.2f, camTransform.position.x + 38.4f), Random.Range (-2.6f, 4f));
				Instantiate (HarpoonerTransform, HarpoonerPosition, HarpoonerTransform.transform.rotation) ;
				break;

			case 1:

				int j = Random.Range(1,10);
				if(j%2==0)
				{
					//spawn boat with fisherman
					Instantiate (boatTransform.transform, boatPosition, boatTransform.transform.rotation);
					boatPosition = new Vector3 (Random.Range (boatPosition.x - .3f, boatPosition.x + .3f), boatPosition.y + .3f);
					Instantiate (fisherTransform.transform, boatPosition, fisherTransform.transform.rotation) ;
				}
				else{
					//spawn boat with fisherman and net
					Instantiate (boatTransform.transform, boatPosition, boatTransform.transform.rotation);

					boatPosition = new Vector3 (Random.Range (boatPosition.x - .3f, boatPosition.x + .3f), boatPosition.y + .3f);
					Instantiate (fisherTransform.transform, boatPosition, fisherTransform.transform.rotation) ;
						
					boatPosition = new Vector3 (Random.Range (boatPosition.x - .3f, boatPosition.x + .3f), boatPosition.y - boatTransform.transform.localScale.y * 1.4f);
					Instantiate (netTransform.transform, boatPosition, netTransform.transform.rotation) ;
				}
				break;

			}
		}
	}
}