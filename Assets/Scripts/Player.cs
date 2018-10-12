using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    List<IInteractable> currentInteractablesList = new List<IInteractable>();
    Rigidbody2D myBody;
    float speed = 5;

    // Use this for initialization
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ManageInput();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        IInteractable otherObj = collision.gameObject.GetComponent<IInteractable>();
        if (otherObj != null)
        {
            currentInteractablesList.Add(otherObj);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        IInteractable otherObj = collision.gameObject.GetComponent<IInteractable>();
        if (otherObj != null)
        {
            currentInteractablesList.Remove(otherObj);
        }
    }

    private void ManageInput()
    {
        if (Input.GetKeyUp(KeyCode.DownArrow) 
            || Input.GetKeyUp(KeyCode.UpArrow) 
            || Input.GetKeyUp(KeyCode.RightArrow) 
            || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            StopMovement();
        }

        #region down key
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            // rotate
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            AddMovement(Directions.Down);
        }
        #endregion down key        
        #region up key
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            // rotate
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            AddMovement(Directions.Up);
        }
        #endregion up key        
        #region right key
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            // rotate
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            AddMovement(Directions.Right);
        }
        #endregion right key       
        #region left key
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // rotate
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            AddMovement(Directions.Left);
        }
        #endregion left key
    }
    #region movement
    private void AddMovement(Directions dir)
    {
        StopMovement();
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
    #endregion movement

    private enum Directions
    {
        Up,
        Down,
        Left,
        Right
    }
}
