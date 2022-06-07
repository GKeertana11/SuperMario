using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region PRIVATE VARIABLES

    #endregion
    #region SINGLETON CLASS
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new GameManager();
                if(instance==null)
                {
                    instance = GameObject.Find("GameManager").GetComponent<GameManager>();
                }
            }
            return instance;
        }
    }
    #endregion
    #region PUBLIC METHODS
    public void ActivatingSuperPower(GameObject obj)
    {
        obj.transform.localScale += Vector3.one;          //Increasing the size of the player
    }
    public void ActivatingMegaPower(GameObject obj)
    {

        Physics2D.IgnoreLayerCollision(3, 7);       //Ignoring the collision between enemy and player
        StartCoroutine("StartingPower", obj);

    }
    IEnumerator StartingPower(GameObject obj)
    {

        yield return new WaitForSeconds(5);
        Physics2D.IgnoreLayerCollision(3, 7, false);    // Making collision active    

    }
    #endregion
}
