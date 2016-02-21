using UnityEngine;
using System.Collections;

public class MainMenuToGame : MonoBehaviour {

	public GameObject sceneController;

	void Update () {
		if(Input.GetKeyUp("space"))
			sceneController.GetComponent<FadeInAndOut>().EndScene("Scene_1");
	}
}
