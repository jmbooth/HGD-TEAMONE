using UnityEngine;
using System.Collections;

public class FadeoutMusic : MonoBehaviour {

	[TooltipAttribute("The audio source")]
	public AudioSource audioSource;
	[TooltipAttribute("Time in seconds to fade out")]
	public float fadeSpeed = 1f;
	[TooltipAttribute("Toggle the fade")]
	public bool startFadeIn = false;
	public bool startFadeOut = false;

	float time = 0f;
	
	void Update(){
		if(startFadeOut){
			audioSource.volume = Mathf.Lerp(1f, 0f, time);
			time += Time.deltaTime / fadeSpeed;
		}

		if (audioSource.volume <= 0f)
			startFadeOut = false;

		if (startFadeIn) {
			audioSource.volume = Mathf.Lerp(0f, 1f, time);
			time += Time.deltaTime / fadeSpeed;
		}

		if (audioSource.volume >= 1f)
			startFadeIn = false;
	}
}
