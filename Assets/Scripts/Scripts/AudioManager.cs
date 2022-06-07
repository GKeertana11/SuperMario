using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region PUBLIC VARIABLES
    public AudioClip[] audioClips;
    public AudioSource audioSource;
    #endregion
    #region SINGLETON CLASS
    private static AudioManager instance;
    public static AudioManager Instance
    {
        get
        {
            if(instance==null)
            {
                instance=new AudioManager();
                if(instance==null)
                {
                    instance = GameObject.Find("AudioManager").GetComponent<AudioManager>();
                }
            }
            return instance;
        }
    }
    #endregion
    #region PUBLIC METHODS
    public void ActivatingBackgroundSound()
    {
        audioSource.clip = audioClips[0];
        audioSource.Play();
    }
    public void ActivatingCoinSound()
    {
        audioSource.clip = audioClips[1];
        audioSource.Play();
    }
    public void ActivatingPowerupSound()
    {
        audioSource.clip = audioClips[2];
        audioSource.Play();
    }
    public void ActivatingEnemyDeathSound()
    {
        audioSource.clip = audioClips[3];
        audioSource.Play();
    }
    public void ActivatingPlayerDeathSound()
    {
        audioSource.clip = audioClips[4];
        audioSource.Play();
    }
    public void ActivatingLevelWonSound()
    {
        audioSource.clip = audioClips[5];
        audioSource.Play();
    }
    #endregion

    #region MONOBEHAVIOUR METHODS
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    #endregion
}
