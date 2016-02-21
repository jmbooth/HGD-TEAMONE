using UnityEngine;
using System.Collections;

public class MainMenuToGame : MonoBehaviour {

	void Update () {
		if(Input.GetKeyUp("space"))
			Application.LoadLevel("Scene_1");
	}
}
