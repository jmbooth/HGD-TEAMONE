using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CameraController : MonoBehaviour {


	public float speed=1f;
	private Vector3 newPosition;
	public GameObject player;
	private float playerY;
	private float playerX;
	Vector3 basePosition;
	Vector3 oldBasePosition;
	public float moveThreshold;
	public float maxOffset;
	public float minOffset;
	private Vector3 velocity;
	private Color worldColor;
	private const float linearConstant = 0.5625f; //used for background interpolation
	// Use this for initialization

	void Start () {
		Debug.Log(Camera.main.backgroundColor.ToString());
		worldColor = Camera.main.backgroundColor;
		newPosition = this.transform.position;
		Camera.main.nearClipPlane = 0f;
		playerY = player.transform.position.y;
		playerX = player.transform.position.x;
		basePosition = transform.position;
		oldBasePosition = transform.position;
		Vector3 velocity = Vector3.zero;
	}
		
	float totalDistance;

	/**Interpolates the color of the default background when the player character goes
	 * above a certain height. This is used to simulate going higher into the atmosphere.
	 * 
	 * */
	void backgroundGradient(){
		//calcuate direction that dolphin is going
		Vector3 change = basePosition - oldBasePosition;
		//Creates a scale factor so that the rate of change stays the same regardless of framerate
		//linearConstant can be made smaller for slower transitions and greater for quicker transitions. 
		float delta = linearConstant * change.magnitude;
		if(basePosition.y > 16){
			//used for when dolphin is going down and the world color needs to return to default 
			if(change.y < 0){
				//transitions the world color back to the default starting color.
				worldColor.r = Mathf.MoveTowards(worldColor.r, 0.533f , delta);
				worldColor.g = Mathf.MoveTowards(worldColor.g, 0.800f, delta);
				worldColor.b = Mathf.MoveTowards(worldColor.b, 0.812f, delta);
					
				Camera.main.backgroundColor = worldColor;
				//Debug.Log(worldColor);
					

			}
			//used for when the dolphin is going up and the world color is transitioned into black
			else{
				//transitions world color to black 
				worldColor.r = Mathf.MoveTowards(worldColor.r, 0, delta);
				worldColor.g = Mathf.MoveTowards(worldColor.g, 0, delta);
				worldColor.b = Mathf.MoveTowards(worldColor.b, 0, delta);
					
				Camera.main.backgroundColor = worldColor;
				//Debug.Log(worldColor + " a");
					

			}
			
		}
	}
	void LateUpdate(){

		//move the camera up and down
		playerY = player.transform.position.y;
		basePosition = transform.position;
		backgroundGradient();
		//Debug.Log(gameObject.transform.position);

		//has the camera smoothly follow the player and prevents camera from going beneath the world
		Vector3 modifiedPlayerPos = player.transform.position;
		if(player.transform.position.y <= 0){
			modifiedPlayerPos.y = 0;
		}
		transform.position = Vector3.SmoothDamp(transform.position, modifiedPlayerPos, ref velocity, 0.3F);
		if(transform.position.y <= 0){
			transform.position.Set(transform.position.x , 0, transform.position.z);
		}
		transform.position.Set(transform.position.x , transform.position.y, 0);
		Debug.Log(modifiedPlayerPos + " " + player.transform.position);
		oldBasePosition = basePosition;

	}
		
}
