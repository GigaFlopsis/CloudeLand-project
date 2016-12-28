using UnityEngine;
using System.Collections;

[AddComponentMenu("GoogleVR/GvrHead")]
public class RotateCam : MonoBehaviour {

	public Transform posCam;
	public Transform head;
	public GvrHead headPos;
	public Vector3 rotateHead;

	private float cabibrateYPos;

	// Use this for initialization
	void Awake()
	{

	}

	void Start () {
		rotateHead = Vector3.zero;
	//	cabibrateYPos = posCam.eulerAngles.y - headPos.RotataHead.eulerAngles.y;			
	//	rotateHead.y = cabibrateYPos;
	}
	
	// Update is called once per frame
	void Update () {
		//head.localEulerAngles.x
		if(head.localEulerAngles.x >= 0 && headPos.RotateHead.eulerAngles.x < 90){ 
			rotateHead.x = 	Mathf.Clamp(headPos.RotateHead.eulerAngles.x,0f,30f);
		} 
		if(head.localEulerAngles.x < 360 && headPos.RotateHead.eulerAngles.x > 90) {
			rotateHead.x = 	Mathf.Clamp(headPos.RotateHead.eulerAngles.x,350f,360f);
		}


		rotateHead.y = headPos.RotateHead.eulerAngles.y;

		posCam.eulerAngles = rotateHead;


	}

	float map(float x, float in_min, float in_max, float out_min, float out_max)
	{
		return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
	}

}
