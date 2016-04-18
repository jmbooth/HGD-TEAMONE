using UnityEngine;
using System.Collections;

public class DeathBackground : MonoBehaviour {

	public Sprite explodedDeath;
	private SpriteRenderer sr;

	void Start () {
		sr = GetComponent<SpriteRenderer> ();
		if (Movement.exploded) {
			sr.sprite = explodedDeath;
		}
	}

	void Update () {
	
	}
}
