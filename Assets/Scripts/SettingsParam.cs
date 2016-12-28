using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SettingsParam : MonoBehaviour {

 
    public Toggle vrMod;
    public Toggle blur;
	public Toggle sound;

	private LevelParam level;
	private SwitchVRMode vr;
	private VolumSound soundParam;

    // Use this for initialization
	void Start () {
        level = FindObjectOfType<LevelParam>();
        vr = FindObjectOfType<SwitchVRMode>();
		soundParam = FindObjectOfType<VolumSound>();

    }

    void OnGUI()
    {
        vrMod.isOn = vr.VRModeState();
		blur.isOn = level.motionBlur;
		sound.isOn =  !soundParam.SoundState();
    }

    public void ToggleVRMode(bool state)
    {
        vr.ToggleVRMode(state);
    }

    public void ToggleBlur(bool state)
    {
        level.EnableMotionBlur(state);
    }

	public void ToggleSoundMode(bool state)
	{
		soundParam.ToggleSoundModeState (!state);
	}


}
