using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelParam : MonoBehaviour {

	public bool cursoorVisible = false;
	public bool motionBlur;
	public bool restartButton = true;
	public Image loadBackground;

	public UnityStandardAssets.ImageEffects.CameraMotionBlur[] MotionBlurScript;
	public Vector3 gravity = new Vector3(0F, -9.81F, 0F);
	public int Level = 0;

	[SerializeField]
	private int AvailableLevels = 0;
	private int continueLevel;

	public int Stars = 0;

	public Timer timeGame;
	private bool SwitchMotionBlur;
	// Use this for initialization
	AsyncOperation AO;

	void Awake () {

		Application.targetFrameRate = 30;

		StartCoroutine (StartLevelBg (loadBackground));

		GvrViewer.Controller.directRender = !GvrViewer.Controller.directRender;

		continueLevel = Level;
		if (Application.loadedLevelName != "Menu") {
			PlayerPrefs.SetInt ("ContinueLevel", continueLevel);
			PlayerPrefs.Save ();                         
		}

		if (PlayerPrefs.HasKey("AvalibleLevels"))
			AvailableLevels = PlayerPrefs.GetInt("AvalibleLevels");
		// switch Motion Blur
		if (PlayerPrefs.HasKey("MotionBlur")){
			motionBlur = PlayerPrefs.GetInt("MotionBlur") == 1 ? true : false;
			SwitchMotionBlur = !motionBlur;
		}

		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = cursoorVisible;
		Physics.gravity = gravity;
	}

	//
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player");
		StartCoroutine(LoadLevel (Application.loadedLevelName, 0f, loadBackground));
		GvrViewer.Controller.directRender = !GvrViewer.Controller.directRender;

	}

	// Update is called once per frame
	void Update () {

		if (AO != null) {
			Debug.Log (AO.progress);
		}

		if(motionBlur != SwitchMotionBlur){
			EnableMotionBlur(motionBlur);
		}

		if (Input.GetKey(KeyCode.R) || Input.GetKeyUp("escape") && restartButton)
		{
			RestartLevel ();
			GvrViewer.Controller.directRender = !GvrViewer.Controller.directRender;
		}

		if (Input.GetKey(KeyCode.K)) PlayerPrefs.DeleteAll();
	}

	public void RestartLevel()
	{
		StartCoroutine(LoadLevel(Application.loadedLevelName, 0f, loadBackground, 10f));
	}

	public void EnableMotionBlur(bool state){

		for(int i = 0; i < MotionBlurScript.Length; i++){
			MotionBlurScript[i].enabled = state;
		}
		PlayerPrefs.SetInt("MotionBlur", state == true ? 1 : 0);
		PlayerPrefs.Save();
		SwitchMotionBlur = state;
		motionBlur = state;

	}

	public void ExitGame()
	{ Application.Quit(); }


	public void ContinueGame()
	{
		int clevel = 0;
		if (PlayerPrefs.HasKey("ContinueLevel"))
		{
			clevel = PlayerPrefs.GetInt("ContinueLevel");
		}
		clevel = clevel < 0 ? 0 : clevel;
		string name = "Level_" + clevel.ToString("0");
		StartCoroutine (LoadLevel(name,2f,loadBackground));	
	}





	public void LoadMenu()
	{
		StartCoroutine (LoadLevel ("Menu", 0f, loadBackground));
	}

	private bool finish = false;
	public void Finish()
	{
		timeGame.Stop(Level);
		string name = "Level_" + Level.ToString() + "_Stars";
		if (PlayerPrefs.HasKey(name))
		{
			if (PlayerPrefs.GetInt(name) <= Stars)
			{
				int newStars = Stars - PlayerPrefs.GetInt(name);
				PlayerPrefs.SetInt(name, Stars);
				if (PlayerPrefs.HasKey("AvalibleStars"))
				{
					int allStarts = PlayerPrefs.GetInt("AvalibleStars");
					PlayerPrefs.SetInt("AvalibleStars", allStarts + newStars);
				}
			}
		}
		else {
			PlayerPrefs.SetInt(name, Stars);
			if (PlayerPrefs.HasKey("AvalibleStars"))
			{
				int allStarts = PlayerPrefs.GetInt("AvalibleStars");
				PlayerPrefs.SetInt("AvalibleStars", allStarts + Stars);
			}
		}
		if (AvailableLevels <= Level) PlayerPrefs.SetInt("AvalibleLevels", Level + 1);
		PlayerPrefs.Save();
		//        Debug.Log("avLevel: " + PlayerPrefs.GetInt("AvalibleLevels"));
	}

	public void LoadNextLevel(string name)
	{
		//    Application.LoadLevel(name);
		StartCoroutine (LoadLevel(name,0f,loadBackground));
	}


	IEnumerator LoadLevel(string name,float delay,Image im = null, float speed = 10f)
	{
		if (im != null) {
			im.enabled = true;
			Color targetColor = im.color;
			targetColor.a = 0f;
			im.color = targetColor;
			targetColor.a = 1;

			while(im.color.a < 0.98f){
				im.enabled = true;
				im.color = Color.Lerp(im.color,targetColor, Time.deltaTime * speed);
				yield return null;
			}
			im.color = targetColor;
		}
		yield return new WaitForSeconds(delay); 
		Application.LoadLevel(name);
	}



	IEnumerator StartLevelBg(Image im = null, float speed = 10f)
	{
		if (im != null) {
			im.enabled = true;
			Color targetColor = im.color;
			targetColor.a = 1f;
			im.color = targetColor;
			targetColor.a = 0f;
			while(im.color.a > 0.005f){
				im.enabled = true;
				im.color = Color.Lerp(im.color,targetColor, Time.deltaTime * speed);
				yield return null;
			}
		}
		im.enabled = false;
		yield return null;
	}


	public void AddStar()
	{
		Stars++;
	}


}
