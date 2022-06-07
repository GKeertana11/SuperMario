using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScript : MonoBehaviour
{
    #region PUBLIC VARIABLES
    public Slider slider;
    #endregion
    #region PRIVATE VARIABLES
    float time;
    #endregion
    #region MONOBEHAVIOUR METHODS
    void Start()
    {

    }

    
    void Update()
    {
        time = Time.time;
        slider.value = time/5f;
        if(slider.value==1)
        {
            SceneManager.LoadScene("02_MenuScene");
        }

    }
    #endregion
    #region PUBLIC METHODS

    #endregion
    #region PRIVATE METHODS

    #endregion

}
