using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class JukeBoxLogic : MonoBehaviour 
{
    private GlobalData globalData;

    private AudioSource audioSource;

    public AudioClip menuMusic;
    public AudioClip playingMusic1;
    public AudioClip playingMusic2;
    public AudioClip playingMusic3;
    public AudioClip endMusic;

    void Awake()
    {
        globalData = GameObject.Find("GlobalData").GetComponent<GlobalData>();
        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(transform.gameObject);
        gameObject.SendMessage("OnLevelWasLoaded", SceneManager.GetActiveScene().buildIndex);
    }

	// Use this for initialization
	void Start () 
    {
        
	}

    void OnLevelWasLoaded(int level)
    {
        if (level == 1)
        {
            Debug.Log("isPlaying::" + audioSource.isPlaying);
            if (!audioSource.isPlaying)
            {
                Debug.Log("Started Playing");
                audioSource.clip = menuMusic;
                audioSource.Play();
                audioSource.loop = true;
            }
        }
        if(level == 4)
        {
            audioSource.clip = GetRandomPlayingSong();
            audioSource.Play();
            audioSource.loop = false;
        }
        if(level == 5)
        {
            audioSource.clip = endMusic;
            audioSource.Play();
            audioSource.loop = true;
        }
    }
	
    AudioClip GetRandomPlayingSong()
    {
        int randomSong = globalData.globRandom.Next(1, 3);
        if (randomSong == 1)
            return playingMusic1;
        else if (randomSong == 2)
            return playingMusic2;
        else if (randomSong == 3)
            return playingMusic3;
        else
            return playingMusic1;
    }

	// Update is called once per frame
	void Update () 
    {
	}
}
