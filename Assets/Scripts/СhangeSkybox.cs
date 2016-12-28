using UnityEngine;
using System.Collections;

public class СhangeSkybox : MonoBehaviour {

	public bool sky = false;
	public Material skybox1;
	public Material skybox2;

	// Use this for initialization
	void Start () {
		skybox1 = RenderSettings.skybox;
	}
	
	// Update is called once per frame
	void Update () {
		if(sky)
		{
			RenderSettings.skybox = skybox1;
		}
		if(!sky)
		{
			RenderSettings.skybox = skybox2;
		}

	
	}


	public void ChengeSkybox(){
		sky = !sky;
	}

}
