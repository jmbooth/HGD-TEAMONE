using UnityEngine;
using System.Collections;

public class MainMenuToGame : MonoBehaviour {

	public GameObject sceneController;


	public float inputDelay = 2f;
	private float inputDelayDelta = 0f;

	public GameObject outroVoice;

	void Update () {

		if (inputDelayDelta  < inputDelay) {
			inputDelayDelta += Time.deltaTime;
			return;
		}

		if (Input.GetKeyUp ("space")) {
			outroVoice.GetComponent<AudioSource>().enabled = true;
			outroVoice.GetComponent<AudioSource>().Play ();
			sceneController.GetComponent<FadeInAndOut> ().EndScene ("Scene_1");
		}
	}
}
