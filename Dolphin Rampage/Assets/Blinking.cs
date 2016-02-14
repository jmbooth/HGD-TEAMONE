using UnityEngine;
using System.Collections;

public class Blinking : MonoBehaviour {

	float speed = .66f;


	/*void Update() {
		

		Color color = Renderer.material.color ;

		color.a = Mathf.Round(Mathf.PingPong(Time.time * speed, 1.0f));

		Renderer.material.color = color ;	
	}*/

	public GameObject flashing_Label;
	

	
	void Start()
	{
		InvokeRepeating("FlashLabel", 0, speed);
	}
	
	void FlashLabel()
	{
		if(flashing_Label.activeSelf)
			flashing_Label.SetActive(false);
		else
			flashing_Label.SetActive(true);
	}
}
