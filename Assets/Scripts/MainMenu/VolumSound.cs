using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VolumSound : MonoBehaviour {

    public Image icon;
    public Sprite muteImg;
    public Sprite volumImg;

    public bool audioMute = false;
    // Use this for initialization
    void Start () {

        if (PlayerPrefs.HasKey("AudioMute"))
        {
            AudioListener.pause = PlayerPrefs.GetInt("AudioMute") > 0 ? true : false;
            audioMute = AudioListener.pause;
        }
        else
        {
            AudioListener.pause = audioMute;
        }
        ChengeIcon();

    }

    void update()
    {
        if (AudioListener.pause != audioMute)
        {
            ChengeIcon();
            AudioListener.pause = audioMute;
        }
            
    }

    public void ChengeIcon()
    {
        if (AudioListener.pause)
        {
            PlayerPrefs.SetInt("AudioMute", AudioListener.pause == true ? 1 : 0);
           
			if(icon != null)	icon.sprite = muteImg;
            audioMute = AudioListener.pause;

        }
        if (!AudioListener.pause)
        {
            PlayerPrefs.SetInt("AudioMute", AudioListener.pause == true ? 1 : 0);
			if(icon != null) icon.sprite = volumImg;
            audioMute = AudioListener.pause;
        }
        PlayerPrefs.Save();
    }

    public void ToggleSoundMode()
    {
        AudioListener.pause = !AudioListener.pause;
        ChengeIcon();
    }


	public void ToggleSoundModeState(bool state)
	{
		AudioListener.pause = state;
		ChengeIcon();
	}

	public bool SoundState()
	{
		return AudioListener.pause;
	}

}
