﻿using Assets.Scripts.Utils;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : Character
{
    public PlayerInteractionZone interactionZone;

    Animator animator;

    Rigidbody2D myBody;
    readonly float speed = 5;
    private bool lockMove;
    public bool forceStopMove;
    public bool blockInteraction;

    // Use this for initialization
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (forceStopMove)
        {
            ForceStop();
        }
        else
        {
            ManageInput();
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hole"))
        {
            if (Inventory.Instance.CanFly)
            {
                animator.SetBool("IsFlying", true);
            }
            else
            {
                this.transform.position = collision.gameObject.GetComponent<Hole>().RespawnPosition;
                transform.position = new Vector3(transform.position.x, transform.position.y, -2.0f);
                lockMove = true;
                if (SceneManager.GetActiveScene().buildIndex == 1) //on est dans la scene dracula
                {
                    if (FindObjectOfType<Dracula>().IsOnTheOtherSide)
                    {
                        var myInitializer = FindObjectOfType<Initializer>();
                        myInitializer.ShowHoles();
                        var MyTimer = new System.Threading.Timer(_ => myInitializer.mustHideHoles = true, null, 750, 0);
                    }
                }
            }
        }
    }

    private void ForceStop()
    {
        StopMovement();
    }

    private void ManageInput()
    {
        if(GameManager.Instance.isGameFinished) {
            return;
        }
        #region movement
        if (Input.GetKeyUp(KeyCode.DownArrow)
            || Input.GetKeyUp(KeyCode.UpArrow)
            || Input.GetKeyUp(KeyCode.RightArrow)
            || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            StopMovement();
            animator.SetInteger("Walk", 0);

            lockMove = false;
        }

        #region down key
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            RotateTrigger(Directions.Down);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            AddMovement(Directions.Down);
            animator.SetInteger("Walk", 1);

        }
        #endregion down key        
        #region up key
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            RotateTrigger(Directions.Up);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            AddMovement(Directions.Up);
            animator.SetInteger("Walk", 4);

        }
        #endregion up key        
        #region right key
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            RotateTrigger(Directions.Right);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            AddMovement(Directions.Right);
            animator.SetInteger("Walk", 3);

        }
        #endregion right key       
        #region left key
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            RotateTrigger(Directions.Left);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            AddMovement(Directions.Left);
            animator.SetInteger("Walk", 2);
        }
        #endregion left key
        #endregion movement
        #region action
        if (Input.GetKey(KeyCode.Space) && interactionZone.CurrentInteractablesList.Any() && !blockInteraction)
        {
            interactionZone.CurrentInteractablesList.First().Interact();
        }
        #endregion action
    }
    #region movement
    private void AddMovement(Directions dir)
    {
        StopMovement();
        if (lockMove) return;
        switch (dir)
        {
            case Directions.Down:
                myBody.velocity = Vector2.down * speed;
                break;
            case Directions.Up:
                myBody.velocity = Vector2.up * speed;
                break;
            case Directions.Right:
                myBody.velocity = Vector2.right * speed;
                break;
            case Directions.Left:
                myBody.velocity = Vector2.left * speed;
                break;
        }
    }

    private void StopMovement()
    {
        myBody.velocity = new Vector2(0, 0);
    }

    private void RotateTrigger(Directions dir)
    {
        Vector2 translationVector = new Vector2();
        switch (dir)
        {
            case Directions.Up:
                translationVector = Vector2.up;
                break;
            case Directions.Down:
                translationVector = Vector2.down;
                break;
            case Directions.Left:
                translationVector = Vector2.left;
                break;
            case Directions.Right:
                translationVector = Vector2.right;
                break;
        }

        interactionZone.transform.localPosition = new Vector3(translationVector.x * 0.5f, translationVector.y * 0.5f, this.transform.position.z);
    }

    protected override DialogLine[] GetDialogLines()
    {
        //Do ntohing
        return null;
    }
    #endregion movement
}
