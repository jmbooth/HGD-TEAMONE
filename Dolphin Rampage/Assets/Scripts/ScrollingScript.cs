using UnityEngine;
using System.Collections;

public class ScrollingScript : MonoBehaviour {

	private float spriteWidth;

	// Use this for initialization
	void Start () {

		SpriteRenderer spriteRenderer = GetComponent<Renderer>() as SpriteRenderer;
		spriteWidth = spriteRenderer.sprite.bounds.size.x;
	}
	
	// Update is called once per frame
	void Update()
	{
		LateUpdate ();
	}

	void LateUpdate () {

		if ((transform.position.x + spriteWidth) < Camera.main.transform.position.x) {

			Vector3 pos = transform.position;
			pos.x += 2.0f * spriteWidth;
			transform.position = pos;

		}
	}
}
