using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    Collider2D triggerCollider;
    List<IInteractable> currentInteractablesList = new List<IInteractable>();
    Rigidbody2D myBody;
    float speed = 5;

    // Use this for initialization
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        triggerCollider = GetComponents<Collider2D>().First(col => col.isTrigger);
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
        #region movement
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
            RotateTrigger(Directions.Down);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            AddMovement(Directions.Down);
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
        }
        #endregion left key
        #endregion movement
        #region action
        if (Input.GetKey(KeyCode.Space) && currentInteractablesList.Any())
        {
            currentInteractablesList.First().Interact();
        }
        #endregion action
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

        triggerCollider.offset = translationVector * 0.5f;
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
