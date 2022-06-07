using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    #region PRIVATE VARIABLES
    private int score;
    #endregion
    #region
   // public Text scoreText;
    #endregion
    #region SINGLETON CLASS
    private static ScoreManager instance;
    public static ScoreManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ScoreManager();
                if (instance == null)
                {
                    GameObject container = GameObject.Find("ScoreManager");
                    instance = container.GetComponent<ScoreManager>();
                }
            }
            return instance;

        }
    }
    #endregion
    #region PUBLIC METHODS
    public void Score(int value)
    {
        score += value;
       // scoreText.GetComponent<Text>().text = score.ToString();
    }
    #endregion

}
