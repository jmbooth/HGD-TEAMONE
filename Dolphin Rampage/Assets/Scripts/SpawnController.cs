using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour
{
	public Transform camTransform;
	public GameObject netTransform;
	public GameObject boatTransform;
	public GameObject fisherTransform;
	public GameObject HarpoonerTransform;
	private GameObject[,] spawnedMat = new GameObject[5, 3];
	float timeb;
	float timeh;
	float spawnTime; 
	// Use this for initialization
	void Start ()
	{
		timeb = timeh = 0;
		spawnTime = Random.Range(10,15);
	}

	// Update is called once per frame
	Vector3 boatPosition; 

	void Update ()
	{

		timeb += Time.deltaTime;
		timeh += Time.deltaTime;
		boatPosition = new Vector3 (camTransform.position.x + 19.2f, 5.62f);
		if (timeb >= spawnTime) {
			Instantiate (boatTransform.transform, boatPosition, boatTransform.transform.rotation);
			timeb = 0;
			spawnTime = Random.Range (10, 15);
			int extraSpawns = Random.Range (1, 3);

			switch (extraSpawns) {
			case 3:
				//spawn fisherman and net
				boatPosition = new Vector3 (Random.Range (boatPosition.x - .3f, boatPosition.x + .3f), boatPosition.y + .3f);
				Instantiate (fisherTransform.transform, boatPosition, fisherTransform.transform.rotation) ;

				boatPosition = new Vector3 (Random.Range (boatPosition.x - .3f, boatPosition.x + .3f), boatPosition.y - boatTransform.transform.localScale.y * 1.4f);
				Instantiate (netTransform.transform, boatPosition, netTransform.transform.rotation) ;
				break;

			case 2:
				//spawn fisherman
				boatPosition = new Vector3 (Random.Range (boatPosition.x - .3f, boatPosition.x + .3f), boatPosition.y + .3f);
				Instantiate (fisherTransform.transform, boatPosition, fisherTransform.transform.rotation) ;
				break;

			case 1:
				//spawn net
				boatPosition = new Vector3 (Random.Range (boatPosition.x - .3f, boatPosition.x + .3f), boatPosition.y - (boatTransform.transform.localScale.y * 1.5f));
				Instantiate (netTransform.transform, boatPosition, netTransform.transform.rotation) ;
				break;

			case 0:
				break;
			}
			
		} else if (timeh >= 15) {
			timeh = 0;
			Vector3 HarpoonerPosition = new Vector3 (Random.Range (camTransform.position.x + 19.2f, camTransform.position.x + 38.4f), Random.Range (-2.6f, 4f));
			Instantiate (HarpoonerTransform, HarpoonerPosition, HarpoonerTransform.transform.rotation) ;

		}
	}
}