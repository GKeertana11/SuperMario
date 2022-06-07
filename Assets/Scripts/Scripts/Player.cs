using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{

    #region PUBLIC VARIABLES
    public int playerSpeed;
    public int playerJumpForce;
    public GameObject coinParticleEffect;
    public GameObject powerParticleEffect;
    public GameObject enemyDeathParticleEffect;


    #endregion

    #region PRIVATE VARIABLES
    private PlayerControl controls;
    InputAction movement;
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer renderer;
    private bool IsJump = false;
    private float inputValue;
    #endregion


    #region MONOBEHAVIOUR METHODS
    void Awake()
    {
        controls = new PlayerControl();                   // Creating Input System Object
        controls.Player.Movement.performed += ctx => Movement(ctx.ReadValue<Vector2>());   // Adding Movement Event
        controls.Player.Jump.performed += ctx => Jump();     // Adding Jump Event

    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (inputValue != 0)
            animator.SetBool("IsIdle", false);
        else
            animator.SetBool("IsIdle", true);
    }
    private void OnEnable()
    {
        controls.Enable();      // Enabling the player actions
    }
    private void OnDisable()
    {
        controls.Disable();  // Disabling the player actions 
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer==Constants.GROUND_LAYER_NUMBER)  //Making jump as false , when player is on ground
        {
            IsJump = false;
            animator.SetBool("IsJump", false);
        }
        if (collision.gameObject.layer==Constants.ENEMY_LAYER_NUMBER)     // Collision with Enemy 
        {
            if (IsJump)               // PLayer in jumping state can kill the enemy
            {
                AudioManager.Instance.ActivatingEnemyDeathSound();
                GameObject temp = Instantiate(enemyDeathParticleEffect, collision.gameObject.transform.position, Quaternion.identity);

                Destroy(collision.gameObject);
                Destroy(temp, 0.2f);
            }
            else if(this.gameObject.transform.localScale.x>1f)  // If player have a power
            {
                this.gameObject.transform.localScale = Vector3.one;
            }
            else  // If player doesn't have power and collided with enemy 
            {
                AudioManager.Instance.ActivatingPlayerDeathSound();
                Destroy(this.gameObject);
            }

        }
        if(collision.gameObject.layer==Constants.COIN_LAYER_NUMBER)
        {
            AudioManager.Instance.ActivatingCoinSound();
            GameObject temp = Instantiate(coinParticleEffect, collision.gameObject.transform.position, Quaternion.identity);

            Destroy(collision.gameObject);
            Destroy(temp, 0.2f);

            ScoreManager.Instance.Score(2);

        }
        if (collision.gameObject.tag == "SuperPower")
        {
            AudioManager.Instance.ActivatingPowerupSound();
            GameObject temp = Instantiate(powerParticleEffect, collision.gameObject.transform.position, Quaternion.identity);

            Destroy(collision.gameObject);
            Destroy(temp, 0.2f);
            
           
            GameManager.Instance.ActivatingSuperPower(this.gameObject);
        }
        if (collision.gameObject.tag == "MegaPower")
        {
            AudioManager.Instance.ActivatingPowerupSound();
            GameObject temp = Instantiate(powerParticleEffect, collision.gameObject.transform.position, Quaternion.identity);

            Destroy(collision.gameObject);
            Destroy(temp, 0.2f);
            GameManager.Instance.ActivatingMegaPower(this.gameObject);

        }

        if(collision.gameObject.layer==Constants.WATER_LAYER_NUMBER ||collision.gameObject.layer==Constants.FIRE_LAYER_NUMBER)
        {
            AudioManager.Instance.ActivatingPlayerDeathSound();

            Destroy(this.gameObject);// Game end panel
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Treasure")    // When reaches the end of the level
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Destroy(collision.gameObject);
            
            AudioManager.Instance.ActivatingLevelWonSound();
            
        }
    }
    #endregion

    #region PUBLIC METHODS

    #endregion
    #region PRIVATE METHODS
    void Movement(Vector2 value)
    {
        if (value.x < 0)
            renderer.flipX = true;
        else
            renderer.flipX = false;
        inputValue = value.x;
        rb.velocity = value * playerSpeed;
       // transform.Translate(value * playerSpeed * Time.deltaTime);
    }
    void Jump()
    {
        IsJump = true;
        animator.SetBool("IsJump", true);
        rb.AddForce(Vector2.up * playerJumpForce, ForceMode2D.Impulse);
        

    }
    #endregion


}
