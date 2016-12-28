using UnityEngine;
using System.Collections;

public class FinishParam : MonoBehaviour {

    public string NextLevel = "Level_2";
    public AudioClip song;
    public AudioSource AudioSource;

    private LevelParam level;
    private bool tritter = false;

    void Start()
    {
        level = FindObjectOfType<LevelParam>();
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !tritter)
        {
            level.Finish();
            PlaySong();
            tritter = true;
           level.LoadNextLevel(NextLevel);
	    }

    }



    public void PlaySong()
    {
        AudioSource.clip = song;
        AudioSource.Play();
    }
}
