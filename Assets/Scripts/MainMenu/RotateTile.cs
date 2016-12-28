using UnityEngine;
using System.Collections;

public class RotateTile : MonoBehaviour {

    

    public Transform cam;
    public float speed = 1f;

    bool look = false;

    Quaternion mainRotate;

    void Start() {
        mainRotate = gameObject.transform.rotation;

    }

    void Update()
    {
        if (look)
        {
            Quaternion lookCam = Quaternion.LookRotation(gameObject.transform.position, cam.transform.position);
            transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, lookCam, Time.deltaTime * speed);
        }
        else {
            transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, mainRotate, Time.deltaTime * speed);
        }

    }


    public void LookState(bool state)
    {
        look = state;
    }


}
