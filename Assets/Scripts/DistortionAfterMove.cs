using UnityEngine;
using System.Collections;

public class DistortionAfterMove : MonoBehaviour {

    [SerializeField]
    private float time = 5f;
    private Vector3 originPos;
    private bool destroy = false;

    // Use this for initialization
    void Start () {
        originPos = transform.position;
	
	}
	
	// Update is called once per frame
	void Update () {
        if (originPos != transform.position && !destroy)
            DestroyObject();

    }



    void DestroyObject()
    {
        destroy = true;
        Destroy(gameObject, time);
    }

}
