//Author: Jesus Villagomez - JesseDotEXE
//References: N/A

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public AudioClip menuMusic;
    public AudioClip playingMusic1;
    public AudioClip playingMusic2;
    public AudioClip playingMusic3;
    public AudioClip endMusic;

    private GlobalData globalData;
    private AudioSource audioSource;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);

        globalData = GameObject.Find("GlobalData").GetComponent<GlobalData>();
        audioSource = GetComponent<AudioSource>();

        gameObject.SendMessage("OnLevelWasLoaded", SceneManager.GetActiveScene().buildIndex);
    }

    void OnLevelWasLoaded(int level)
    {
        if(level == 1)
        {
            if(!audioSource.isPlaying)
            {
                audioSource.clip = menuMusic;
                audioSource.Play();
                audioSource.loop = true;
            }
        }
        if(level == 4)
        {
            audioSource.clip = GetRandomPlayingSong();
            audioSource.Play();
            audioSource.loop = true;
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
        int randomSong = globalData.globalRandom.Next(1, 3);
        if(randomSong == 1)
        {
            return playingMusic1;
        }
        else if(randomSong == 2)
        {
            return playingMusic2;
        }
        else if(randomSong == 3)
        {
            return playingMusic3;
        }
        else
        {
            return playingMusic1;
        }
    }

    public void StopPlaying()
    {
        audioSource.Stop();
    }
}
