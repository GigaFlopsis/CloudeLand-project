using UnityEngine;
using System.Collections;

public class LoadLogo : MonoBehaviour {

	public string levelLoadname = "Menu";
	bool loadScene = false;
	// Use this for initialization
	void Start () {
		StartCoroutine(timeAnimate(5f));
	}
	
	// Update is called once per frame
	void Update () {
		if (loadScene) {
			StartCoroutine(loadLevel(1f));
			loadScene = false;
		}
	}

	IEnumerator timeAnimate(float time)
	{
		yield return new WaitForSeconds(time);
		loadScene = true;
	}
	IEnumerator loadLevel(float time)
	{
		yield return new WaitForSeconds(time);
		Application.LoadLevel(levelLoadname);
	}


}
