using UnityEngine;
using System.Collections;

public class RespawnPlayer : MonoBehaviour {

	public Transform resPos;
	public AudioClip clip;
	private AudioSource sound;


	void Start(){
		if (clip != null) {
			sound = gameObject.AddComponent<AudioSource> ();
		}
	
	}
	void OnTriggerEnter(Collider collision)
	{
		if (collision.gameObject.tag == "Player") {
			collision.gameObject.transform.position = resPos.transform.position;
		
			if (clip != null) {
				sound.clip = clip;
				sound.Play ();
			}
		}
	}
}
