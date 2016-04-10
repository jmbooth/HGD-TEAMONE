using UnityEngine;
using System.Collections;

public class EnemyPhysicsController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerExit2D(Collider2D coll){
		Debug.Log (this.gameObject.tag + " left collision with "+coll.tag);
		if (coll.gameObject.tag == "Boat"&& !this.gameObject.tag.ToString().Equals("Player")) {
			this.gameObject.GetComponent<Rigidbody2D>().gravityScale = .1f;
		}
	}
	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "Harpoon" && ((this.gameObject.tag == "Fisherman") || (this.gameObject.tag == "Harpooner"))) {
			Debug.Log (this.gameObject.tag + "hit by harpoon");
			Destroy (this.gameObject);
		}
	}
}
