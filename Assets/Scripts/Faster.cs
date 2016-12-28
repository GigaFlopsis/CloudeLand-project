using UnityEngine;
using System.Collections;

public class Faster : MonoBehaviour {

	public enum typeDerection {player, fasterPlane};
	public typeDerection derectForce;

	public ForceMode forceMode;
	public float power;

	private Vector3 vecForvard;
	private bool faster = false;
	private Rigidbody rb;

	public AudioClip clip;
	private AudioSource sound;

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Player") {
			rb	= collision.gameObject.GetComponent<Rigidbody> ();
		}
		if (clip != null) {
			sound.clip = clip;
			sound.Play();
		}
	}

	void OnCollisionStay(Collision collision)
	{
		if (collision.gameObject.tag == "Player") {

			switch (derectForce) {
			case typeDerection.fasterPlane:
				vecForvard = transform.forward.normalized;
				break;
			case typeDerection.player:
				vecForvard = collision.gameObject.transform.forward.normalized;
				break;
			}
			vecForvard = collision.gameObject.transform.forward.normalized;
			rb.AddForce(vecForvard*power, forceMode);
		}
	}


	// Use this for initialization
	void Start () {
		if (clip != null) {
			sound = gameObject.AddComponent<AudioSource> ();
		}

		//forceMode = ForceMode.Impulse;
		//derectForce = typeDerection.player;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
