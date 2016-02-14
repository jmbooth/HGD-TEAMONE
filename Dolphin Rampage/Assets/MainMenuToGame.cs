using UnityEngine;
using System.Collections;

public class MainMenuToGame : MonoBehaviour {

	void Update () {
		if(Input.GetMouseButton(0))
			Application.LoadLevel("Scene_1");
	}
}
