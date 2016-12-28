using UnityEngine;
using System.Collections;

public class Fly : MonoBehaviour
{

    public GameObject cam;
    public GameObject player;
             
    private Vector3 offset;

    public float lookSpeed = 5.0f;
    public float moveSpeed = 1.0f;
    public float rotationX = 0.0f;
    public float rotationY = 0.0f;


    private Vector3 MousePos;
    private float MyAngle = 0F;





    // Use this for initialization
    void Start()
    {
        offset = transform.position;
        rotationX = cam.transform.localEulerAngles.y;
        rotationY = cam.transform.localEulerAngles.x;
                  
    }
             

    // Update is called once per frame
    void Update()
    {
     
            cam.transform.position += cam.transform.forward * moveSpeed * Input.GetAxis("Vertical");
            cam.transform.position += cam.transform.right * moveSpeed * Input.GetAxis("Horizontal");
            if (cam.transform.position.y < 1.0f)
            cam.transform.position = new Vector3(cam.transform.position.x, 1.0f, cam.transform.position.x);
       
            if (Input.GetMouseButton(1))
            {
                rotationX += Input.GetAxis("Mouse X") * lookSpeed;
                rotationY += Input.GetAxis("Mouse Y") * lookSpeed;
                //rotationY = Mathf.Clamp(rotationY, 270, 90);

                cam.transform.localRotation =  Quaternion.AngleAxis(rotationX, Vector3.up);
                cam.transform.localRotation *= Quaternion.AngleAxis(rotationY, Vector3.left);
            }
            
    }
}
