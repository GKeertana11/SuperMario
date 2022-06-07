using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region PUBLIC VARIABLES
    public GameObject playerMegaPower;
    public Transform player;


    #endregion
    #region PRIVATE VARIABLES
    GameObject temp;
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
        obj.transform.localScale += new Vector3(0.5f,0.5f,0f);          //Increasing the size of the player
    }
    public void ActivatingMegaPower(GameObject obj)
    {
        // temp = Instantiate(playerMegaPower, player.transform.position, Quaternion.identity);
        playerMegaPower.SetActive(true);
        Physics2D.IgnoreLayerCollision(3, 7);   //Ignoring the collision between enemy and player
        Physics2D.IgnoreLayerCollision(3, 9);    //Ignoring the collision between fire and player

        StartCoroutine("StartingPower", obj);

    }
    IEnumerator StartingPower(GameObject obj)
    {

        yield return new WaitForSeconds(15);
        //Destroy(temp);
        playerMegaPower.SetActive(false);
        Physics2D.IgnoreLayerCollision(3, 7, false);// Making collision active
        Physics2D.IgnoreLayerCollision(3, 9, false);// Making collision active    

    }
    #endregion
}
