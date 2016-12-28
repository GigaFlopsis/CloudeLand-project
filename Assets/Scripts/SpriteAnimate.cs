using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpriteAnimate : MonoBehaviour {

	private Image image;
	private SpriteRenderer spriteRenderer;


	void Start(){
		image = GetComponent<Image>();
		spriteRenderer = GetComponent<SpriteRenderer>();
	
	}

	void OnGUI() {
		image.sprite = spriteRenderer.sprite;
	}

	/*
	public Sprite lastSprite;
	private string nameSprite;
	private string nameSpriteNew;
	private string[] massStr;
	int sizeSprite;



	// Use this for initialization
	void 1Start() {
		nameSprite = lastSprite.name;
		massStr = nameSprite.Split (new char[]{ '_' }); 
		sizeSprite = int.Parse(massStr [massStr.Length - 1]);

		StartCoroutine(PrintAllSprite (0.5f));
	}
	

	IEnumerator PrintAllSprite(float delay) {
		for(int k = 0; k<=sizeSprite;k++)
		{
		for(int i=0; i<massStr.Length-1;i++){
				nameSpriteNew = nameSpriteNew + massStr[i]; 
		}
			nameSpriteNew = nameSpriteNew + "_" + k;
			Sprite newSprite = Resources.Load (nameSpriteNew, typeof(Sprite)) as Sprite;
			image.sprite = newSprite;
			nameSpriteNew = null;
			yield return new WaitForSeconds (delay);
		}
	}
*/

}
