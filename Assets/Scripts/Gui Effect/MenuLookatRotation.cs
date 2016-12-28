using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuLookatRotation : MonoBehaviour {
	public float minAlpfa = 0f;
	public float maxAlpfa = 1f;

	public Transform main;
	public Transform rotate;


	public Image[] MassMenu;

	public float delayEnable = 1f;


	public float headAngle = 80f;
	public float speed = 5;

    //tille menu 
    public GameObject menuTile;
    private Vector2 originalSizeMenu;
    private RectTransform menuTileRect;
    public bool openMenu = false;
    private bool tileMenuOpensState = true;

    private Color colorInvs;
	private Color colorVis;

	private bool stopCoroutine = true;
	private bool visible = true;

	private Quaternion mainRotate;

	public GameObject[] childObject;
	private MovePlayer player;

    void Start()
    {
        menuTileRect = menuTile.GetComponent<RectTransform>();
		player = FindObjectOfType<MovePlayer> ();
		originalSizeMenu = menuTileRect.sizeDelta;
        OpenTileMenu(openMenu);
    }


	void Update () {
		
		AlphaChenge();

		//EnableChildren();
		if(stopCoroutine)
		StartCoroutine(EnableObjectGUI());
            
		if (menuTile.active) {
			player.EnableMove (false);
		} else {
			player.EnableMove (true);

		}

	}



	IEnumerator EnableObjectGUI()
	{
		stopCoroutine = false;

		if(main.localEulerAngles.x <= 40 || main.localEulerAngles.x >= 180) {
			yield return new WaitForSeconds(delayEnable);

		if(main.localEulerAngles.x > 40 && main.localEulerAngles.x < 180) {
				stopCoroutine = true;
				yield break;
			}
			visible = false;

			yield return new WaitForSeconds(delayEnable);
			for(int i = 0; i < childObject.Length; i++)
			{
				childObject[i].active = false;
				yield return null;
			}
				
			stopCoroutine = true;
			yield break;
		}

	/*****************/
		if(main.localEulerAngles.x > headAngle && main.localEulerAngles.x < 180) {
			yield return new WaitForSeconds(delayEnable);

			if(main.localEulerAngles.x < headAngle || main.localEulerAngles.x >= 180) {
				stopCoroutine = true;
				yield break;
			}

			for(int i = 0; i < childObject.Length; i++)
			{
				childObject[i].active = true;
				yield return null;
			}

			visible = true;
			stopCoroutine = true;
			yield break;		
		}

		stopCoroutine = true;
		yield break;
	}



	//open menu
    public void OpenTileMenu(bool state)
    {
        if (tileMenuOpensState)
            StartCoroutine(OpenTileMenuCoroutine(state));
    }
	// lerp open menu
    IEnumerator OpenTileMenuCoroutine(bool state)
        {
        openMenu = state;
        tileMenuOpensState = false;
            if (!state)
            {
                while ((int)menuTileRect.sizeDelta.x > Time.deltaTime+3f)
                {
                    menuTileRect.sizeDelta = Vector2.Lerp(menuTileRect.sizeDelta, Vector2.zero, Time.deltaTime * speed);
                    yield return null;
                }
                menuTileRect.sizeDelta = Vector2.zero;
               menuTile.active = false;
        }
            if (state)
            {
            menuTile.active = true;
            while (menuTileRect.sizeDelta.x < (originalSizeMenu.x-3f))
                {
                    menuTileRect.sizeDelta = Vector2.Lerp(menuTileRect.sizeDelta, originalSizeMenu, Time.deltaTime * speed);
                    yield return null;
            }
            menuTileRect.sizeDelta = originalSizeMenu;
            }
        tileMenuOpensState = true;
        }



	void AlphaChenge() // изменение прозрачности 
	{
		
	for(int i = 0; i < MassMenu.Length; i++)
		{
			colorInvs = MassMenu[i].color;
			colorVis = colorInvs;  
			colorVis.a = maxAlpfa;
			colorInvs.a = minAlpfa;
		
			
			if(main.localEulerAngles.x >= headAngle-5 && !openMenu) {
				Rotate(0.5f);
			}
		
			if(main.localEulerAngles.x >= headAngle  && main.localEulerAngles.x < 180 && visible ) {
			MassMenu[i].color = Color.Lerp(MassMenu[i].color, colorVis, Time.deltaTime*speed);	
			}

			if(main.localEulerAngles.x < 45 && !visible && !openMenu) {
				MassMenu[i].color = Color.Lerp(MassMenu[i].color, colorInvs, Time.deltaTime*speed);	
				Rotate(5f);
			}
	
		}
	}
		



	void Rotate(float speed){
		mainRotate = main.localRotation;
		mainRotate.x = 0;
		mainRotate.z = 0;
		rotate.localRotation = Quaternion.Lerp(rotate.localRotation, mainRotate, Time.deltaTime*speed);
	}


    public void OpenMenu(bool state) {
        openMenu = state;
    }

}
