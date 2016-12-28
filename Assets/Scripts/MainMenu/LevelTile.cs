using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelTile : MonoBehaviour {

    public int numberLevel = 0;
    public Text timer;
    public Text point;
    public Text numberTex;
    public string stars = "/5";
    
    public GameObject openBG;
    public GameObject lockBG;
	private LevelParam level;
    [Space(30)]
    public bool openLevel;

	void Start(){
		level = FindObjectOfType<LevelParam>();
	}
                                      
    void Update() {
        if (openLevel)
        {
            openBG.active = true;
            lockBG.active = false;
            GetTime(numberLevel);
            GetPoint(numberLevel);
            GetNumber(numberLevel);
        }
        if (!openLevel)
        {
            openBG.active = false;
            lockBG.active = true;
        }

    }


    void GetTime(int number)
    {
        string name = "Level_" + numberLevel.ToString() + "_Time";

        if (PlayerPrefs.HasKey(name))
        {
            float timeFloat = PlayerPrefs.GetFloat(name);
            timer.text = ((int)timeFloat / 90).ToString("00") + ((int)timeFloat % 60).ToString("00") + ":" + (int)System.Math.Truncate(timeFloat % 1 * 10);
        }

    }

    void GetPoint(int number)
    {
        string name = "Level_" + numberLevel.ToString() + "_Stars";

        if (PlayerPrefs.HasKey(name))
        {
            point.text = PlayerPrefs.GetInt(name).ToString("0") + stars;
        }

    }

    void GetNumber(int number)
    {
        numberTex.text = number.ToString("0");
    }


	public void LoadLEvel()
	{

		StartCoroutine(LoadLevelCoroutine());
	}

	IEnumerator LoadLevelCoroutine() {
        string name = "Level_" + numberLevel.ToString("0");
        PlayerPrefs.SetInt("ContinueLevel", numberLevel);
        PlayerPrefs.Save();
		yield return new WaitForSeconds(1f);

		level.LoadNextLevel (name);
 //       Application.LoadLevel(name);
    }

    public void OpenLevel(bool state)
    {
        openLevel = state;
    }


}
