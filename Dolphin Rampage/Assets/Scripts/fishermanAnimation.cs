using UnityEngine;
using System.Collections;

public class fishermanAnimation : MonoBehaviour {
	public Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	/*
		if (Input.GetKeyDown("space")) {
			anim.Play("drowning", -1, 0f);
		}
		*/
	}
	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.CompareTag("Water")) {
			anim.Play("drowning", -1, 0f);
		}
	}
	
}	

