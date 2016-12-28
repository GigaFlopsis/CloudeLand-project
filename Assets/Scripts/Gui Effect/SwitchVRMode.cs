using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Collider))]
public class SwitchVRMode : MonoBehaviour, IGvrGazeResponder {

	public Sprite vrOn;
	public Sprite vrOff;
	public Image imageVR;

    public bool vr;

    void Start() {
		vr = (PlayerPrefs.GetInt("VRMode") > 0 ? true : false);
        GvrViewer.Instance.VRModeEnabled = vr;
        ChengeIcon();
    }

    public void ToggleVRMode() {
        GvrViewer.Instance.VRModeEnabled = !GvrViewer.Instance.VRModeEnabled;
		ChengeIcon();
    }

    public void ToggleVRMode(bool state)
    {
        GvrViewer.Instance.VRModeEnabled = state;
        ChengeIcon();
    }
    


    public bool VRModeState()
    {
        return GvrViewer.Instance.VRModeEnabled;
    }


    public void ChengeIcon()
	{
		if(GvrViewer.Instance.VRModeEnabled)
		{
			PlayerPrefs.SetInt("VRMode", GvrViewer.Instance.VRModeEnabled == true ? 1 : 0); 
			imageVR.sprite = vrOn;

		}
		if(!GvrViewer.Instance.VRModeEnabled)
		{
			PlayerPrefs.SetInt("VRMode", GvrViewer.Instance.VRModeEnabled == true ? 1 : 0);
			imageVR.sprite = vrOff;
		}
		PlayerPrefs.Save();
	}

	#region IGvrGazeResponder implementation

	/// Called when the user is looking on a GameObject with this script,
	/// as long as it is set to an appropriate layer (see GvrGaze).
	public void OnGazeEnter() {
	}

	/// Called when the user stops looking on the GameObject, after OnGazeEnter
	/// was already called.
	public void OnGazeExit() {
	}

	/// Called when the viewer's trigger is used, between OnGazeEnter and OnGazeExit.
	public void OnGazeTrigger() {
	}

	#endregion
}
