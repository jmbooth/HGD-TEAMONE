using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeInAndOut : MonoBehaviour
{
	public float fadeInSpeed = 1.5f;          // Speed that the screen fades to and from black.
	public float fadeOutSpeed = 1.5f;

	private bool sceneStarting = true;      // Whether or not the scene is still fading in.
	private bool sceneEnding = false;

	private string nextScene = "";

	void Start()
	{
		GetComponent<Image> ().color = Color.black;
	}

	void Update ()
	{
		// If the scene is starting...
		if(sceneStarting)
			StartScene();


		if (sceneEnding)
			EndScene (nextScene);
	}
	
	
	void FadeToClear ()
	{
		// Lerp the colour of the texture between itself and transparent.
		GetComponent<Image>().color = Color.Lerp(GetComponent<Image>().color, Color.clear, fadeInSpeed * Time.deltaTime);

	}
	
	
	void FadeToBlack ()
	{
		// Lerp the colour of the texture between itself and black.
		GetComponent<Image>().color = Color.Lerp(GetComponent<Image>().color, Color.black, fadeOutSpeed * Time.deltaTime);
	}
	
	
	void StartScene ()
	{
		// Fade the texture to clear.
		FadeToClear();

		// If the texture is almost clear...
		if(GetComponent<Image>().color.a <= 0.05f)
		{
			// ... set the colour to clear and disable the GUITexture.
			GetComponent<Image>().color = Color.clear;
			//GetComponent<Image>().enabled = false;
			
			// The scene is no longer starting.
			sceneStarting = false;
		}
	}
	
	
	public void EndScene (string sceneToLoad)
	{

		nextScene = sceneToLoad;
		sceneEnding = true;
		// Make sure the texture is enabled.
		//GetComponent<Image>().enabled = true;
		
		// Start fading towards black.
		FadeToBlack();

		// If the screen is almost black...
		if(GetComponent<Image>().color.a >= 0.95f)
			// ... reload the level.
			SceneManager.LoadScene(sceneToLoad);
	}
}