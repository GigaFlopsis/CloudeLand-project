using UnityEngine;
using System.Collections;

public class MainMenuLogic : MonoBehaviour
{

    public RectTransform menuCanvas;
    public RectTransform levelCanvas;
    public RectTransform settingsCanvas;

    public float speed = 5f;

    private enum stateMenu {main, level, settings};
    private stateMenu openTile;
                              
    private Vector2 menuSizeDelta;
    private Vector2 levelSizeDelta;
    private Vector2 settingsSizeDelta;

    bool mainMenuOpensState = true;
    bool settingsOpensState = true;

	[Space(20)]
	public AudioClip openTileClip;
	public AudioClip closeTileClip;
	public AudioClip lookTileClip;
	public AudioClip lockTileClip;

	[Space(20)]
	public AudioSource menuSourse;

    // Use this for initialization
    void Awake()
    {
        menuSizeDelta = menuCanvas.sizeDelta;
        levelSizeDelta = levelCanvas.sizeDelta;
        settingsSizeDelta = settingsCanvas.sizeDelta;
        levelCanvas.sizeDelta = Vector2.zero;
        settingsCanvas.sizeDelta = Vector2.zero;
        //MenuOpen(true);
        //SettingsOpen(false);
        openTile = stateMenu.main;
    }
		

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("escape"))
        {
            switch (openTile) {
                case stateMenu.main:
                    break;
                case stateMenu.level:
                    MenuOpen(true);
                    break;
                case stateMenu.settings:
                    SettingsOpen(false);
                    break;
            }
        }
    }



    public void MenuOpen(bool state)
    {
        if (mainMenuOpensState)
            StartCoroutine(mainMenuOpen(state));
    }

    public void SettingsOpen(bool state)
    {
        if (settingsOpensState)
            StartCoroutine(SettingsTilesOpen(state));
    }

    IEnumerator mainMenuOpen(bool state)
    {
        mainMenuOpensState = false;
            if (state)
            {
            while (levelCanvas.sizeDelta.x > Time.deltaTime && levelCanvas.sizeDelta.y > Time.deltaTime)
            {

                levelCanvas.sizeDelta = Vector2.Lerp(levelCanvas.sizeDelta, Vector2.zero, Time.deltaTime * speed);
                    yield return null;
                }
            levelCanvas.sizeDelta = Vector2.zero;
            while ((int)menuCanvas.sizeDelta.x < menuSizeDelta.x-2f || (int)menuCanvas.sizeDelta.y < menuSizeDelta.y-2f)
            {
                menuCanvas.sizeDelta = Vector2.Lerp(menuCanvas.sizeDelta, menuSizeDelta, Time.deltaTime * speed);
                    yield return null;
             }
            openTile = stateMenu.main;
            }
        if (!state)
        {
            while (menuCanvas.sizeDelta.x > Time.deltaTime && menuCanvas.sizeDelta.y > Time.deltaTime)
            {
                menuCanvas.sizeDelta = Vector2.Lerp(menuCanvas.sizeDelta, Vector2.zero, Time.deltaTime * speed);
                yield return null;

            }
            menuCanvas.sizeDelta = Vector2.zero;

            while ((int)levelCanvas.sizeDelta.x < levelSizeDelta.x-2f || (int)levelCanvas.sizeDelta.y < levelSizeDelta.y - 2f)
            {
                levelCanvas.sizeDelta = Vector2.Lerp(levelCanvas.sizeDelta, levelSizeDelta, Time.deltaTime * speed);
                yield return null;
            }
            openTile = stateMenu.level;
        }
        mainMenuOpensState = true;
    }

    IEnumerator SettingsTilesOpen(bool state)
    {
        settingsOpensState = false;
        if (!state)
        {
            while (settingsCanvas.sizeDelta.x > Time.deltaTime && settingsCanvas.sizeDelta.y > Time.deltaTime)
            {

                settingsCanvas.sizeDelta = Vector2.Lerp(settingsCanvas.sizeDelta, Vector2.zero, Time.deltaTime * speed);
                yield return null;
            }
            settingsCanvas.sizeDelta = Vector2.zero;
            while ((int)menuCanvas.sizeDelta.x < menuSizeDelta.x - 2f || (int)menuCanvas.sizeDelta.y < menuSizeDelta.y - 2f)
            {
                menuCanvas.sizeDelta = Vector2.Lerp(menuCanvas.sizeDelta, menuSizeDelta, Time.deltaTime * speed);
                yield return null;
            }
            openTile = stateMenu.main;
        }

        if (state)
        {
            while (menuCanvas.sizeDelta.x > Time.deltaTime && menuCanvas.sizeDelta.y > Time.deltaTime)
            {
                menuCanvas.sizeDelta = Vector2.Lerp(menuCanvas.sizeDelta, Vector2.zero, Time.deltaTime * speed);
                yield return null;

            }
            menuCanvas.sizeDelta = Vector2.zero;
            while ((int)settingsCanvas.sizeDelta.x < settingsSizeDelta.x - 2f || (int)settingsCanvas.sizeDelta.y < settingsSizeDelta.y - 2f)
            {
                settingsCanvas.sizeDelta = Vector2.Lerp(settingsCanvas.sizeDelta, settingsSizeDelta, Time.deltaTime * speed);
                yield return null;
            }
            openTile = stateMenu.settings;
        }
        settingsOpensState = true;
    }

//play menu sound 
	public void PlayOpenMenu()
	{
		menuSourse.PlayOneShot(openTileClip, 0.8f);
	}

	public void PlayCloseMenu()
	{
		menuSourse.PlayOneShot(closeTileClip, 1f);
	}
	public void PlayLookSound()
	{
		menuSourse.PlayOneShot(lookTileClip, 0.5f);
	}

	public void PlayLockSound()
	{
		menuSourse.PlayOneShot(lockTileClip, 0.5f);
	}



}