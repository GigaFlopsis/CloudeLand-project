using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerLookatRotation : MonoBehaviour {

	public Transform main;
	public Transform rotate;

	public Text TimerText;
	public float delay = 0f;

	public float headAngle = 340f;
	public float speed = 5;

	public Color colorInvs;
	public Color colorVis;
	private float timerDelay = 0f;
	private Quaternion mainRotate;

	private Vector3 lookUp;
	// Use this for initialization
	void Start () {
	}
		
	// Update is called once per frame
	void Update () {
		AlphaChenge();
		mainRotate = main.localRotation;
		mainRotate.x = 0;
		mainRotate.z = 0;
		rotate.localRotation = mainRotate;

}

	void AlphaChenge()
	{

		if(main.localEulerAngles.x >= headAngle || main.localEulerAngles.x <= 180) {
			timerDelay += Time.deltaTime;
		}


		if(main.localEulerAngles.x >= headAngle || main.localEulerAngles.x <= 180 && timerDelay > delay) {
			TimerText.color = Color.Lerp(TimerText.color, colorInvs, Time.deltaTime*speed);	
		}
		if(main.localEulerAngles.x < headAngle && main.localEulerAngles.x > 180) {
			timerDelay = 0f;
			TimerText.color = Color.Lerp(TimerText.color, colorVis, Time.deltaTime*speed);	


		}
			
	}

}
