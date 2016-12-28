using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Timer : MonoBehaviour {

	[SerializeField]
	bool play = false;
	public Text TimerGUI;

	string CoutTimer = "";

	public float timersecond = 0; // проверка отчёта секунд в Inspector
		

	void Update () { // обновляет код каждый кадр

		if(play){
			timersecond += Time.deltaTime;
		}

		CoutTimer = Minutes().ToString("00") + ":" + Second().ToString("00") + ":" + Millis(); 
//		Debug.Log(CoutTimer);
	

	}


	void OnGUI()
	{
		if(TimerGUI != null)
		{
			TimerGUI.text = CoutTimer;
		}
	}


	public int Minutes()
	{
		return (int)timersecond/60;
	}
	public int Second()
	{
		return (int)timersecond%60;
	}
	public int Millis()
	{
		return  (int)System.Math.Truncate(timersecond%1*10);
	}

	public void Play(bool state)
	{
		play = state;
	}

	public void ResetTimer()
	{
		timersecond = 0;
	}
    public void Stop(int nLevel) {
        string name = "Level_" + nLevel.ToString() + "_Time";

        PlayerPrefs.SetFloat(name, timersecond);
        PlayerPrefs.Save();
    }



}