using UnityEngine;
using System.Collections;

public class MainMenuToGame : MonoBehaviour {

	public GameObject sceneController;


	public float inputDelay = 2f;
	private float inputDelayDelta = 0f;

	void Update () {

		if (inputDelayDelta  < inputDelay) {
			inputDelayDelta += Time.deltaTime;
			return;
		}

		if(Input.GetKeyUp("space"))
			sceneController.GetComponent<FadeInAndOut>().EndScene("Scene_1");
	}
}
