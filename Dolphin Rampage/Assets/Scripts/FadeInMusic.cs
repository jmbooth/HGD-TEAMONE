using UnityEngine;
using System.Collections;

public class FadeInMusic : MonoBehaviour {
	
	[TooltipAttribute("The audio source")]
	public AudioSource audioSource;
	[TooltipAttribute("Time in seconds to fade out")]
	public float fadeSpeed = 1f;

	private bool fadingIn = true;
	
	float time = 0f;
	
	void Update(){

		if (fadingIn) {
			audioSource.volume = Mathf.Lerp (0f, 1f, time);
			time += Time.deltaTime / fadeSpeed;
		}
		if(audioSource.volume >= 1)
			fadingIn = false;

	}
}
