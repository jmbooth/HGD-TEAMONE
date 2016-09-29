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
	public GameObject Jetpack;
	public GameObject player;
	public GameObject coralTransform;
	private Movement mov;

	public AudioSource voiceOne;
	public AudioSource voiceTwo;
	public AudioSource voiceThree;


	private bool playedVoiceOne = false;
	private bool playedVoiceTwo = false;
	private bool playedVoiceThree= false; 
	public static bool jetpackMade;

	private float noise;
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

		playedVoiceOne = false;
		playedVoiceTwo = false;
		playedVoiceThree = false;
		jetpackMade = false;

		mov = player.GetComponent<Movement>();
	}

	// Update is called once per frame
	Vector3 boatPosition; 
	Vector3 coralPosition;
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
		noise = Mathf.PerlinNoise(Time.time, 0.0f);
		if((int)Movement.dist > distance)
			distance = (int)Movement.dist;
		
		timeb += Time.deltaTime;
		boatPosition = new Vector3 (camTransform.position.x + 19.2f, 5.62f);
		coralPosition = new Vector3 (camTransform.position.x + 18f, -4.5f);

		//control when planes,mines, and harpooners start appearing
		int r=1;

		if (distance >= 600) {
			r = 4;
			if (!playedVoiceThree)
			{
				voiceThree.GetComponent<AudioSource>().Play();
				playedVoiceThree = true;
			}
		} else if (distance >= 300) {
			if(!playedVoiceTwo)
			{
				voiceTwo.GetComponent<AudioSource>().Play();
				playedVoiceTwo = true;
			}
			r = 3;
		} else if (distance >= 100) {
			if(!playedVoiceOne)
			{
				voiceOne.GetComponent<AudioSource> ().Play ();
				playedVoiceOne = true;
			}
			r = 2;
		}

		if (timeb >= spawnTime) {
			//int random.range is exculsive on the second argument
			int extraSpawns = Random.Range (1, r+1);

			timeb = 0;

			//spawn time decreases by 1 for each 1000 distance traveled
			spawnTime = baseSpawnTime-(distance/500);
					if(spawnTime<5)
			spawnTime=5;



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
	//control coral spawn
		if(distance > 10){
			if(noise > 0.78f){
				coralPosition = new Vector3 (Random.Range (coralPosition.x - 1.5f, coralPosition.x + 11f), Random.Range(coralPosition.y -.7f, coralPosition.y + .2f), 0);
				Instantiate (coralTransform.transform, coralPosition, coralTransform.transform.rotation);
			}
		}
		if(Movement.hasJetPack){
			Vector3 jetPackOffset = player.transform.position + new Vector3(-0.1f, 0.33f, 0);
			if(!jetpackMade){
				Instantiate(Jetpack.transform, jetPackOffset, player.transform.rotation);
				jetpackMade = true;
			}
			
		}

	}
}