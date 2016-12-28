using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class MovePlayer : MonoBehaviour {

	public GameObject head;
	public GameObject objectMove;


	[Space(20)]
	public float powerForward = 1f;
	public float powerJump = 1f;
	public float powerMove = 1f;

	[Space(20)]
	public bool enableMove = true;
    public bool fly;
	public bool lookAtGui = false;


	[Space(20)]
    public float jumpSpeed = 10f;
    private float jumpPower;
    public Slider sliderPower;

	[Space(20)]
	[SerializeField] 
	private AudioClip m_LandSound;
	[SerializeField]
	private AudioClip m_JumpSound;           // the sound played when character leaves the ground.
	[SerializeField] 
	private AudioClip[] m_FootstepSounds;
    [SerializeField]
    private AudioClip m_Fly;
    private AudioSource m_AudioSource;

	private float forceMove;
	private bool jumpState = true;
	private float delay = 0;
	private float speed;
	private Rigidbody rb;
	private Vector3 mVect;
	private string collisionName;
	private string HitName;
	private bool stopCoroutine = true;




	// Use this for initialization
	void Start () {
		m_AudioSource = GetComponent<AudioSource>();
		rb = objectMove.GetComponent<Rigidbody>();
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = false;
	}


	void OnTriggerEnter()
	{
		PlayLandingSound();
	}


	void OnCollisionEnter(Collision collision)
	{

		ContactPoint contact = collision.contacts[0];
		mVect = Vector3.Reflect(head.transform.forward.normalized, contact.normal);
		collisionName = collision.collider.name;
	}

	void OnTriggerStay(Collider other)
	{
		if (!lookAtGui) {
			enableMove = true;
			if (stopCoroutine)
				StartCoroutine (SwitchJumpState (true));
		} else {
			enableMove = false;
			jumpState = false;
		
		}
	}


	void FixedUpdate () {

        if(sliderPower != null)
        {   sliderPower.value = jumpPower; }


        if (!jumpState && fly)
        {
            if ((int)jumpPower < 99)
            {
                jumpPower = Mathf.Lerp(jumpPower, 100f, Time.deltaTime * jumpSpeed);
             //   Quaternion rotatePlayer = Quaternion.LookRotation(head.transform.position, transform.position);

             //   transform.rotation = Quaternion.Lerp(transform.rotation, rotatePlayer, Time.deltaTime * jumpSpeed);
                
                // Debug.Log("jumpPower: " + jumpPower);
            }
            else {
                jumpState = true;
                jumpPower = 100;
            }
        }


        if (fly)
        {
            if (Input.GetMouseButton(0))
            enableMove = false;
           
        }

		//если смотрит не на объект с которым столкнулся
		RaycastHit hit;
		if (Physics.Raycast(head.transform.position, head.transform.forward, out hit, 10.0f))
			HitName = hit.collider.name;

       // if (!enableMove)
       // {
       //     jumpState = false;
       // }
                                               
		if(Input.GetMouseButton(0) && enableMove)
		{
			delay += Time.fixedDeltaTime;
            rb.AddForce(head.transform.forward.normalized*Mathf.Lerp(forceMove, powerMove, Time.fixedDeltaTime*30f));
            PlayFootStepAudio();
		}

        if (Input.GetMouseButtonUp(0) && jumpState && delay < 0.2f) // jump to button 
        {
            if (fly)
            {
                rb.AddForce(head.transform.forward.normalized * powerForward, ForceMode.Impulse);
            }
            if (!fly)
            {
                if (head.transform.localEulerAngles.x > 70 && head.transform.localEulerAngles.x < 180)
                {
                    rb.AddForce(objectMove.transform.up.normalized * powerJump, ForceMode.Impulse);
                }
                else {
                    rb.AddForce(head.transform.forward.normalized * powerForward, ForceMode.Impulse);
                    rb.AddForce(objectMove.transform.up.normalized * powerJump, ForceMode.Impulse);
                }

                if (collisionName == HitName && (head.transform.localEulerAngles.x < 70 || head.transform.localEulerAngles.x > 180))
                {
                    rb.GetComponent<Rigidbody>().AddForce(mVect.normalized * powerJump, ForceMode.Impulse);
                }
            }
            jumpState = false;
            jumpPower = 0;
            PlayJumpSound();
        }

        if (Input.GetMouseButtonUp(0))
        {
            delay = 0f;
            forceMove = 0;
        }
        enableMove = false;
	}



	IEnumerator SwitchJumpState(bool state)
	{
		stopCoroutine = false;
        jumpState = true;
        yield return new WaitForSeconds(1f);
        stopCoroutine = true;
	}



	public void EnableMove(bool state)
	{
		lookAtGui = !state;
		enableMove = state;
        if(!state)
        jumpState = false;
    }

	private void PlayJumpSound()
	{
	//	m_AudioSource.clip = m_JumpSound;
	//	m_AudioSource.Play();
		m_AudioSource.PlayOneShot(m_JumpSound, 0.05f);
	}
		
	private void PlayLandingSound()
	{
		//m_AudioSource.clip = m_LandSound;
		//m_AudioSource.Play();
		m_AudioSource.PlayOneShot(m_LandSound, 0.5f);
	}

    private void PlayFlySound()
    {
		m_AudioSource.PlayOneShot(m_Fly, 1f);
    }

    private void PlayFootStepAudio()
	{
		if (rb.velocity.magnitude == 0)
		{
			return;
		}
		if(delay%0.4 <= 0.02)
		{
		// pick & play a random footstep sound from the array,
		// excluding sound at index 0
		int n = Random.Range(1, m_FootstepSounds.Length);
		m_AudioSource.clip = m_FootstepSounds[n];
		m_AudioSource.PlayOneShot(m_AudioSource.clip);
		// move picked sound to index 0 so it's not picked next time
		m_FootstepSounds[n] = m_FootstepSounds[0];
		m_FootstepSounds[0] = m_AudioSource.clip;
		}
		}


 
}