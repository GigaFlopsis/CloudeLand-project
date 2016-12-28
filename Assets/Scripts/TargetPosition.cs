using UnityEngine;
using System.Collections;

public class TargetPosition : MonoBehaviour {

    public GameObject TargetPlayer;
    public bool forCam = true;
    public Vector3 error;
    private Vector3 pos;
    // Update is called once per frame
	private float posY;
    private Quaternion targetAngle;

    void Setup()
    {
        pos = transform.position;

    }

    void Update () {
        //для ANPA
       if(!forCam)
        {

            pos = TargetPlayer.transform.position;

            transform.position = pos;
            targetAngle = TargetPlayer.transform.rotation;

            targetAngle.x = 0f;
            targetAngle.z = 0f;


            transform.rotation = Quaternion.Lerp(transform.rotation, targetAngle, 1f);

        }



        //для камеры
        if (forCam)
        {
			posY = Mathf.Lerp (pos.y, TargetPlayer.transform.position.y, Time.deltaTime);

			pos = new Vector3(TargetPlayer.transform.position.x, posY, TargetPlayer.transform.position.z);

            transform.position = pos;
                                                 
    
    }

        //для 


        }
}
