using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
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

    #endregion
}
