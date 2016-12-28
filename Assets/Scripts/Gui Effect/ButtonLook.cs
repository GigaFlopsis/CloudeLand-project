using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonLook : MonoBehaviour {


	public GameObject obj;

	public float speed = 5f;
	[Space(15)]
	private Image image;
	public Color color2;
	public float speedColor = 30f;

	private Color color1;

	bool pushState = false;
	private bool look = false;
	private Vector3 lookPos;


	void Start()
	{
		image = GetComponent<Image>();
	}
	void Update () {


		lookPos = obj.transform.localEulerAngles;
		if(look)
		{
			lookPos.x = 80f;
			obj.transform.localEulerAngles = Vector3.Lerp(obj.transform.localEulerAngles,lookPos,Time.deltaTime * speed);  
		}
		if(!look)
		{
			lookPos.x = 90f;
			obj.transform.localEulerAngles = Vector3.Lerp(obj.transform.localEulerAngles,lookPos,Time.deltaTime * speed);  
				
		}
			
	}

	public void Look(bool state)
	{
		look = state;
	}


	public void Push()
	{
	
		if(!pushState)
	StartCoroutine(PushCoroutine());
	}


	IEnumerator PushCoroutine()
	{
		pushState = true;
		color1 = image.color;
		while(image.color != color2)
		{
			image.color = Color.Lerp(image.color, color2, Time.deltaTime*speedColor);
			yield return new WaitForFixedUpdate();
		}
		while(image.color != color1)
		{
			image.color = Color.Lerp(image.color, color1, Time.deltaTime*speedColor);
			yield return new WaitForFixedUpdate();
		}
		pushState = false;
		yield return null;

	}

}
