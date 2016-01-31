using UnityEngine;
using System.Collections;

public class ScrollingScript : MonoBehaviour {
	private Transform cameraTransform;
	private float spriteWidth;
	// Use this for initialization
	void Start () {
		cameraTransform = Camera.main.transform;
		SpriteRenderer spriteRenderer = GetComponent<Renderer>() as SpriteRenderer;
		spriteWidth = spriteRenderer.sprite.bounds.size.x;
	}
	
	// Update is called once per frame
	void Update () {
		if ((transform.position.x + spriteWidth) < cameraTransform.position.x) {
			Debug.Log (transform.position.x + " + " + spriteWidth + "+" + cameraTransform.position.x);
			Vector3 pos = transform.position;
			pos.x += 2.0f * spriteWidth;
			transform.position = pos;
			Debug.Log (pos.ToString ());
		}
	}
}
