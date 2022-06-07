using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    #region PRIVATE VARIABLES

    #endregion
    #region PUBLIC VARIABLES
    public GameObject homePanel;
    public GameObject instructionPanel;
    public GameObject settingPanel;
    #endregion
    #region MONOBEHAVIOUR METHODS
    void Start()
    {
        AllPanelInactive();
        homePanel.SetActive(true);     // Intially only home panel set to active
    }

    // Update is called once per frame
    void Update()
    {

    }
    #endregion
    #region PUBLIC METHODS
    public void StartGame()
    {
        Debug.Log("Button Clicking");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);       //Loading game scene by clicking the play button 
    }
    public void ActivatingInstructionPanel()
    {
        AllPanelInactive();
        instructionPanel.SetActive(true);     // Making only instruction panel to active
    }
    public void ActivatingSettingPanel()
    {
        AllPanelInactive();
        settingPanel.SetActive(true);      // Making only setting panel to active
    }
    public void BackToHome()
    {
        AllPanelInactive();
        homePanel.SetActive(true);  //Returning to Home panel
    }
    public void AllPanelInactive()    // Setting all panels to inactive
    {
        homePanel.SetActive(false);
        instructionPanel.SetActive(false);
        settingPanel.SetActive(false);
    }
    #endregion
    #region PRIVATE METHODS

    #endregion

}
