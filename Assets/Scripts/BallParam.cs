using UnityEngine;
using System.Collections;

public class BallParam : MonoBehaviour {

    private LevelParam level;
    public AudioClip song;
    public AudioSource AudioSource;

    private bool tritter = false;

    void Start()
    {
        level = FindObjectOfType<LevelParam>();
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !tritter)
        {
            level.AddStar();
            PlaySong();
            Destroy(gameObject,1F);
            tritter = true;
        }

        
    }

    public void PlaySong()
    {
        AudioSource.clip = song;
        AudioSource.Play();
    }
}
