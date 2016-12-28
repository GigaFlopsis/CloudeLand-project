using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VisibleEffect : MonoBehaviour {


	public Image im;
	public GameObject[] objects;
	public GameObject sprite;
	public float speed = 10f;

	void OnTriggerEnter(Collider trigger)
	{
		if (trigger.tag == "Player")
		{
			StartCoroutine(VisibleGUI (objects, true));
		}
	}


	void OnTriggerExit(Collider trigger)
	{
		if (trigger.tag == "Player")
		{
			// unvisible code
			StartCoroutine(VisibleGUI (objects, false));

		}
	}
		

	IEnumerator VisibleGUI(GameObject[] objects, bool state)
	{
		if (state) {
			//on objects	
			if(objects.Length != null)
			 {
				for (int i = 0; i < objects.Length; i++)
					objects[i].active = state;
			}

				Color targetColor = im.color;
				targetColor.a = 0;
				im.color = targetColor;
				targetColor.a = 1.2f;

				while (im.color.a < 1f) {
					im.color = Color.Lerp (im.color, targetColor, Time.deltaTime * speed);
					yield return null;
				}
			if(sprite != null) 	sprite.active = true;
			}
		if (!state) {

			// off objects	
			if(sprite != null)  sprite.active = false;

			if(objects.Length != null)
			{
				for (int i = 0; i < objects.Length; i++)
					objects[i].active = state;
			}

			Color targetColor = im.color;
			targetColor.a = 1;
			im.color = targetColor;
			targetColor.a = -0.2f;

			while (im.color.a > 0f) {
				im.color = Color.Lerp (im.color, targetColor, Time.deltaTime * speed);
				yield return null;
			}


		}
			


	}

}
